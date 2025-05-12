using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public Vector2 moveDirection = new Vector2(1, -1);
    public float speed = 3f;

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (transform.position.x > 80)
        {
            Destroy(gameObject);
        }
    }
}
