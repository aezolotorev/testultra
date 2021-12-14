using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EndPlatform : MonoBehaviour
{
    public delegate void GameISOverBrothers();
    public event GameISOverBrothers gameisover;
    public enum Type
    {
        End, Start,
    }
    public Type type;
    public PlatformManager platformManager;
    private bool canbuild=true;
    



    /*private void Start()
    {
        if(type == Type.Start)
        transform.position = new Vector3(transform.position.x, platformManager.SetStartposition(), transform.position.z);
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("Platform"))
        {
            if (type == Type.End)
            {
                platformManager.DeletePlatform(collision.gameObject);
                StartCoroutine(Can());
            }
            if (type == Type.Start)
            {
                Platform platform = collision.gameObject.GetComponent<Platform>();
                if (platform!=null&&platform.isFirstColl())
                {
                    StartCoroutine(Can());
                    platformManager.GetPlatform(platformManager.SetPosition(collision.gameObject.transform.position));
                }
            }

        }
        if (collision.CompareTag("Player"))
        {
            if (type == Type.End)
            {
                gameisover?.Invoke();
            }         

        }

    }

    IEnumerator Can()
    {
        canbuild = false;
        yield return new WaitForSeconds(0.5f);
        canbuild = true;

    }
    


}
