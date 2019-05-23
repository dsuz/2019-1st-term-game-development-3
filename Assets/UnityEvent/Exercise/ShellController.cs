using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShellController : MonoBehaviour
{
    [SerializeField] Vector2 m_direction = Vector2.up;
    [SerializeField] float m_power = 1f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.AddForce(m_direction.normalized * m_power, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
