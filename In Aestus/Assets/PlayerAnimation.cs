using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [System.Serializable]
    class SpriteAnimation {
        [SerializeField]
        private string color;
        [SerializeField]
        private Sprite[] tankSprites;
        [SerializeField]
        private Sprite turretSprite;
        public string Color => color;
        public Sprite[] TankSprites => tankSprites;
        public Sprite TurretSprite => turretSprite;
    }

    [SerializeField]
    private SpriteAnimation[] animations;
    [SerializeField]
    private SpriteRenderer tankRenderer;
    [SerializeField]
    private SpriteRenderer turretRenderer;
    [SerializeField]
    private float frameInterval = .33f;

    private int currentFrame = 0;
    private Sprite[] selectedSprites;
    private PlayerMovement playerMovement; // we need this to check whether the player is moving
    private Coroutine animationCoroutine;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void SetAnimationColor(string color) {
        SpriteAnimation s = animations.Where(s => s.Color.Equals(color)).FirstOrDefault();
        if (s == null) {
            Debug.LogError("Color " + color + " is not defined");
        }

        selectedSprites = s.TankSprites;
        tankRenderer.sprite = selectedSprites[0];
        turretRenderer.sprite = s.TurretSprite;

    }

    public void StartAnimation() {
        if (animationCoroutine == null) {
            animationCoroutine = StartCoroutine(AnimatePlayer());
        }
    }

    IEnumerator AnimatePlayer() {
        while (true) {
            if (playerMovement.IsMoving) {
                currentFrame = ++currentFrame >= selectedSprites.Length ? 0 : currentFrame;
                tankRenderer.sprite = selectedSprites[currentFrame];
            }
            yield return new WaitForSeconds(frameInterval);
        }
    }

    private void Start() {
        // Debugging:
        SetAnimationColor("green");
        StartAnimation();

        StartCoroutine(ChangeColorRepeating());
    }

    IEnumerator ChangeColorRepeating() {
        while (true) {
            foreach (var anim in animations) {
                SetAnimationColor(anim.Color);
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
