using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public LevelSO levelSO;

    [SerializeField] private LevelItemUI levelItemUIPrefabs;
    [SerializeField] private Transform gridLayoutGroup;
    [SerializeField] private Button btnBackMainMenu;
    private void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnBackMainMenu.onClick.AddListener(()=> {
            UIManager.Instance.pnlMainMenu.SetActive(true);
            //UIManager.Instance.pnlLevel.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        });
    }

    private void OnEnable()
    {
        ClearGridLayout();
        for(int i=0;i<levelSO.listLevel.Count;i++)
        {
            LevelItemUI levelItemUI = Instantiate(levelItemUIPrefabs, gridLayoutGroup);
            levelItemUI.SetLevelItem(levelSO.listLevel[i], OnLevelItemClick);
        }
        
    }

    private void OnLevelItemClick(int index)
    {
        GameManager.Instance.CreateMap(index);
        //UIManager.Instance.pnlLevel.SetActive(false);
        this.gameObject.SetActive(false);
        UIManager.Instance.pnlStartGame.SetActive(true);
    }


    private void ClearGridLayout()
    {
        foreach(Transform chil in gridLayoutGroup)
        {
            Destroy(chil.gameObject);
        }
    }
}
