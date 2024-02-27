using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Collisions : MonoBehaviour
{
    public int score = 0; // Initial score
    public TextMeshProUGUI scorer;
    public TextMeshProUGUI healthtext;
    public TextMeshProUGUI timertext;
    public TextMeshProUGUI outofbounds;
    public int health = 100;
    public float time = 60f;
    public int trashcounter = 0;
    public Vector3 minBound;
    public Vector3 maxBound;

    void Start()
    {
        DisplayScore();
        DisplayHealth();
    }

    void Update()
    {
        // Displays timer that decrements every second
        time -= Time.deltaTime;
        timertext.text = "Time Remaining: " + Mathf.FloorToInt(time).ToString();

        // Check X-axis bounds
        if (transform.position.x < minBound.x || transform.position.x > maxBound.x)
        {
            Reposition();
        }

        // Check Y-axis bounds
        if (transform.position.y < minBound.y || transform.position.y > maxBound.y)
        {
            Reposition();
        }

        // Check Z-axis bounds
        if (transform.position.z < minBound.z || transform.position.z > maxBound.z)
        {
            Reposition();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            // Collided with the trash, add to the score and increase trash counter
            score += 20;
            DisplayScore();
            Destroy(other.gameObject);
            trashcounter++;
        }
        if (other.CompareTag("Collision"))
        {
            // Collided with any other object, subtract from the score and decrement health
            score -= 10;
            DisplayScore();
            health -= 10;
            DisplayHealth();
        }
    }
    // Displays for our score, heakth, and an out of bounds screen

    public void DisplayScore()
    {
        scorer.text = "Score: " + score.ToString();
    }

    public void DisplayHealth()
    {
        healthtext.text = "Health: " + health.ToString();
    }

    public void DisplayBoundsError()
    {
        outofbounds.text = "Out of Bounds!!";
        StartCoroutine(DelayText());

    }

    IEnumerator DelayText()
    {
        // Bounds error message will display for 3 seconds
        yield return new WaitForSeconds(3f);
        outofbounds.text = "";
    }

    void Reposition()
    {
        // Reposition the object to the nearest point within the bounds
        // Added 50 units of breathing room for ship to reposition to
        // lowers score after bounds error
        score -= 10;
        DisplayScore();
        DisplayBoundsError();
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minBound.x + 50f, maxBound.x - 50f),
            Mathf.Clamp(transform.position.y, minBound.y + 50f, maxBound.y - 50f),
            Mathf.Clamp(transform.position.z, minBound.z + 50f, maxBound.z - 50f)
        ); 
    }
}
