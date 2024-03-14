using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "ScriptableObjects/ColorData")]
public class ColorSO : ScriptableObject
{
    public List<Material> listMaterial;  
}
