using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBase : MonoBehaviour
{
    public PlatformData platform;
    [SerializeField] protected float moveSpeed; 
    [SerializeField] protected bool isMoving;
    [SerializeField] protected bool isDestroeble;
    [SerializeField] protected bool isHided;



    public void Start()
    {
        moveSpeed = platform._moveSpeed;
        isMoving= platform._isMoving;      
        isDestroeble = platform._isDestroeble;
        isHided= platform._isHided;
    }
    
}
