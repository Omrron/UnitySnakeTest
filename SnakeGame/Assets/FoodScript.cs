using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private float m_LeftBoundary; 
    private float m_RightBoundary; 
    private float m_TopBoundary; 
    private float m_BottomBoundary; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject leftBoundary = GameObject.Find("LeftBoundary");
        GameObject rightBoundary = GameObject.Find("RightBoundary");
        GameObject topBoundary = GameObject.Find("TopBoundary");
        GameObject bottomBoundary = GameObject.Find("BottomBoundary");
        
        m_LeftBoundary = leftBoundary.transform.position.x + leftBoundary.GetComponent<Renderer>().bounds.size.x;
        m_RightBoundary = rightBoundary.transform.position.x - rightBoundary.GetComponent<Renderer>().bounds.size.x;
        m_TopBoundary = topBoundary.transform.position.y - topBoundary.GetComponent<Renderer>().bounds.size.y;
        m_BottomBoundary = bottomBoundary.transform.position.y + bottomBoundary.GetComponent<Renderer>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float xPos = Random.Range(m_LeftBoundary + 1f, m_RightBoundary);
            float yPos = Random.Range(m_BottomBoundary + 1f, m_TopBoundary);
            transform.position = new Vector3(xPos, yPos);
            Debug.Log($"new position ({xPos}, {yPos})");
        }
    }
}
