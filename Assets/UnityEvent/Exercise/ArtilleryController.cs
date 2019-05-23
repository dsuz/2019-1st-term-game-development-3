using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ArtilleryController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    Rigidbody2D m_rb;
    [SerializeField] Transform m_muzzle;
    [SerializeField] GameObject m_shellPrefab;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        m_rb.velocity = h * Vector2.right * m_speed;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_shellPrefab, m_muzzle.position, Quaternion.identity);
        }
    }
}
