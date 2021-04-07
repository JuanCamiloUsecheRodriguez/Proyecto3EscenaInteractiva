using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class AIObject
{
    public string AIGroupName { get { return m_aiGroupName; } }
    public GameObject objectPrefab { get { return m_prefab; } }
    public int maxAI { get { return m_maxAI; } }


    [Header("AI Group Stats")]
    [SerializeField]
    private string m_aiGroupName;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    [Range(0f,20f)]
    private int m_maxAI;

}
public class AISpawner : MonoBehaviour {

    public List<Transform> Waypoints = new List<Transform>();
    [Header("AI Groups Settings")]
    public AIObject[] AIObject = new AIObject[6];
    public Vector3 spawnArea { get { return m_spawnArea; } }

    [SerializeField]
    private Vector3 m_spawnArea = new Vector3(20f,10f,20f);

    // Use this for initialization
    void Start () {
        GetWayPoints();
	}

    void GetWayPoints() {
        Transform[] wplist = this.transform.GetComponentsInChildren<Transform>();
        for(int i=0; i < wplist.Length; i++)
        {
            if(wplist[i].tag == "waypoint")
            {
                Waypoints.Add(wplist[i]);
            }
        }
     }

    public Vector3 RandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z));
        randomPosition = transform.TransformPoint(randomPosition * .5f);
        return randomPosition;
    } 


    void CreateAIObject(int i)
    {
        Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
        GameObject newObject = Instantiate(AIObject[i].objectPrefab, RandomPosition(), randomRotation);
        newObject.transform.parent = this.transform;
        newObject.AddComponent<AIMove>();
    }

    public Vector3 RandomWayPoint()
    {
        int randomWP = Random.Range(0, (Waypoints.Count - 1));
        Vector3 randomWayPoint = Waypoints[randomWP].transform.position;
        return randomWayPoint;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            CreateAIObject(0);
        }
	}
    public void CreateAIObject0()
    {
        CreateAIObject(0);
    }
    public void CreateAIObject1()
    {
        CreateAIObject(1);
    }
    public void CreateAIObject2()
    {
        CreateAIObject(2);
    }
    public void CreateAIObject3()
    {
        CreateAIObject(3);
    }
    public void CreateAIObject4()
    {
        CreateAIObject(4);
    }
    public void CreateAIObject5()
    {
        CreateAIObject(5);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, spawnArea);
    }
}
