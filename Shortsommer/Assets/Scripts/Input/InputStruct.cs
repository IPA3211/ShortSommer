using System;
using UnityEngine;

//지금 Player 가 키보드로 누르고 있는 것들

[Serializable]
public struct InputStruct
{
    [SerializeField] internal Vector2 m_MoveDir;
    [SerializeField] internal Vector3 m_AimDir;
    [SerializeField] internal Vector3 m_fireDir;
    [SerializeField] internal bool m_Jump;
    [SerializeField] internal bool m_Sprint;
    [SerializeField] internal bool m_Interact;

    public readonly Vector2 MoveDir => m_MoveDir;
    public readonly Vector3 AimDir => m_AimDir;
    public readonly Vector3 Fire => m_fireDir;
    public readonly bool Jump => m_Jump;
    public readonly bool Sprint => m_Sprint;
    public readonly bool Interact => m_Interact;
}
