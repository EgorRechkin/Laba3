using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    //private Rigidbody2D ob;
    private ITank _target;
    private ITank Launcher;
    private Vector2 moveVector;
    private float speed;
    public void DealDamage(int damage, GameObject EnemyTank)
    {
        
        _target = EnemyTank.GetComponent<EnemyTank>();
        _target.GetDamage(damage);
        
    }
    void Start()
    {
        speed = 3f;
        //Launcher = 
        //Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        float var = transform.rotation.z;
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "block")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        if (collision.collider.TryGetComponent(out Block block))
        {
            Destroy(block.gameObject);
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "EnemyTank" && gameObject.tag=="Bullet")
        {
            DealDamage(2, collision.gameObject);
            Destroy(gameObject);
        }
        
        if (collision.collider.TryGetComponent(out Tank tank) && gameObject.tag == "EnemyTankBullet")
        {
            DealDamage(2, tank.gameObject);
            Destroy(gameObject);
        }
        if (collision.collider.TryGetComponent(out Tank tank1) && gameObject.tag == "Bullet")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            //print("dfghjkl;/hkl.gkfy,");
            //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
}
