using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Transform[] spawnPoints;

    public GameObject completeUI;
    public Text CountDownUI;

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public string levelToLoad;

    void Start ()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.Log("No SpawnPoints");
        }
        StartCoroutine(ShowCompleteWaveUI());
        waveCountdown = timeBetweenWaves;
	}
	

	void Update ()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
            CountDownUI.text = ("" + Mathf.Round(waveCountdown));
        }
	}

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            //Load next Level after Complete(Loops for now); 
            //SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            StartCoroutine(ShowCompleteWaveUI());
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i =0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f/ _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }
    IEnumerator ShowCompleteWaveUI()
    {
        completeUI.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        completeUI.SetActive(false);
    }
    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
