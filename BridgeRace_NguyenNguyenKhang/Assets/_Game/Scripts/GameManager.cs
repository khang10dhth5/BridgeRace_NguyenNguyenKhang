using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    public GameState gameState;
    public bool isWin;

  
    private Map currentMap;
    private int currenLevelIndex;
    private int coin;
    public int Coin { get => coin; set => coin = value; }

    private void Start()
    {

        OnInit();
    }

    private void OnInit()
    {
        gameState = GameState.Begin;
        if(!PlayerPrefs.HasKey(KeyConstant.KEY_COIN))
        {
            PlayerPrefs.SetInt(KeyConstant.KEY_COIN, Coin);
        }
        else
        {
            Coin = PlayerPrefs.GetInt(KeyConstant.KEY_COIN);
        }
    }
    public void SaveCoin()
    {
        PlayerPrefs.SetInt(KeyConstant.KEY_COIN, Coin);
    }
    public void CreateMap(int levelIndex)
    {
        Map map = Resources.Load<Map>(PathConstant.MAP_PATH+levelIndex);
        currentMap = Instantiate(map);
        currenLevelIndex = levelIndex;
    }

    internal void RetryGame()
    {
        DestroyMap();
        CreateMap(currenLevelIndex);
        UIManager.Instance.pnlStartGame.SetActive(true);

    }
    public void DestroyMap()
    {
        gameState = GameState.Begin;
        Destroy(currentMap.player.gameObject);
        Destroy(currentMap.gameObject);
    }
    public void NextLevel()
    {
        int index = currenLevelIndex+1;
        if(UIManager.Instance.pnlLevel.levelSO.listLevel.Count<index)
        {
            return;
        }
        DestroyMap();
        CreateMap(index);
        currenLevelIndex = index;
        UIManager.Instance.pnlStartGame.SetActive(true);
    }
    public void QuitGame()
    {
        DestroyMap();
        UIManager.Instance.pnlLevel.gameObject.SetActive(true);
        UIManager.Instance.btnPauseGame.gameObject.SetActive(false);
    }
}
