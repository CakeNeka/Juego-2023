using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsDeactivator : MonoBehaviour, IOutOfBoundsRemover 
{
    public void DestroyOutOfBounds() {
        gameObject.SetActive(false);
    }
}
