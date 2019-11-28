using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    private Fruit[] fruits;

    [SerializeField]
    private float spawnTimeDelay, startSpawnDelay;

    private Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {

    }

    // spawning enemies on a delay
    // Use Moev to move in a certain direction
    // check to see if spawning complete
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(startSpawnDelay);

            int fruitType = Random.Range(0, fruits.Length);

            Vector3 cameraRandomPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1, cam.nearClipPlane));
            Instantiate(fruits[fruitType], cameraRandomPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnTimeDelay);
        }
    }

}
