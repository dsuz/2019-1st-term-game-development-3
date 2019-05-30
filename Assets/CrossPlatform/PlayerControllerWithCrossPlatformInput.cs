using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;   // CrossPlatformInput を使うために必要です

/// <summary>
/// CrossPlatformInput を使って Rigidbody2D を動かすコンポーネント
/// Rigidbody2D と同じオブジェクトにアタッチして使う
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerWithCrossPlatformInput : MonoBehaviour
{
    [SerializeField] float m_speed = 3f;
    [SerializeField] float m_jumpPower = 3f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ジャンプ
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        // 左右に動く
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 v = Vector2.right * h * m_speed;
        m_rb.velocity = new Vector2(v.x, m_rb.velocity.y);
    }
}
