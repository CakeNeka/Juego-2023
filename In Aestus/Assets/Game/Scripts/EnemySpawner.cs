using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawner : MonoBehaviour
{
    // Move to scriptable object, gamemanager change params as game progresses

    public List<GameObject> enemies;
    public Transform[] spawnPoints;
    public float spawnRate = 1f;
    public int maxEnemies = 5;

    public int ActiveEnemies { get; set; }

    private Coroutine spawningCoroutine;

    private void Start() {
        spawningCoroutine = StartCoroutine(SpawnRepeating());
    }

    private Vector3 offset = Vector3.zero;
    private void generateSpawnPoints() {
        spawnPoints = new Transform[8];
        int i = 0;

        for (float x = 0; x <= 1; x += .5f) {
            for (float y = 0; y <= 1; y += .5f) {
                if (y == .5f && x == .5f) // avoids creating spawnpoint in center
                    continue;

                Vector3 viewportPosition = new Vector3(x, y, 0);
                Vector3 worldPosition = Camera.main.ViewportToWorldPoint(viewportPosition) + offset;
                worldPosition.z = 0; // Working on 2D, ignore Z component
                spawnPoints[i] = new GameObject("Spawn point " + i).transform;
                spawnPoints[i].position = worldPosition;

                spawnPoints[i].SetParent(GameManager.Instance.PlayerTransform);
                i++;
            }
        }

    }

    IEnumerator SpawnRepeating() {
        yield return new WaitForSeconds(spawnRate);
        generateSpawnPoints();
        while(true) {
            if (ActiveEnemies < maxEnemies) {
                // TODO Set enemies' spawning area
                GameObject newEnemy = Instantiate(GetRandomEnemy(), GetSpawnPosition(), Quaternion.identity);
                ActiveEnemies++;
                // EnemyHealthSystem resta uno a activeEnemies cuando el enemigo muere.
                newEnemy.GetComponent<BaseEnemyHealthSystem>().Spawner = this;
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private GameObject GetRandomEnemy() {
        return enemies[Random.Range(0, enemies.Count)];
    }

    private Vector3 GetSpawnPosition() {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
