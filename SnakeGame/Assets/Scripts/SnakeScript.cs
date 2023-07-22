using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private Dictionary<KeyCode, Vector2> m_DirectionResolver;
    private Vector2 m_Direction;
    private List<Transform> m_Segments;
    private bool m_IsDead;

    [SerializeField] Canvas RespawnMenu;
    [SerializeField] int InitialSize = 4;

    public float Speed = 25;
    public float SpeedMultiplier;
    public Rigidbody2D Rigidbody;
    public Transform BodySegment;

    void Start()
    {
        SpeedMultiplier = InstanceData.Instance.Data.SpeedMultiplier;

        m_DirectionResolver = new Dictionary<KeyCode, Vector2>()
        {
            {KeyCode.A, Vector2.left },
            {KeyCode.W, Vector2.up },
            {KeyCode.S, Vector2.down },
            {KeyCode.D, Vector2.right }
        };
        m_Direction = Vector2.down;
        m_Segments = new List<Transform>() {transform };
        RespawnMenu.gameObject.SetActive(false);
        m_IsDead = false;

        InvokeRepeating("Move", 0.2f, 1/(Speed * SpeedMultiplier));

        for (int i = 0; i < InitialSize; i++)
        {
            Grow();
        }
    }

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
            RespawnMenu.gameObject.SetActive(true);
            gameObject.SetActive(false);
            m_IsDead = true;
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(BodySegment);
        segment.position = m_Segments[m_Segments.Count - 1].position - new Vector3(m_Direction.x * 2, m_Direction.y * 2, 0f);
        m_Segments.Add(segment);
    }

    private void Move()
    {
        if (m_IsDead)
        {
            return;
        }

        for (int i = m_Segments.Count - 1; i > 0; i--) 
        {
            m_Segments[i].position = m_Segments[i-1].position;
        }

        transform.position += new Vector3(Mathf.Round(m_Direction.x * 2), Mathf.Round(m_Direction.y * 2), 0f);
    }
}
