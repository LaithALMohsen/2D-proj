using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImgPool : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImgPrefab;

    private Queue<GameObject> availabeObjects = new Queue<GameObject>();

    public static PlayerAfterImgPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        GrowPool();
    }


    private void GrowPool()
    {


        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(afterImgPrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }

   public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);

        availabeObjects.Enqueue(instance);
    }


    public GameObject GetFromPool()
    {


        if(availabeObjects.Count == 0)
        {
            GrowPool();

        }

        var instance = availabeObjects.Dequeue();
        instance.SetActive(true);
        return instance; 

    }



}
