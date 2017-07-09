using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fractal : MonoBehaviour {
    public Mesh mesh;
    public float childScale;
    public Material material;
    public int maxDepth;
    private int depth;
    private Material[] materials;
	private float timeLeft = 20.0f; //timer = 20s
	private bool stop = false;
	public static int Frames = 0;
	public float maxRotationSpeed;
	private float rotationSpeed;

    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1];
        for (int i = 0; i <= maxDepth; i++)
        {
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i] = new Material(material);
			materials[i].color = Color.Lerp(material.color, Color.red, (float)i / maxDepth);
        }
        //materials[maxDepth].color = Color.magenta;
    }
    // Use this for initialization
    void Start () {
		Frames = Time.frameCount;
		rotationSpeed = Random.Range (-maxRotationSpeed, maxRotationSpeed);
        if (materials == null)
        {
            InitializeMaterials();
        }
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth];
        if (depth < maxDepth)
        {
			StartCoroutine(CreateChildren());
        }
    }

    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back,
		Vector3.down
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f),
		Quaternion.Euler(-90f,0f,-90f)
    };

    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);
            new GameObject("Fractal Child").AddComponent<Fractal>().
                Initialize(this, i);
        }
    }
    private void Initialize(Fractal parent, int childIndex)
    {
        mesh = parent.mesh;
        materials = parent.materials;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
		maxRotationSpeed = parent.maxRotationSpeed;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        //transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }

    // Update is called once per frame
    void Update () {
		//FractalFrames++;
		transform.Rotate(0f,rotationSpeed*Time.deltaTime, 0f);
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0)
		{
			StopCoroutine ("CreateChildren");
			stop = true;
		}
		if (stop)
			SceneManager.LoadScene("Proton");
	}
}