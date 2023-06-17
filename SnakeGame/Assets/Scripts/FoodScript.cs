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
        float xPos = Mathf.Round(Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x / 2));
        float yPos = Mathf.Round(Random.Range(SpawnArea.bounds.min.y, SpawnArea.bounds.max.y / 2));

        transform.position = new Vector3(Mathf.Round(xPos * 2 + 1), Mathf.Round(yPos * 2 + 1));
    }
}
