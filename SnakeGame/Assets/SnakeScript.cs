using System;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private Dictionary<KeyCode, Vector3> m_DirectionResolver;
    private float m_Speed = 25;
    private Vector3 m_Direction;

    // Start is called before the first frame update
    void Start()
    {
        m_DirectionResolver = new Dictionary<KeyCode, Vector3>()
        {
            {KeyCode.A, Vector3.left },
            {KeyCode.W, Vector3.up },
            {KeyCode.S, Vector3.down },
            {KeyCode.D, Vector3.right }
        };
        m_Direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in m_DirectionResolver.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                m_Direction = m_DirectionResolver[key];
            }
        }

        Move(m_Direction);
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * m_Speed * Time.deltaTime);
    }
}
