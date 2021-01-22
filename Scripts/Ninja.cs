using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public GameObject shuriken;

    public float moveSpeed = 5f;

    private float cameraY;

    private bool attackPlayer;
    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactive();
    }
    void Deactive()
    {
        if (transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(transform.position.y < 0)
        {
            if(!attackPlayer)
            {
                attackPlayer = true;
                Instantiate(shuriken, transform.position, Quaternion.identity);
            }
        }
    }
}
