using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// uGUI の EventTrigger から呼び出されて Rigidbody2D を上下左右に動かすクラス
/// Rigidbody2D と同じオブジェクトにアタッチして使う
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerUi : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float m_speed = 1f;
    /// <summary>水平方向の入力</summary>
    float m_horizontal;
    /// <summary>垂直方向の入力</summary>
    float m_vertical;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力値から速度ベクトルを生成し、velocity としてセットする
        Vector2 v = m_horizontal * Vector2.right + m_vertical * Vector2.up;
        v = v.normalized * m_speed;
        m_rb.velocity = v;
    }

    /// <summary>
    /// 水平方向の入力を行う
    /// </summary>
    /// <param name="value">正の場合は右、負の場合は左</param>
    public void Horizontal(float value)
    {
        m_horizontal = value;

        if (m_horizontal > 0)
            Debug.Log("Right");
        else if (m_horizontal < 0)
            Debug.Log("Left");
    }

    /// <summary>
    /// 垂直方向の入力を行う
    /// </summary>
    /// <param name="value">正の場合は上、負の場合は下</param>
    public void Vertical(float value)
    {
        m_vertical = value;

        if (m_vertical > 0)
            Debug.Log("Up");
        else if (m_vertical < 0)
            Debug.Log("Down");
    }
}
