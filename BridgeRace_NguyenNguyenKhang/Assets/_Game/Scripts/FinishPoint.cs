using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagName.Player.ToString()) || other.CompareTag(TagName.Enemy.ToString()))
        {
            CameraFollow.Instance.target = other.transform;
            other.GetComponent<Character>().ChangeAmin(AminState.win.ToString());
            if(other.CompareTag(TagName.Player.ToString()))
            {
                GameManager.Instance.isWin = true;
            }
            else
            {
                GameManager.Instance.isWin = false;
            }
            Invoke("EndGame", 2f);
        }
    }
    private void EndGame()
    {
        UIManager.Instance.ShowReward(GameManager.Instance.isWin, 300);
        GameManager.Instance.gameState = GameState.EndGame;
        GameManager.Instance.Coin += 300;
        GameManager.Instance.SaveCoin();
        UIManager.Instance.txtCoin.text = GameManager.Instance.Coin.ToString();
    }
}
