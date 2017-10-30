using UnityEngine;
using System.Collections;

public class randomSpawn : MonoBehaviour
{
    public GameObject[] enemyToSpawn;
    public float spawnCounter;
    public float spawnRate = 10.0f;
    public bossController boss;
    public GameObject[] possibleSpawns;

    // Use this for initialization
    void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (boss.inCol && !boss.Dead)
        {
            if (boss.phaseID == 0)
            {
                spawnRate = Random.Range(0.1f, 0.2f);
                Spawn();
            }
            else if (boss.phaseID == 1)
            {
                spawnRate = Random.Range(0.05f, 0.1f);
                Spawn();
            }
            else if (boss.phaseID == 2)
            {
                spawnRate = Random.Range(0f, 0f);
                //Spawn();
            }
        }
        spawnCounter -= Time.deltaTime * spawnRate;
    }
    void Spawn()
    {
        if (boss.inCol && spawnCounter <= 0.0f)
        {
            int i = Random.Range(0, possibleSpawns.Length);
            Instantiate(enemyToSpawn[0], possibleSpawns[i].transform.position, possibleSpawns[i].transform.rotation);
            spawnCounter = 1.0f;
        }
    }
}
