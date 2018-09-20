using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {

    public ParticleSystem push;
    public ParticleSystem pull;
    public ParticleSystem drop;

	// Use this for initialization
	void Start () {
        push.Stop();
        pull.Stop();
        drop.Stop();
	}
}
