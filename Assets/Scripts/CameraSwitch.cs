using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondaryCamera;
    public Button switchCam;

    void Start()
    {
        // Makes sure only one camera is enabled at a time, intitally main camera
        mainCamera.enabled = true;
        secondaryCamera.enabled = false;
        EventTrigger trigger = switchCam.gameObject.AddComponent<EventTrigger>();
        var pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((data) => { backCam(); });
        trigger.triggers.Add(pointerDown);

        var pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((data) => { backCam(); });
        trigger.triggers.Add(pointerUp);
    }

    void Update()
    {

    }

    // Disables main camera before enabling back camera
    public void backCam()
    {
        mainCamera.enabled = !mainCamera.enabled;
        secondaryCamera.enabled = !secondaryCamera.enabled;
    }
}
