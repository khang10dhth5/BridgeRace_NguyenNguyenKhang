using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorManager : SingletonMono<ColorManager>
{
    public ColorSO colorSO;

    public Material GetMaterial(ColorType colorType)
    {
        return colorSO.listMaterial[(int)colorType];
    }
}
