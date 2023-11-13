using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyHealthSystem : HealthSystem {
    protected override void Die() {
        Destroy(gameObject);
    }
}
