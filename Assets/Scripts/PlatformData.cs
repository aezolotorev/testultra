using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Platform/properties")]
public class PlatformData : ScriptableObject
{
    [Range(0, 1)]
    public float _moveSpeed;    
    public bool _isMoving;
    public bool _isDestroeble;
    public bool _isHided;
    
}
