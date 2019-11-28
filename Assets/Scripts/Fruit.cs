using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fruit : MonoBehaviour
{
    [SerializeField] public Sprite fruitSprite;

    [SerializeField] public AnimationClip idleAnimationClip;
    [SerializeField] public AnimationClip walkAnimationClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                PlatformerCharacter2D player = collision.gameObject.GetComponent<PlatformerCharacter2D>();
                PowerUp(player);
                Destroy(this.gameObject);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }

    public abstract void PowerUp(PlatformerCharacter2D player);

}
