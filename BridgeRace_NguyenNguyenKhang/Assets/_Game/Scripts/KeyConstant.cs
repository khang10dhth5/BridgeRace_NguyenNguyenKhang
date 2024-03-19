using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConstant
{
    public const string KEY_COIN = "coin";
}

public class PathConstant
{
    public const string MAP_PATH = "Map/Map_";
}
public enum GameState
{
    Begin,
    PlayGame,
    EndGame
}
public enum AminState
{
    idle,
    run,
    win
}
public enum Result
{
    WIN,
    LOSE
}
public enum TagName
{
    Player,
    Enemy,
    Brick,
    BrickStair
}
public enum ColorType
{
     Black,
     Green,
     White
}
public enum BrickState
{
    DeAct,
    Active
}
