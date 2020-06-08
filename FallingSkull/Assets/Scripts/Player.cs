using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMesh itemText;
    public GameManager gameManager;
    public float moveSpeed;

    float movement;

    Animator anim;
    SpriteRenderer sprite;
    Vector3 playerPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerPos = GetComponent<Player>().transform.position;
    }

    void Update()
    {
        OnMove();
    }

    void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.back, movement * Time.fixedDeltaTime * moveSpeed);
    }

    void OnMove()
    {
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Horizontal"))
        {
            sprite.flipX = (Input.GetAxisRaw("Horizontal") == -1);
        }

        anim.SetInteger("movement", (int)movement);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            OnHit();
        }
        else if (collision.tag == "Item")
        {
            bool isHealthPill = collision.gameObject.name.Contains("HealthPill");
            bool isInvincibilityPill = collision.gameObject.name.Contains("InvincibilityPill");
            bool isBronze = collision.gameObject.name.Contains("BronzeCoin");
            bool isSilver = collision.gameObject.name.Contains("SilverCoin");
            bool isGold = collision.gameObject.name.Contains("GoldCoin");

            if (isHealthPill)
            {
                if (gameManager.health < 3)
                {
                    itemText.text = "HealthUp";
                    gameManager.DrawPlayerHealth(++gameManager.health);
                }
                itemText.text = "point +70";
                gameManager.totalPoint += 70;
            }
            else if (isInvincibilityPill)
            {
                itemText.text = "Immortar";
                sprite.color = new Color(0.4f, 0.4f, 0.4f, 0.4f);
                gameObject.layer = 8;
                Invoke("CanDamaged", 1.5f);
            }
            else if (isBronze)
            {
                itemText.text = "point +50";
                gameManager.totalPoint += 50;
            }
            else if (isSilver)
            {
                itemText.text = "point +100";
                gameManager.totalPoint += 100;
            }
            else if (isGold)
            {
                itemText.text = "point +150";
                gameManager.totalPoint += 150;
            }
            itemText.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
        }
    }

    void DeAcitveTextMesh()
    {
        itemText.gameObject.SetActive(false);
    }

    void OnHit()
    {
        gameManager.HealthDown();
        gameObject.layer = 8;
        gameObject.SetActive(false);

        if (gameManager.health >= 0)
        {
            Invoke("OnRespawn", 1f);
        }
    }

    void OnRespawn()
    {
        sprite.color = new Color(1, 1, 1, 0.5f);
        transform.position = playerPos;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
        Invoke("CanDamaged", 1.5f);
    }

    void CanDamaged()
    {
        gameObject.layer = 9;
        sprite.color = new Color(1, 1, 1, 1);
    }
}
