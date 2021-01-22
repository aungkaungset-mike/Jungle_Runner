using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private bool attackStarted;
    private bool moveAttack;
    private bool attackRight;

    public float attackSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x > 0)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BeeAttack();
    }

    void BeeAttack()
    {
        if(transform.position.y > 0)
        {
            Vector3 temp = transform.position;
            temp.y -= moveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            if(!attackStarted)
            {
                attackStarted = true;
                StartCoroutine(AttackPlayer());
            }
        }
        if(moveAttack)
        {
            if(!attackRight)
            {
                transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * attackSpeed * Time.deltaTime;
            }
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1f);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, -45f)));

        moveAttack = true;
        Invoke("Deactive", 3f);
    }
}
