using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectShake : MonoBehaviour
{
    void OnTriggerEnter (Collider other){
        // cameraScript = GameObject.Find("MainCamera").GetComponent(CameraShake);
        GameObject go = GameObject.Find("Main Camera");
        CameraShake ot = (CameraShake) go.GetComponent(typeof(CameraShake));

        // cameraScript = GameObject.FindObjectOfType(typeof(CameraShake)) as CameraShake;
        Debug.Log("This is Awesome");
        ot.shakeCamera();
        this.gameObject.SetActive(false);
    }
}
