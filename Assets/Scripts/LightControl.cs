using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LeverLightSwitch : MonoBehaviour
{
    public Light[] lightsToControl;
    public XRLever lever;
    private bool lightsAreOn = false;

    void Start()
    {
        if (lever != null)
        {
            lever.selectEntered.AddListener(_ => ToggleLight());
        }
    }

    private void ToggleLight()
    {
        lightsAreOn = !lightsAreOn;
        foreach (var light in lightsToControl)
        {
            light.enabled = lightsAreOn;
        }
    }
}
