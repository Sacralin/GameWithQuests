using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public delegate void CameraSwitched(GameObject newCamera);
    public static event CameraSwitched OnCameraSwitched;
    public GameObject mainCamera;
    public GameObject secondaryCamera;

    


    // Start is called before the first frame update
    void Start()
    {
        SwitchCamera(mainCamera, secondaryCamera);
    }

    private void SwitchCamera(GameObject cameraToEnable, GameObject cameraToDisable)
    {
        cameraToDisable.SetActive(false);
        cameraToEnable.SetActive(true);

        OnCameraSwitched?.Invoke(cameraToEnable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SwitchCamera(secondaryCamera, mainCamera);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SwitchCamera(mainCamera, secondaryCamera);
        }
    }
}
