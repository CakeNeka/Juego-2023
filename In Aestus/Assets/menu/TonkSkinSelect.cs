using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TonkSkinSelect : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> tonkSkins;
    [SerializeField]
    private Image image;

    private int index = 0;

    private void Start()
    {
        image.sprite = tonkSkins[0];
    }

    public void NextSprite()
    {
        if (++index >= tonkSkins.Count)
        {
            index = 0;
        }
        image.sprite = tonkSkins[index];
    }

    public void PrevSprite()
    {
        if (--index <= 0)
        {
            index = tonkSkins.Count - 1;
        }
        image.sprite = tonkSkins[index];
    }
}
