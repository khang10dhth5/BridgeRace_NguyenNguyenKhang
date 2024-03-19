using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    [SerializeField] private Text txtLevelIndex;
    [SerializeField] private Image imgLevel;
    [SerializeField] private Button btnClick;
   public void SetLevelItem(Level level, Action<int> actionClick)
    {
        txtLevelIndex.text = level.levelIndex.ToString();
        imgLevel.sprite = level.levelSprite;
        btnClick.onClick.AddListener(() =>
        {
            actionClick.Invoke(level.levelIndex);
        });
    }

}
[Serializable]
public class Level
{
    public int levelIndex;
    public Sprite levelSprite;
}