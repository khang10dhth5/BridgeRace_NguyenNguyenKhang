using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickStair : MonoBehaviour
{
    [HideInInspector] public ColorType colorType;
    [SerializeField] private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    public void ChangeColor(ColorType colorType)
    {
        renderer.material = ColorManager.Instance.GetMaterial(colorType);
        this.colorType = colorType;
    }
    public void OnInit()
    {
        colorType =(ColorType)1000;
    }
    public void OnDespawn()
    {

    }
}
