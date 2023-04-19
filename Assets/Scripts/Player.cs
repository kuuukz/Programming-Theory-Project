using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator playerAnimator;

    private float speed = 5.0f;
    private bool isSitting = true;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        bool front = Input.GetKey(KeyCode.UpArrow);
        bool back = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if (front)
        {
            Rotation(0);
            Move();
        }
        if (back)
        {
            Rotation(180);
            Move();
        }
        if (left)
        {
            Rotation(-90);
            Move();
        }
        if (right)
        {
            Rotation(90);
            Move();
        }
        if (front && left)
        {
            Rotation(-45);
        }
        if (front && right)
        {
            Rotation(45);
        }
        if (back && left)
        {
            Rotation(-135);
        }
        if (back && right)
        {
            Rotation(135);
        }
        if (!front && !back && !left && !right)
        {
            playerAnimator.ResetTrigger("Sit_b");
        }

        float xRange = 9;
        float upRange = 14;
        float downRange = -2;

        if (transform.position.x > xRange)
        {
            GameBorderX(xRange);
        }
        if (transform.position.x < -xRange)
        {
            GameBorderX(-xRange);
        }
        if (transform.position.z > upRange)
        {
            GameBorderZ(upRange);
        }
        if (transform.position.z < downRange)
        {
            GameBorderZ(downRange);
        }
    }

    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        playerAnimator.SetTrigger("Sit_b");
    }

    void Rotation(int angle)
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, angle, transform.rotation.z);
    }

    void GameBorderX(float range)
    {
        transform.position = new Vector3 (range, transform.position.y, transform.position.z);
    }

    void GameBorderZ(float range)
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, range);
    }
}
