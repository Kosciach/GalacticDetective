using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpaceShip", menuName = "SpaceShips")]
public class SpaceShip : ScriptableObject
{
    public string Name;
    public float Speed;
    public float Size;
    public string EngineType;
    public float MagneticFieldStrength;
    public float Loudness;
    public string RhytmCode;
}
