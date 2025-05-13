using UnityEngine;

public class SimpleGrabber : MonoBehaviour
{
    public string targetTag = "Box";
    public Transform attachPoint;

    private GameObject currentTarget = null;
    private bool isHolding = false;

    void OnTriggerStay(Collider other)
    {
        if (!isHolding && other.CompareTag(targetTag))
        {
            currentTarget = other.gameObject;
        }
    }

    public void GrabObject()
    {
        if (isHolding || currentTarget == null) return;

        currentTarget.transform.SetParent(attachPoint);
        var rb = currentTarget.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        isHolding = true;
    }

    public void ReleaseObject()
    {
        if (!isHolding || currentTarget == null) return;

        currentTarget.transform.SetParent(null);
        var rb = currentTarget.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = false;

        currentTarget = null;
        isHolding = false;
    }
}
