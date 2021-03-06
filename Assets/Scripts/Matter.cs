﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Matter", menuName ="Matter")]
public class Matter : ScriptableObject {

    public new string name;

    public float density;

    public float frictionMultiplier;

    public bool isDestructable;

    public bool isPhysical;

    public float breakingPoint;

    public Material matterMaterial;

    public PhysicMaterial physicMaterial;
}
