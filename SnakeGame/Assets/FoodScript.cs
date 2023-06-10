using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public BoxCollider2D SpawnArea;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float xPos = Random.Range(SpawnArea.bounds.min.x,  SpawnArea.bounds.max.x);
            float yPos = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
            transform.position = new Vector3(Mathf.Round(xPos), Mathf.Round(yPos));
            Debug.Log($"new position ({xPos}, {yPos})");
        }
    }
}
