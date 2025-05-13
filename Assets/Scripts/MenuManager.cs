using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject welcomePanel;
    public GameObject xrRig;

    public void StartScene()
    {
        welcomePanel.SetActive(false);
        xrRig.SetActive(true);
    }
}
