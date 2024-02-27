using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    public float boostSpeed = 2f;
    public Button booster;
    public bool hasBoosted;
    public float boostTime = 5f;
    public Collisions collisions;
    public TextMeshProUGUI gameover;
    public TextMeshProUGUI nohealth;

    void Start()
    {
        // This makes the ship boost as long as the boost button is being press down
        EventTrigger trigger = booster.gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((data) => { hasBoosted = true; });
        trigger.triggers.Add(pointerDown);

        var pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((data) => { hasBoosted = false; });
        trigger.triggers.Add(pointerUp);
    }

    void Update()
    {
        // Win screen if we collect all the trash
        if (collisions.trashcounter >= 20)
        {
            gameover.text = "Congrats! You collected all the trash!";
            return;
        }

        // Game over if we lose all our health
        if (collisions.health <= 0)
        {
            nohealth.text = "You Died!";
            return;
        }

        // This makes our ship move forward continously and rotate based on joystick input
        Vector3 movement = new Vector3(0f, 0f, 1f) * speed * Time.deltaTime;
        transform.Translate(movement);
        transform.Rotate(Vector3.left, fixedJoystick.Vertical);
        transform.Rotate(Vector3.up, fixedJoystick.Horizontal);

        
        // Checks if we can boost based on stamina
        if (hasBoosted && boostTime > 0)
        {
            setBoost();
        }
        else
        {
            speed = 10f;
            if (boostTime <= 10f)
            {
                boostTime += (Time.deltaTime / 2);
            }
        }
    }

    // Decrements stamina based on how long we have been boosting
    public void setBoost()
    {
        speed += boostSpeed;
        if (boostTime > 0)
        {
            boostTime -= (Time.deltaTime * 2);
        }
    }
}
