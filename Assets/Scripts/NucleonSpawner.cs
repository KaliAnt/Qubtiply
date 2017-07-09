using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NucleonSpawner : MonoBehaviour {
    public float timeBetweenSpawns;
    public float spawnDistance;
    public Nucleon[] nucleonPrefabs;
    float timeSinceLastSpawn;
	float timeLeft = 30.0f;
	bool stop = false;
	public static int Frames = 0;

	void Strat() {
		Frames = Time.frameCount;
	}

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			StopCoroutine ("CreateChildren");
			stop = true;
		}
		if(stop) 
			SceneManager.LoadScene("Pool");
	}

    void SpawnNucleon()
    {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }
}
