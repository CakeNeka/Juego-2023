using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem {
    protected override void Die() {
        GameManager.Instance.GameOver();
    }
}
