using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float leftBoundary = -10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverObstacle();
    }
    private void MoverObstacle()
    {
        transform.position += Vector3.left * GameManager.instance.GetGameSpeed() * Time.deltaTime;
        if(transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
}
