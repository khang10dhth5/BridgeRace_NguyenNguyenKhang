using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public ColorType colorType;

    [SerializeField] private Renderer renderer;
    [SerializeField] private GameObject block;


    private void Start()
    {
        OnInit();
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
        Invoke("OnInit",3f);
    }
    private void  OnInit()
    {
        gameObject.SetActive(true);
        colorType =(ColorType) Random.Range(0,ColorManager.Instance.colorSO.listMaterial.Count);
        renderer.material = ColorManager.Instance.GetMaterial(colorType);
    }
}
