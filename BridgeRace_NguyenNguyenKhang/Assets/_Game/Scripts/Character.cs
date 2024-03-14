using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;

    [SerializeField] private Renderer renderer;
    [SerializeField] private Animator amin;
    [SerializeField] private ColorType colorType;
    [SerializeField] private Transform brickTransform;
    [SerializeField] private PlayerBrick brickPlayerPrefabs;
    [SerializeField] private Transform model;
    [SerializeField] private LayerMask layerMaskStair;

    private string currentAmin;
    protected Stack brickStack=new Stack();
    public virtual void Start()
    {
        renderer.material=ColorManager.Instance.colorSO.listMaterial[(int)colorType];
        Debug.Log(colorType);
    }
    private void Update()
    {
            
    }
    public virtual void Onit()
    {

    }
    public virtual void OnDespawn()
    {

    }


    protected void ChangeAmin(string aminName)
    {
        if(currentAmin==null)
        {
            currentAmin = AminState.idle.ToString();
        }
        if(currentAmin!=aminName)
        {
            amin.ResetTrigger(currentAmin);
            currentAmin = aminName;
            amin.SetTrigger(currentAmin);
        }
    }

    protected void AddBrick()
    {
        Debug.Log("addBrick");
        PlayerBrick playerBrick = Instantiate(brickPlayerPrefabs, brickTransform.position,gameObject.transform.rotation);
        playerBrick.transform.SetParent(model);
        playerBrick.OnInit(colorType);

        brickStack.Push(playerBrick);
        brickTransform.position = new Vector3(brickTransform.position.x, brickTransform.position.y + 0.3f, brickTransform.position.z);
    }
    protected void RemoveBrick()
    {
        Debug.Log("RemoveBrick");
        PlayerBrick playerBrick =(PlayerBrick) brickStack.Pop();
        brickTransform.position = new Vector3(brickTransform.position.x, brickTransform.position.y - 0.3f, brickTransform.position.z);
        Destroy(playerBrick.gameObject);
    }
    protected bool IsStair()
    {
        if(Physics.Raycast(transform.position,Vector3.forward,out RaycastHit hit,1f,layerMaskStair))
        {
            Debug.DrawRay(transform.position , Vector3.forward,Color.blue,10f);
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);
                BrickStair brickstair = hit.transform.GetComponent<BrickStair>();
                if (brickstair.colorType != colorType)
                    return true;
            }
        }
        return false;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagName.BrickStair.ToString()))
        {
            BrickStair brickstair = other.GetComponent<BrickStair>();
            if (brickStack.Count > 0)
            {
                if(brickstair.colorType!=colorType)
                {
                    RemoveBrick();
                    brickstair.ChangeColor(colorType);
                }

            }
            else
            {
                return;
            }
        }
        if (other.CompareTag(TagName.Brick.ToString()))
        {
            Brick brick = other.GetComponent<Brick>();
            if (brick.colorType == colorType)
            {
                brick.OnDespawn();
                AddBrick();
            }
            
        }
    }
}
