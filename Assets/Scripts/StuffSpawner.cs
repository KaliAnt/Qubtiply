using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct FloatRange
{
    public float min, max;

    public float RandomInRange
    {
        get
        {
            return Random.Range(min, max);
        }
    }
}
public class StuffSpawner : MonoBehaviour
{

   // public float timeBetweenSpawns;
	bool stop = false;
	float timeLeft = 10.0f;
	public static int Frames = 0;
    public Stuff[] stuffPrefabs;

    float timeSinceLastSpawn;

    public FloatRange timeBetweenSpawns,scale, randomVelocity,angularVelocity;

    float currentSpawnDelay;

    public float velocity;

    public Material stuffMaterial;

    void SpawnStuff()
    {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = Instantiate<Stuff>(prefab);

        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;
        spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
    }
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

	void Start() {
		Frames = Time.frameCount;
	}

	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			StopAllCoroutines();
			stop = true;
		}
		if(stop) 
			SceneManager.LoadScene("Score");
	}
}