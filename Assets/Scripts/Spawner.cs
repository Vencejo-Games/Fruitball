using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemies;

    [SerializeField]
    private float spawnTimeDelay, startSpawnDelay;
    public bool completed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // spawning enemies on a delay
    // Use Moev to move in a certain direction
    // check to see if spawning complete
    private IEnumerator Spawn()
    {
        // statement
        yield return new WaitForSeconds(startSpawnDelay);
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemyInstance = Instantiate(enemies[i], transform.position, Quaternion.identity);
            enemyInstance.Move(transform.right);
            completed = i >= enemies.Length - 1;
            yield return new WaitForSeconds(spawnTimeDelay);
        }
    }

}
