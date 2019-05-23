using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fire() を呼ばれたら指定された方向に発射する
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    /// <summary>発射する方向</summary>
    [SerializeField] Vector3 m_fireDirection = Vector3.up;
    /// <summary>発射する力/summary>
    [SerializeField] float m_firePower = 1f;
    Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    /// <summary>発射する</summary>
    public void Fire()
    {
        m_rb.AddForce(m_fireDirection.normalized * m_firePower, ForceMode.Impulse);
    }

    /// <summary>発射する</summary>
    public void Fire(float firePower)
    {
        m_rb.AddForce(m_fireDirection.normalized * firePower, ForceMode.Impulse);
    }

    /// <summary>発射する</summary>
    public void Fire(Vector3 fireDirection)
    {
        m_rb.AddForce(fireDirection.normalized * m_firePower, ForceMode.Impulse);
    }

    /// <summary>発射する</summary>
    public void Fire(Vector3 fireDirection, float firePower)
    {
        m_rb.AddForce(fireDirection.normalized * firePower, ForceMode.Impulse);
    }

    /// <summary>発射する</summary>
    public void Fire(float firePower, float dummy)
    {
        m_rb.AddForce(m_fireDirection.normalized * firePower, ForceMode.Impulse);
    }

    /// <summary>発射する</summary>
    public void Fire(Rigidbody rb)
    {
        rb.AddForce(m_fireDirection.normalized * m_firePower, ForceMode.Impulse);
    }
}
