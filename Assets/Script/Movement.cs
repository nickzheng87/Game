using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    

    public Rigidbody2D rb;
    public Camera cam;
    Vector2 position;
    Vector2 mousePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

         position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



    }


    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
