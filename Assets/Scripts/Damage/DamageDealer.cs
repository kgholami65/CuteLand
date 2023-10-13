using UnityEngine;

public abstract class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    public abstract void Hit();


    public int GetDamage()
    {
        return damage;
    }
}
