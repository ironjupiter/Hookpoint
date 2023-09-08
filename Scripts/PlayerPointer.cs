using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{

    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosistion = Input.mousePosition;
        mousePosistion = Camera.main.ScreenToWorldPoint(mousePosistion);

        Vector2 direction = new Vector2(mousePosistion.x - transform.position.x,
            mousePosistion.y - transform.position.y);
        transform.up = direction;
    }
}
