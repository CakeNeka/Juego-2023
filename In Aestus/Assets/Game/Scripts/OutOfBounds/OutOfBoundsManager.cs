using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OutOfBoundsManager : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        IOutOfBoundsRemover outOfBoundsObject;
        if (other.gameObject.TryGetComponent(out outOfBoundsObject)) {
            outOfBoundsObject.DestroyOutOfBounds();
        }
    }
}
