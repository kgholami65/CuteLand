using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "new Inventory")]
public class InventorySO : ScriptableObject
{
    private List<ICollectable> _collectables;

    public InventorySO()
    {
        _collectables = new List<ICollectable>();
    }

    public List<ICollectable> GetCollectables()
    {
        return _collectables;
    }

    public void Add(ICollectable collectable)
    {
        _collectables.Add(collectable);
    }

    public void Remove(ICollectable collectable)
    {
        if (_collectables.Contains(collectable))
            _collectables.Remove(collectable);
        else
            throw new Exception();
    }
}
