using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiPeSpawn : MonoBehaviour {

    [SerializeField]
    public Object pipeSpawn;


    void Start()
    {

        StartCoroutine(_Spawner());
    }

    IEnumerator _Spawner()
    {
        Vector3 ranSpawn = transform.position;
        ranSpawn.y = Random.Range(0.5f, 2f);



        yield return new WaitForSeconds(1);
        Instantiate(pipeSpawn, ranSpawn, Quaternion.identity);
        StartCoroutine(_Spawner());
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag==("CheckZone"))
    //    {
    //        Debug.Log("va cham");

    //    }
    //}
  
        
    



}
