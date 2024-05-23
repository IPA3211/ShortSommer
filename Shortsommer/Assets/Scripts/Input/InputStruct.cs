using System;
using UnityEngine;

//지금 Player 가 키보드로 누르고 있는 것들

[Serializable]
public struct InputStruct
{
    [SerializeField] internal Vector2 m_MoveDir;
    [SerializeField] internal Vector3 m_AimDir;
    [SerializeField] internal bool m_Jump;
    [SerializeField] internal bool m_Sprint;
    [SerializeField] internal bool m_Interact;
    [SerializeField] internal bool m_fire;

    public Vector2 MoveDir => m_MoveDir;
    public Vector3 AimDir => m_AimDir;
    public bool Jump => m_Jump;
    public bool Sprint => m_Sprint;
    public bool Interact => m_Interact;
    public bool Fire => m_fire;
}
