using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    public AudioClip powerupClip;
    public enum PotionType
    {
        Speed,
        Jump
    }

    public PotionType potionType;
    public int potionModAmount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            if(potionType == PotionType.Jump)
            {
                AudioSource.PlayClipAtPoint(powerupClip, transform.position);
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
            }
            else if (potionType == PotionType.Speed)
            {
                AudioSource.PlayClipAtPoint(powerupClip, transform.position);
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
            }
            collision.gameObject.GetComponent<PlayerMovement>().potionModAmount = potionModAmount;

            Destroy(this.gameObject);
        }
    }
}
