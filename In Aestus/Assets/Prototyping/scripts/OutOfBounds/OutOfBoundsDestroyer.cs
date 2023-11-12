using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDestroyer : MonoBehaviour, IOutOfBoundsRemover {
    public void DestroyOutOfBounds() {
        Destroy(gameObject);
    }
}
