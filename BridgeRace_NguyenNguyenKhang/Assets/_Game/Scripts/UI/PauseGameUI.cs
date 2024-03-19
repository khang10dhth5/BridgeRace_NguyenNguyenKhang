using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameUI : MonoBehaviour
{
    [SerializeField] private Button btnClose;
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnQuitGame;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    private void OnInit()
    {
        btnClose.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        });
        btnResume.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        });
        btnRetry.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.RetryGame();

        });
        btnQuitGame.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.QuitGame();
        });
    }
}
