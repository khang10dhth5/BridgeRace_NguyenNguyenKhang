using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrick : MonoBehaviour
{
    [SerializeField] private Renderer renderer;

    public void OnInit(ColorType colorType)
    {
        renderer.material = ColorManager.Instance.GetMaterial(colorType);
    }
}
