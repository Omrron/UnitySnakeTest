using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public BoxCollider2D SpawnArea;

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePosition();
        }
    }

    private void RandomizePosition()
    {
        float xPos = Random.Range(SpawnArea.bounds.min.x,  SpawnArea.bounds.max.x);
        float yPos = Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y);
        transform.position = new Vector3(Mathf.Round(xPos), Mathf.Round(yPos));
    }
}
