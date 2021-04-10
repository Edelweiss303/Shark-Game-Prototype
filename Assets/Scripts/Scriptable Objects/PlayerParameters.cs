using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Parameters")]
public class PlayerParameters : ScriptableObject
{
    public float movementSpeed;
    public float turnSpeed;
    public float boostMultiplier;
    public float boostAmount;
}
