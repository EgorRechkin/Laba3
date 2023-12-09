using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


/*public class Tank : MonoBehaviour, IObject, ITank
{
    
}*/

public class Tank : MonoBehaviour, ITank, IObject
{
    // Start is called before the first frame update
    //public GameObject Square;
    public GameObject Bullet;

    void Start()
    {
        Hp = 10;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public int Hp { get; set; } /// Так вообще можно????????????????
    private float speed = 0.05f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    //private Vector3 BulletVector;
    public void GetDamage(int damage)
    {
        if (Hp > damage)
        {
            Hp -= damage;
        }
        else
        {
            Hp = 0;
        }
    }
    public void BeDestroyed()
    {
        Destroy(gameObject);
    }
    public void Move()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed/** Time.deltaTime*/);
        Vector3 rotate = transform.eulerAngles;
        if (Input.GetAxis("Horizontal") > 0)
        {
            rotate.z = -90;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {

            rotate.z = 90;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rotate.z = 0;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            rotate.z = 180;
        }
        transform.rotation = Quaternion.Euler(rotate);
    }
    public void LaunchBullet()
    {
        Vector3 vector = transform.position;
        Quaternion q = transform.rotation;
        //Physics2D.IgnoreCollision(Bullet.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        Instantiate(Bullet, vector, q);
        
    }
    void Update()
    {
        Move();
        //if (Input.GetKeyDown(KeyCode.Space))
        if(Input.GetMouseButtonDown(0))
        {
            LaunchBullet();
        }
        if (Hp == 0)
        {
            BeDestroyed();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Square"))
        {
            gameObject.SetActive(false);
        }
    }
    
}
