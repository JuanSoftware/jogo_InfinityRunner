using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] grounds;

    

    private float lastX;

    void Start()
    {
        GetGroundAndSetLastX();
        
    }

    void GetGroundAndSetLastX()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");

        lastX = grounds[0].transform.position.x;

        for (int i = 0; i < grounds.Length; i++)
        {
            if (lastX < grounds[i].transform.position.x)
            {
                lastX = grounds[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Ground")
        {
            Vector3 temp = target.transform.position;
            float height = target.GetComponent<BoxCollider2D>().size.x;

            if (temp.x == lastX)
            {
                for (int i = 0; i < grounds.Length; i++)
                {
                    if (!grounds[i].activeInHierarchy)
                    {
                        temp.x += height;
                        lastX = temp.x;
                        grounds[i].transform.position = temp;
                        grounds[i].SetActive(true);
                    }
                }
            }
        }
    }


    //adicionar aleatoriamente
    

}
