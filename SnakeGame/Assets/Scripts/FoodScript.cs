using UnityEngine;

public sealed class FoodScript : MonoBehaviour
{
    public BoxCollider2D SpawnArea;

    void Start()
    {
        RandomizePosition();
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
