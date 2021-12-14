using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : PlatformBase
{
    private float dir;
    [SerializeField] private float current;
    [SerializeField] private float bias;
    [SerializeField] private Vector3 target1, target2;   
    [SerializeField] Animator anim;
    [SerializeField] bool firstcoll;
    BoxCollider2D box;
    PlatformEffector2D platformEffector;
    SpriteRenderer spriteRenderer;

    

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        firstcoll = true;
        anim = GetComponent<Animator>();
        bias = Random.Range(0.5f, 2);
        base.Start();
        dir = 1;
        if (isMoving)
        {            
            target1 = new Vector3(transform.localPosition.x + bias, transform.localPosition.y, transform.localPosition.z);
            target2 = new Vector3(transform.localPosition.x - bias, transform.localPosition.y, transform.localPosition.z);
        }

        if (isHided)
            anim.SetTrigger("Hide");      
        
    }

    public bool isFirstColl()
    {
        if (firstcoll)
        {
            firstcoll = false;
            return true;
        }
        else return false;
    }

    
    void Update()
    {
        if(isMoving)
        Move();   
    }





    private void Move()
    {
            current += dir * moveSpeed * Time.deltaTime;
            if (current > 1.0f)
            {
                current = 1.0f;
                dir = -1.0f;
            }
            else if (current < 0.0f)
            {                
                dir = 1.0f;
            }
            transform.localPosition = Vector3.Lerp(target1, target2, current);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (isDestroeble)
        {
            if (collision.gameObject.name == "Player")
            {
                if (anim != null)
                {
                    anim.SetTrigger("Destroy");
                    StartCoroutine(DestroyPlatform());
                }
            }
        }
    }
  

    IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(3f);
        box.isTrigger = true;
        //platformEffector.enabled = false;       
        spriteRenderer.enabled = false;
    }

    public void Hide()
    {
        GetComponent<Collider2D>().enabled = false;
    }


    public void UnHide()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
