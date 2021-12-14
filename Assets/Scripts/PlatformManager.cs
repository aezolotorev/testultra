using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] List<PlatformData> platformDatas;
    [SerializeField] List<GameObject> prefabs;
    [SerializeField] List<GameObject> platformsInScreen;
    [SerializeField] float globalspeed;
    [SerializeField] private int startsize;
    [SerializeField] float step;
    [SerializeField] float offset;
    [SerializeField] Collider2D endLevel;

    void Awake()
    {       
        if (startsize == 0) startsize = 5;
        if (step == 0) step = 2f;
        if (offset == 0) offset = 4f; 
        StartInit();
        SetStartposition();
    }

    public float SetStartposition()
    {
        return step * (float)(startsize-1);
    }

    private void StartInit()
    {
        for (int i = 0; i < startsize; i++)
            GetPlatform(new Vector3(Random.Range(-offset, offset), step*i, transform.position.z));
    }

    public Vector3 SetPosition(Vector3 v)
    {
        return new Vector3(Random.Range(-offset, offset), v.y + step, v.z);
    }
  


    public void GetPlatform(Vector3 plTransform)
    {
        GameObject currentPlattform = Instantiate(prefabs[Random.Range(0, prefabs.Count)] as GameObject, plTransform, Quaternion.identity);
        currentPlattform.transform.SetParent(transform);
        Platform platformCurrent = currentPlattform.AddComponent<Platform>();
        platformCurrent.platform = platformDatas[Random.Range(0, platformDatas.Count)];
        platformsInScreen.Add(currentPlattform);        
    }

    public void DeletePlatform(GameObject p)
    {
        platformsInScreen.Remove(p);
        Destroy(p);
        //GetPlatform(new Vector3(Random.Range(-offset, offset), p.transform.position.y + step * startsize, transform.position.z));
    }



    
   

    void GameOver()
    {

    }

}
