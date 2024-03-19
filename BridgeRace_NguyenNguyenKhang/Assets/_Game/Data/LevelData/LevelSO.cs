using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelSO")]
public class LevelSO : ScriptableObject
{
    public List<Level> listLevel;
}
