using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyHealthSystem : HealthSystem {


    public EnemySpawner Spawner { get; set; }

    protected override void Die() {
        Debug.Assert(Spawner != null);
        Spawner.ActiveEnemies--;

        SoundManager.PlaySound(SoundManager.Sound.EnemyDie);
        Destroy(gameObject);
    }

    protected override void OnDamageReceived() {
        SoundManager.PlaySound(SoundManager.Sound.EnemyHit);
    }
}
