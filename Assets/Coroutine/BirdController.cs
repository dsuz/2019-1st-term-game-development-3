using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 指定された interval で、ランダムに４方向に動く
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BirdController : MonoBehaviour
{
    /// <summary>タイマー</summary>
    float m_timer = 0f;
    Rigidbody2D m_rb;
    /// <summary>動きを切り替える間隔</summary>
    [SerializeField] float m_intervalSeconds = 1f;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer > m_intervalSeconds)
        {
            m_timer = 0;
            RandomMove();
        }
    }

    /// <summary>
    /// 指定された方向に動く
    /// </summary>
    /// <param name="v">速度ベクトル</param>
    void Move(Vector2 v)
    {
        m_rb.velocity = v;
    }

    /// <summary>
    /// ４方向のうちランダムな方向に動く
    /// </summary>
    void RandomMove()
    {
        Vector2 v = Vector2.zero;
        int r = Random.Range(0, 100);
        r = r % 4;
        switch (r)
        {
            case 0:
                v = Vector2.up;
                break;
            case 1:
                v = Vector2.down;
                break;
            case 2:
                v = Vector2.right;
                break;
            case 3:
                v = Vector2.left;
                break;
            default:
                break;
        }
        Move(v);
    }
}
