using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMover : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject[] sideBounds;

    public float heightBound;

    public float cameraY;

    public GameObject[] enemies;

    public GameObject[] spawner;
    // Start is called before the first frame update
    void Awake()
    {
        sideBounds = GameObject.FindGameObjectsWithTag("SideBounds");

        cameraY = Camera.main.gameObject.transform.position.y - 15f;

        heightBound = GetComponent<BoxCollider2D>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Reposition();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }
    void Reposition()
    {
        if(transform.position.y < cameraY)
        {
            float highestBoundsY = sideBounds[0].transform.position.y;

            for(int i = 1; i<sideBounds.Length; i++)
            {
                if (highestBoundsY < sideBounds[i].transform.position.y)
                {
                    highestBoundsY = sideBounds[i].transform.position.y;
                }
            }

            Vector3 temp = transform.position;
            temp.y = highestBoundsY + heightBound -1f;
            transform.position = temp;

            Spawn();
        }
    }
    void Spawn()
    {
        if(Random.Range(0,10) > 0)
        {
            int RandomEnemy = Random.Range(0, enemies.Length);

            if(RandomEnemy == 0)
            {
                Instantiate(enemies[RandomEnemy], new Vector3(0f, transform.position.y, 3f), Quaternion.identity);
            }
            else
            {
                GameObject enemyObj = Instantiate(enemies[RandomEnemy]);
                Vector3 enemyScale = enemyObj.transform.localScale;

                if(Random.Range(0,2) > 0)
                {
                    enemyObj.transform.position = spawner[0].transform.position;
                    enemyScale.x = -Mathf.Abs(enemyScale.x);
                }
                else
                {
                    enemyObj.transform.position = spawner[1].transform.position;
                    enemyScale.x = Mathf.Abs(enemyScale.x);
                }
                enemyObj.transform.localScale = enemyScale;
            }
        }
    }
}
