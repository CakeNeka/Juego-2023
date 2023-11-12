using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsManager : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("exit");
        IOutOfBoundsRemover outOfBoundsObject;
        if (other.gameObject.TryGetComponent(out outOfBoundsObject)) {
            outOfBoundsObject.DestroyOutOfBounds();
        }
    }
}
