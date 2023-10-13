using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int health;
    public abstract void TakeDamage(int damage);
}
