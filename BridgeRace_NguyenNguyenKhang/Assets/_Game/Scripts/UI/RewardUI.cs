using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    [SerializeField] private Text txtResult;
    [SerializeField] private Text txtReward;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnNextLevel;

    private void Start()
    {
        OnInit();
    }
    public void SetResult(bool isWin, int reward)
    {
        if(isWin)
        {
            txtResult.text = Result.WIN.ToString();
            txtReward.text = reward.ToString();
        }
        else
        {

            txtResult.text = Result.LOSE.ToString();
            txtReward.text = 0+"";
        }
        
    }

    private void OnInit()
    {
        btnRetry.onClick.AddListener(()=> {
            GameManager.Instance.RetryGame();
            this.gameObject.SetActive(false);
        });
        btnNextLevel.onClick.AddListener(() =>
        {
            GameManager.Instance.NextLevel();
            this.gameObject.SetActive(false);

        });
    }
}
