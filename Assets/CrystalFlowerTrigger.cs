using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrystalFlower
{
    Shield,
    Health,
    Light,
    Ghost,
    Deactivation
}
public class CrystalFlowerTrigger : MonoBehaviour
{
    public CrystalFlower crystalFlower;
    public int healAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("on");
            if(crystalFlower == CrystalFlower.Shield)
            {
                collision.GetComponent<ShieldController>().TurnOn();
            }else if (crystalFlower == CrystalFlower.Health)
            {
                collision.GetComponent<PlayerHealth>().Heal(healAmount);
            } else if (crystalFlower == CrystalFlower.Light)
            {

            } else if (crystalFlower == CrystalFlower.Ghost)
            {
                collision.GetComponent<GhostMode>().TurnOn();
            } else if (crystalFlower == CrystalFlower.Deactivation)
            {
                List<GameObject> firestars = GetComponent<FireStarList>().fireStars;
                foreach(GameObject firestar in firestars)
                {
                    firestar.GetComponent<FireStar>().Deactivate();
                }
            }
        }
    }
}
