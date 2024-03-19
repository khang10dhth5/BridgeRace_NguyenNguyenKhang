using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : SingletonMono<Map>
{
    public Transform finishPoint;
    public Transform startPoint;
    public Stage firstStage;
    public Player player;

    [SerializeField] private Player playerPrefabs;
    private void Awake()
    {
        for (int i = 0; i < ColorManager.Instance.colorSO.listMaterial.Count; i++)
        {
            firstStage.listColorType.Add((ColorType)i);
        }
        firstStage.SetColorForBrick();
    }
    private void Start()
    {
        player = Instantiate(playerPrefabs, startPoint.position, Quaternion.identity);
        player.currentStage = firstStage;
        CameraFollow.Instance.target = player.transform;
    }
}
