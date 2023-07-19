
using UnityEngine;
using System.Collections;

public class OpenLinkOnClick : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://hammadkhan.itch.io/");
        Debug.Log("Opened Hammad's itch.io page");
    }

}
