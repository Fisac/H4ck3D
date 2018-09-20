using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCube : MonoBehaviour {

    public ParticleSystem swirlies;

    private void OnEnable()
    {
        swirlies.Play();
    }
    private void OnDisable()
    {
        swirlies.Stop();
    }
}
