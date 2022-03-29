using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShake : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        // cameraScript = GameObject.Find("MainCamera").GetComponent(CameraShake);
        cameraScript = GameObject.FindObjectOfType(typeof(CameraShake)) as CameraShake;
        Debug.Log("I'm colliding with: " + cameraScript);
        cameraScript.shakeCamera();
        this.gameObject.SetActive(false);
    }
}
