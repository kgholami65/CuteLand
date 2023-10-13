using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int value;

    public void Consume()
    {
        Destroy(gameObject);
    }

    public int GetValue()
    {
        return value;
    }

}
