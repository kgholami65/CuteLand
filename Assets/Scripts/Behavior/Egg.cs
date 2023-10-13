using DefaultNamespace;
using UnityEngine;

public class Egg : MonoBehaviour, ICollectable
{
    public void Consume()
    {
        Destroy(gameObject);
    }
    
}
