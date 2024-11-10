using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCube : MonoBehaviour
{
    [SerializeField] int moveSpeed = 10;
    [SerializeField] float speedJump = 10;

   public float zValue;
      public    float xValue;

    public  Rigidbody2D rb;


    public SpriteRenderer sr;
    public Transform trans; 

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
     rb =   GetComponent<Rigidbody2D>();
    trans=     GetComponent<Transform>();


    }

    
    void Update()
    {

        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;


        transform.Translate(xValue, speedJump, zValue);

    }
}
