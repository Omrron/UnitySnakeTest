using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private Dictionary<KeyCode, Vector3> m_DirectionResolver;
    private Vector3 m_Direction;

    public float Speed = 25;
    public Rigidbody2D Rigidbody;

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
        Rigidbody.velocity = direction * Speed;
    }
}
