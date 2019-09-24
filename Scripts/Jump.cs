using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public class Jump : MonoBehaviour
{
    public float speed = 700f;

    private Rigidbody2D rb2;
    private Ray mouseRay;
    private RaycastHit2D rayhit;

    private float center,radius;
    private readonly float UNIT = 1;
    private readonly float RAD_MAX = 60* Deg2Rad; //與垂直軸限制在60度徑度角
    private float DELTA_X_MAX;
    
    private float deltaX,deltaY;
    private Vector2 speedDir;

    private bool isClicked = false;


    private void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        radius = transform.localScale.x * UNIT / 2;
        DELTA_X_MAX = radius * Sin(RAD_MAX);
    }


    private void OnMouseDown()
    {
        isClicked = true;       
    }

    private void FixedUpdate()
    {
        if (isClicked)
        {
            UpdateTargetPos();
            CaculateForceUnitDir();
            rb2.velocity = speedDir * speed * Time.deltaTime;
            isClicked = false;
        }
    }


    private void UpdateTargetPos()
    {
        center = transform.position.x;
    }

    // 計算單位施力方向
    private void CaculateForceUnitDir()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //rayhit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, 10,-1);
        deltaX = Clamp(mouseRay.origin.x - center, -DELTA_X_MAX, DELTA_X_MAX);
        deltaY = Mathf.Sqrt(radius * radius - deltaX * deltaX);
        speedDir = new Vector2(-deltaX, deltaY) / radius;
    }
}
