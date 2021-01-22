using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] SpriteRenderer backgroundSprite;
    // Start is called before the first frame update
    void Start()
    {
        float orthoSize = backgroundSprite.bounds.size.x * Screen.height / Screen.width * 0.5f;

        Camera.main.orthographicSize = orthoSize;
    }
}
