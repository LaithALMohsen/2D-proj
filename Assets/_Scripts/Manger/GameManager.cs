using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;


   
    private bool respawn;



    private CinemachineVirtualCamera CVC;
    private void Start()
    {
        CVC = GameObject.Find("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        CheckRespawn();
    }
    public void Respawn()
    {


        respawnTimeStart = Time.time;
        respawn = true; 
    }
   private void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime && respawn)
        {
         var PlayerTemp =    Instantiate(player, respawnPoint);
            CVC.m_Follow = PlayerTemp.transform;
            respawn = false; 
        }

    }
}
