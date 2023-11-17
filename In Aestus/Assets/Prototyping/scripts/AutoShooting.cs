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
    [SerializeField]
    private float shootDelay; // TODO use PlayerStats class

    private Coroutine shootingCoroutine;

    private void Start() {
        Debug.Log(pooler);
        shootingCoroutine = StartCoroutine(ShootRepeating());
    }

    IEnumerator ShootRepeating() {
        yield return new WaitForSeconds(shootDelay);
        while (true) {
            GameObject bullet = pooler.GetObject();
            bullet.SetActive(false);
            bullet.transform.position = firepoint.transform.position;
            bullet.transform.rotation = firepoint.transform.rotation;
            bullet.SetActive(true);
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
