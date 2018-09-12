using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Matter", menuName ="Matter")]
public class Matter : ScriptableObject {

    public new string name;

    public float mass;

    public float frictionMultiplier;

    public bool isDestructable;

    public bool isPhysical;

    public Material matterMaterial;
}
