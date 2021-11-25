using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLips : MonoBehaviour
{
   public GameObject spawnedPrefab;
    public Transform Parent;
    public GameObject explosion;
    //public BoxCollider spawnArea;
    //Vector3 maxSpawnPos;
    //Vector3 m_Min, m_Max;
    private void Start()
    {
        //spawnArea = GetComponent<BoxCollider>();
        //m_Min = spawnArea.bounds.min;
        //m_Max = spawnArea.bounds.max;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag =="Friend")
        {
            explosion.SetActive(true);
            other.gameObject.name = "Hitedobject";
            Destroy(other.gameObject);

            //TO check Later
            //GameObject spawned = Instantiate(spawnedPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            
            //spawned.transform.parent = Parent;
            //Vector3 pos = new Vector3(Random.Range(m_Min.x, m_Max.x), Random.Range(m_Min.y, m_Max.y), Random.Range(m_Min.z, m_Max.z));
            //spawned.transform.localPosition = pos;

        }
    }
}
