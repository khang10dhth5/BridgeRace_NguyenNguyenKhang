using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMono<UIManager>
{
    public GameObject pnlMainMenu;
    public LevelUIManager pnlLevel;
    public GameObject pnlStartGame;
    public RewardUI pnlReward;
    public PauseGameUI pnlPauseGame;
    public Button btnPauseGame;
    public Text txtCoin;

    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnStartGame;

    private void Start()
    {
        OnInit();
    }
    private void OnInit()
    {
        btnPauseGame.gameObject.SetActive(false);
        btnPlay.onClick.AddListener(() =>
        {
            pnlMainMenu.SetActive(false);
            pnlLevel.gameObject.SetActive(true);
        });
        btnStartGame.onClick.AddListener(() =>
        {
            pnlStartGame.SetActive(false);
            GameManager.Instance.gameState = GameState.PlayGame;
            btnPauseGame.gameObject.SetActive(true);
        });
        btnPauseGame.onClick.AddListener(() =>
        {
            pnlPauseGame.gameObject.SetActive(true);
            Time.timeScale = 0;
        });
        txtCoin.text = GameManager.Instance.Coin.ToString();
    }
    public void ShowReward(bool isWin, int reward)
    {
        pnlReward.SetResult(isWin, reward);
        pnlReward.gameObject.SetActive(true);
    }
}
