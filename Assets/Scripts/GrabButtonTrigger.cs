using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabButtonTrigger : MonoBehaviour
{
    public SimpleGrabber grabber; // Об'єкт руки з SimpleGrabber
    public bool grab = true;

    private XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
    }

    void OnEnable()
    {
        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    void OnDisable()
    {
        interactable.selectEntered.RemoveListener(OnButtonPressed);
    }

    void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (grabber == null) return;

        if (grab)
            grabber.GrabObject();
        else
            grabber.ReleaseObject();
    }
}
