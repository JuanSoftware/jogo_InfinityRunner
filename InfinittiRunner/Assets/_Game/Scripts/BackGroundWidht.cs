using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundWidht : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;

    private void Awake() {
        sprite = this.gameObject.GetComponent<SpriteRenderer>(); 
    }
    void Start()
    {
        Vector3 escalaTemp = transform.localScale;

        float largura = sprite.bounds.size.x;
        float altura = sprite.bounds.size.y;

        float alturaWorld = Camera.main.orthographicSize * 2f;
        float larguraWorld = alturaWorld /Screen.height * Screen.width;

        escalaTemp.x = larguraWorld / largura;

        transform.localScale = escalaTemp;
    }

    // Update is called once per frame
   
}
