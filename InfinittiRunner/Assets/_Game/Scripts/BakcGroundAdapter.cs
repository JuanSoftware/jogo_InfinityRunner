using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakcGroundAdapt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private SpriteRenderer[] spritesRenderer;

    private void Awake()
    {
        float tempTransform = spritesRenderer[0].sprite.bounds.size.x;

        for(int i =0; i < spritesRenderer.Length; i++)
        {

            spritesRenderer[i].transform.position = new Vector2(tempTransform * i, transform.position.y);
        }
    }
}
