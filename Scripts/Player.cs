using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Animator anim;

    private bool isLeft, isRight, isJump;

    [SerializeField] AudioSource audioKill, audioJump, audioDead;

    private bool isAlive = true;
    private AudioClip deadSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("JumpBtn").GetComponent<Button>().onClick.AddListener(Jump);
        anim = GetComponent<Animator>();
        isRight = true;
        isLeft = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!isJump)
            {
                if (isRight)
                {
                    anim.Play("RunR");
                }
                else
                {
                    anim.Play("RunL");
                }
              

            }
        }
    }
    public void Jump()
    {
        if (isAlive)
        {
            if (isRight)
            {
                anim.Play("JumpL");
            }
            else
            {
                anim.Play("JumpR");
            }
            isJump = true;
            audioJump.Play();
        }
    }
    public void OnLeft()
    {
        isLeft = true;
        isRight = false;
        isJump = false;
    }
    public void OnRight()
    {
        isLeft = false;
        isRight = true;
        isJump = false;
    }
    void PlayerDied()
    {
        audioDead.Play();

        isAlive = false;

        if (transform.position.x > 0)
        {
            anim.Play("DieR");
        }
        else
        {
            anim.Play("DieL");
        }

        GameplayController.instance.Gameover();
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (isJump)
        {
            if (target.tag == "Enemy")
            {
                target.gameObject.SetActive(false);
                audioKill.Play();
            }
        }
        else
        {
            if (target.tag == "Enemy")
            {
                PlayerDied();
            }
        }
        if (target.tag == "EnemyTree")
        {
            PlayerDied();
        }
        if (target.tag == "Shuriken")
        {
            PlayerDied();
        }
        if (target.tag == "Ninja")
        {
            target.gameObject.SetActive(false);
            audioKill.Play();
        }
    }
}
