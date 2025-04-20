using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        Vector3 teamScale = transform.localScale;

        float height = spriteRenderer.bounds.size.y;
        float width = spriteRenderer.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f; //10
        float worldWidth = worldHeight * Screen.width / Screen.height;

        teamScale.y = worldHeight / height;
        teamScale.x = worldWidth / width;

        transform.localScale = teamScale;
    }
}
