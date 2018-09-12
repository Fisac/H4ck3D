using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Transform doorTransform;

    float doorStart;
    float doorStop;

    float lerpTime = 0f;

    void Start()
    {
        doorTransform = GetComponent<Transform>();

        doorStart = doorTransform.position.z;
        doorStop = doorTransform.position.z - 0.1f;
    }

    void OpenDoor()
    {
        lerpTime += 0.5f * Time.deltaTime;
        doorTransform.position = new Vector3(doorTransform.position.x, doorTransform.position.y, Mathf.Lerp(doorStart, doorStop, lerpTime));

        StartCoroutine(DisableMeshRenderer());
        GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator DisableMeshRenderer()
    {
        yield return new WaitForSeconds(lerpTime);
    }
}