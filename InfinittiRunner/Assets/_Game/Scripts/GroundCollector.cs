using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollector : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D target)
    {
        if( target.tag == "Ground")
        {
            target.gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
