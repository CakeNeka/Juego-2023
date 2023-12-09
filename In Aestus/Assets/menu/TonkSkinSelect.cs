using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TonkSkinSelect : MonoBehaviour
{
    [SerializeField]
    private List<TonkSkin> tonkSkins;

    [System.Serializable]
    public class TonkSkin {
        public Sprite tankSprite;
        public Sprite turretSprite;
        public string color;
    }

    [SerializeField]
    private Image tankImage;
    [SerializeField]
    private Image turretImage;

    private int index = 0;

    private void Start()
    {
        index = tonkSkins.IndexOf(tonkSkins.Where(s => s.color == PlayerAnimation.selectedTankColor).FirstOrDefault());
        index = index < 0 ? 0 : index;
        UpdateSprites();
    }

    public void NextSprite()
    {
        index++;
        if (index >= tonkSkins.Count) {
            index = 0;
        }

     // index = ++index >= tonkSkins.Count ? 0 : index;
        UpdateSprites();
    }

    public void PrevSprite()
    {
        index--;
        if (index < 0) {
            index = tonkSkins.Count - 1;
        }
        // index = --index < 0 ? tonkSkins.Count - 1 : index;
        UpdateSprites();
    }

    private void UpdateSprites() {
        tankImage.sprite = tonkSkins[index].tankSprite;
        turretImage.sprite = tonkSkins[index].turretSprite;
        PlayerAnimation.selectedTankColor = tonkSkins[index].color;
    }
}
