using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    Vector2 targetPos;

    Rigidbody2D rigid;
    Transform target;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Ground>().transform;

        targetPos = target.position - transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        rigid.velocity = targetPos.normalized * moveSpeed;
    }
}
