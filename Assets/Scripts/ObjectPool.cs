using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;

    public Transform StartPos;
    // public Transform EndPos;

   

    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {

        CreateCoin();
    }

    public void Update()
    {
   
    }

    private void CreateCoin()
    {
        
        GameObject tmp;

        for (int i = 0; i < AmountToPool; i++)
        {
            //            tmp = Instantiate(ObjectToPool);
            tmp = Instantiate(ObjectToPool, new Vector3(0, 3, StartPos.position.z + i * 20f), Quaternion.Euler(0, 90, 90));


            tmp.SetActive(true);
            PooledObjects.Add(tmp);
        }
    }
   
    //public GameObject GetPooledObject()
    //{
    //    for (int i = 0; i < AmountToPool; i++)
    //    {
    //        if (!PooledObjects[i].activeInHierarchy)
    //        {
    //            return PooledObjects[i];
    //        }
    //    }
    //    return null;
    //}
}
