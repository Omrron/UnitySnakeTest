using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeScript : MonoBehaviour
{
    private Dictionary<KeyCode, Vector2> m_DirectionResolver;
    private Vector2 m_Direction;
    private List<Transform> m_Segments;

    public float Speed = 25;
    public int InitialSize = 4;
    public Rigidbody2D Rigidbody;
    public Transform BodySegment;

    // Start is called before the first frame update
    void Start()
    {
        m_DirectionResolver = new Dictionary<KeyCode, Vector2>()
        {
            {KeyCode.A, Vector2.left },
            {KeyCode.W, Vector2.up },
            {KeyCode.S, Vector2.down },
            {KeyCode.D, Vector2.right }
        };
        m_Direction = Vector2.down;
        m_Segments = new List<Transform>() {transform };

        InvokeRepeating("Move", 0.2f, 1/Speed);

        for (int i = 0; i < InitialSize; i++)
        {
            Grow();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in m_DirectionResolver.Keys)
        {
            if (Input.GetKeyDown(key) && m_Direction + m_DirectionResolver[key] != Vector2.zero)
            {
                m_Direction = m_DirectionResolver[key];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        if (collision.tag == "Boundary" || collision.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(BodySegment);
        segment.position = m_Segments[m_Segments.Count - 1].position - new Vector3(m_Direction.x, m_Direction.y, 0f);
        m_Segments.Add(segment);
    }

    private void Move()
    {
        for (int i = m_Segments.Count - 1; i > 0; i--) 
        {
            m_Segments[i].position = m_Segments[i-1].position;
        }

        transform.position += new Vector3(Mathf.Round(m_Direction.x), Mathf.Round(m_Direction.y), 0f);
    }
}
