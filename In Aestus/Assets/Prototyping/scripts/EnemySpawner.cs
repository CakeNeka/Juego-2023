using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Move to scriptable object, gamemanager change params as game progresses

    public List<GameObject> enemies;
    public float spawnRate = 1f;
    public int maxEnemies = 5;

    public int ActiveEnemies { get; set; }

    private Coroutine spawningCoroutine;

    private void Start() {
        spawningCoroutine = StartCoroutine(SpawnRepeating());
    }

    IEnumerator SpawnRepeating() {
        yield return new WaitForSeconds(spawnRate);
        while(true) {
            if (ActiveEnemies < maxEnemies) {
                // TODO Set enemies' spawning area
                GameObject newEnemy = Instantiate(RandomEnemy(), transform.position, transform.rotation);
                ActiveEnemies++;
                // EnemyHealthSystem resta uno a activeEnemies cuando el enemigo muere.
                newEnemy.GetComponent<BaseEnemyHealthSystem>().Spawner = this;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    // Debug
    float t = 0;
    private void Update() {
        t += Time.deltaTime;
        if (t >= 2) {
            Debug.Log(FindObjectsOfType<EnemyController>().Length + " " + ActiveEnemies);
        }
    }
    //

    private GameObject RandomEnemy() {
        return enemies[Random.Range(0, enemies.Count)];
    }

    private void ClearEnemies() {

    }
}
