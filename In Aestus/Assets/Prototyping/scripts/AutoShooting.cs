using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    [SerializeField]
    private ObjectPooler pooler;
    [SerializeField]
    private Transform firepoint;
    [SerializeField]
    private GameObject bulletPrefab;

    public float ShootDelay { get; set; } 

    private Coroutine shootingCoroutine;

    private void Start() {
        Debug.Log(pooler);
        shootingCoroutine = StartCoroutine(ShootRepeating());
    }

    IEnumerator ShootRepeating() {
        yield return new WaitForSeconds(ShootDelay);
        while (true) {
            GameObject bullet = pooler.GetObject();
            bullet.SetActive(false);
            bullet.transform.position = firepoint.transform.position;
            bullet.transform.rotation = firepoint.transform.rotation;
            bullet.SetActive(true);
            yield return new WaitForSeconds(ShootDelay);
        }
    }
}
