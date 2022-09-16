﻿using Reflex;
using UnityEngine;
using Reflex.Scripts.Attributes;

public class Collectable : MonoBehaviour
{
    [field: SerializeField] private string _id;

    [Inject] private readonly Container _container;
    [Inject] private readonly ICollectableRegistry _collectableRegistry;
    [Inject] private readonly PickupSoundEffect _pickupSoundEffect;

    private void Start()
    {
        if (_collectableRegistry.Contains(_id))
        {
            Disable();
        }
    }

    [ContextMenu("SolveSomething")]
    private void SolveSomething()
    {
        _container.Resolve<PickupSoundEffect>();
    }

    private void OnMouseDown()
    {
        Collect();
    }

    public void Collect()
    {
        Disable();
        Instantiate(_pickupSoundEffect);
        _collectableRegistry.Register(_id);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}