using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public ColorType colorType;
    public BrickState brickState;

    [SerializeField] private Renderer renderer;
    [SerializeField] private GameObject block;

    private void Start()
    {
        OnInit();
    }

    public void SetColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = ColorManager.Instance.GetMaterial(colorType);
    }
    public void SetState(bool isActive)
    {
        if(isActive)
        {
            brickState = BrickState.Active;
            gameObject.SetActive(true);
        }
        else
        {
            brickState = BrickState.DeAct;
            gameObject.SetActive(false);
        }

    }
    public void OnDespawn()
    {
        brickState = BrickState.DeAct;
        gameObject.SetActive(false);
        Invoke("OnInit",5f);
    }
    private void  OnInit()
    {
        brickState = BrickState.Active;
        gameObject.SetActive(true);
        renderer.material = ColorManager.Instance.GetMaterial(colorType);
    }
}
