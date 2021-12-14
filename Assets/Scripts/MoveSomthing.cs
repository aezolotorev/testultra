using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSomthing : MonoBehaviour
{
    public float globalspeed;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, globalspeed * Time.deltaTime, 0);
    }
}
