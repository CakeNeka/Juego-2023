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

    public float ShootDelay { get; set; } 

    private Coroutine shootingCoroutine;

    private void Start() {
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
            SoundManager.PlaySound(SoundManager.Sound.PlayerAttack);
            yield return new WaitForSeconds(ShootDelay);
        }
    }
}
