using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class CollectableObjectSetter : MonoBehaviour
{
    [SerializeField]
    private CollectableObject theObject;

    [HideInInspector] public GameObject storedObject;
    
    [HideInInspector] public string objectType;

    public float objectNum;
    
   
    
    private void Start()
    {
        //objectType = theObject.objectType;
        objectNum = theObject.objectNum;
        storedObject = theObject.storedObject;
    }

    public void DecreaseNum()
    {
        objectNum -= 1;
        objectNum =Mathf.Clamp(objectNum,0f,Mathf.Infinity);
        
        if (objectNum == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
