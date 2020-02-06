using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Camera myCam;
    private Vector3 clickPos;
    private float moveSpeed = 10;
    float step;
    private Vector2 target;
    private SpriteRenderer sr;
    [SerializeField]
    private Image fillImage;

    // Start is called before the first frame update
    void Start()
    {

        myCam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //clickPos = myCam.ScreenToWorldPoint(Input.mousePosition);

        step = moveSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            clickPos = myCam.ScreenToWorldPoint(Input.mousePosition);
           
        }
        target = clickPos;
        movePlayer();

        if(clickPos.x > transform.position.x)
        {
            sr.flipX = true;
        }
        if (clickPos.x < transform.position.x)
        {
            sr.flipX = false;
        }
        
    }


   void movePlayer()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, step);  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Comb")
        {
            
            fillImage.fillAmount += 0.1f;
            Destroy(col.gameObject,3f);
        }
    }
   
}
