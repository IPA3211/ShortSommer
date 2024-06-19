using System;
using UnityEngine;

[Serializable]
public class CharacterStatus
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] int maxHp;
    [SerializeField] float maxSpeed = 10;

    public string Name => name;
    public string Description => description;
    public float MaxHp => maxHp;
    public float MaxSpeed => maxSpeed;
}