# Devlog

### 10 de noviembre de 2023

> - Conceptos básicos de unity
>    - GameObjects y componentes
> - Triggers, físicas y colisiones
>
> ![](./media/2023-11-10_1.png)

`Movement.cs`
```cs
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;
    public float velocity;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        Vector3 movementDir = new Vector3(horizontalMovement, verticalMovement, 0) * Time.deltaTime * velocity;
        Debug.Log(rb2d.velocity.magnitude);
        rb2d.velocity = new Vector2(movementDir.x, movementDir.y)*velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 70);
    }
}
```