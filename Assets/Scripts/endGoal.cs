using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGoal : MonoBehaviour
{

    public GameObject door;
    public GameObject door1;
    public GameObject player;
    public bool close;
    public float speed;
    public float playerX ;
    public float playerZ ;
    public float doorX;
    public float doorZ;
    public float doorY;
    public float distanceX;
    public float distanceZ;
    public int key;
    public PlayerKeyCollect f;
    Collider m_ObjectCollider;
    public bool collition = false;
    // Start is called before the first frame update
    void Start()
    {
        close = true;
        m_ObjectCollider = door1.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        doorX=door.transform.position.x;
        doorZ = door.transform.position.z+2;
        doorY = door.transform.position.y;
        distanceX = Mathf.Sqrt(Mathf.Pow((playerX - doorX),2) + Mathf.Pow((playerZ - doorZ),2));
        distanceZ = Mathf.Pow((playerX - doorX), 2);
        float time = Time.deltaTime;
        key = f.keysCollected;

        if (distanceX <= 3 && close)
        {

            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + speed, door.transform.position.z);

            if (key>=2)
            {
                m_ObjectCollider.isTrigger = true;
                collition = true;
            }
            if (doorY >= 9)
            {
                close = false;
            }
            
        }
        else if (!close&& distanceX > 3)
        {
            
            if (door.transform.position.y > 6.89f)
            {
                door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - speed, door.transform.position.z); 
                if (door.transform.position.y <= 6.90f)
                {
                    close = true;
                }
            }
        }

       
    }

   
}
