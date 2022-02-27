using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private GameObject[] players;
    private void Awake(){
        GameObject.FindGameObjectWithTag("Bot").transform.position = transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
