using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
   public GameObject playerPrefbs;
   public Transform[] spawnPoints;

   void Start()
   {
       int randNumber = Random.Range(0,spawnPoints.Length);
       Transform spawnPoint = spawnPoints[randNumber];
       PhotonNetwork.Instantiate(playerPrefbs.name,spawnPoint.position,Quaternion.identity);
   }
}
