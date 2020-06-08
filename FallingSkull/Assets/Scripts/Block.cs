using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite[] blockSprite;

    float randomScale;
    float rotateSpeed;
    float moveSpeed;

    SpriteRenderer sprite;
    Rigidbody2D rigid;
    Transform target;
    Vector2 targetPos;

    void Start()
    {
        target = FindObjectOfType<Ground>().transform;
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        targetPos = target.position - transform.position;

        ChooseSprite();
        MakeBlock();
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
    }

    void MakeBlock()
    {
        moveSpeed = Random.Range(1, 3);
        rotateSpeed = Random.Range(0, 180);
        randomScale = Random.Range(0.05f, 0.25f);
        transform.localScale = new Vector3(randomScale, randomScale, transform.localScale.z);

        rigid.velocity = targetPos.normalized * moveSpeed;
    }

    void ChooseSprite()
    {
        int randomSprite = Random.Range(0, blockSprite.Length);
        sprite.sprite = blockSprite[randomSprite];
    }
}
