using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SceneSwitch sceneSwitch;
    Transform doorTransform;

    float doorStart;
    float doorStop;

    float lerpTime = 0f;

    private void Awake()
    {
        if(sceneSwitch == null)
        {
            sceneSwitch = FindObjectOfType<SceneSwitch>();
        }
    }

    void Start()
    {
        doorTransform = GetComponent<Transform>();

        doorStart = doorTransform.position.z;
        doorStop = doorTransform.position.z - 0.1f;
    }

    public void OpenDoor()
    {
        FindObjectOfType<SoundManager>().PlaySound("Win");

        lerpTime += 0.5f * Time.deltaTime;
        doorTransform.position = new Vector3(doorTransform.position.x, doorTransform.position.y, Mathf.Lerp(doorStart, doorStop, lerpTime));

        StartCoroutine(DisableMeshRenderer());
        GetComponent<MeshRenderer>().enabled = false;

        sceneSwitch.FadeToNextLevel();
    }

    IEnumerator DisableMeshRenderer()
    {
        yield return new WaitForSeconds(lerpTime);
    }
}