using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocatorStates", menuName = "ScriptableObjects/LocatorStates", order = 1)]
public class LocatorStates : ScriptableObject
{
    [field: SerializeField] public List<LocatorState> states;
}



[Serializable]
public class LocatorState
{
    public int number;
    public string soundName;
    public Sprite image;
}
