using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public List<Brick> listBrick;
    public List<ColorType> listColorType;
    
    public Transform GetBrick(ColorType colorType)
    {
        for(int i=0;i<listBrick.Count;i++)
        {
            if(listBrick[i].brickState==BrickState.Active&& listBrick[i].colorType==colorType)
            {
                return listBrick[i].transform;
            }
        }
        return null;
    }
    public void ClearColorType(ColorType colorType)
    {
        listColorType.Remove(colorType);
        for (int i = 0; i < listBrick.Count; i++)
        {
            if(listBrick[i].colorType==colorType)
            {
                listBrick[i].SetColor(listColorType[Random.Range(0, listColorType.Count)]);
            }

        }
    }
    public void SetColorForBrick()
    {
        for (int i = 0; i < listBrick.Count; i++)
        {
           listBrick[i].SetColor(listColorType[Random.Range(0,listColorType.Count)]);
            
        }
    }
    public void RandomBrick()
    {
        for (int i = 0; i < listBrick.Count; i++)
        {
            int random = Random.Range(0, 2);
            if(random>0)
            {
                listBrick[i].SetState(true);
                listBrick[i].SetColor(listColorType[Random.Range(0, listColorType.Count)]);
            }
            else
            {
                listBrick[i].SetState(false);
            }
            listBrick[i].SetColor(listColorType[Random.Range(0, listColorType.Count)]);

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag(TagName.Player.ToString()) || other.CompareTag(TagName.Enemy.ToString()))
        {
            Character character = other.GetComponent<Character>();
            character.currentStage.ClearColorType(character.colorType);

            character.currentStage = this;
            listColorType.Add(character.colorType);
            RandomBrick();
        }
    }
}
