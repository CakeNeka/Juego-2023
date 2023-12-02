using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyHealthSystem : HealthSystem {


    public EnemySpawner Spawner { get; set; }

    protected override void Die() {
        Debug.Assert(Spawner != null);
        if (Spawner)
            Spawner.ActiveEnemies--;
        Destroy(gameObject);
    }
}
