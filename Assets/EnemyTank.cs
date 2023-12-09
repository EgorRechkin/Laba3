using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyTank : MonoBehaviour, ITank, IObject
{
    // Start is called before the first frame update
    public int MaxHp = 10;
    public int CurrentHp;
    private float speed = 0.05f;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private float RotateTimer = 3f;
    private float LaunchBulletTimer = 1f;
    public GameObject Bullet;
    private Vector3 vector;
    void Start()
    {
        CurrentHp = MaxHp;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    public void GetDamage(int damage)
    {
        CurrentHp -= damage;
        print("dfg");
        print(CurrentHp);
        /*if (Hp > damage)
        {
            Hp -= damage;
            print("dfg");
            print(Hp);
        }
        else
        {
            Hp = 0;
        }*/
    }
    public void BeDestroyed()
    {
        Destroy(gameObject);
    }
    IEnumerator Wait()
    {
        print(Time.time);
        
        yield return new WaitForSeconds(1);
        Rotate();
        print(Time.time);
        
    }
    public void LaunchBullet()
    {
        LaunchBulletTimer -= Time.deltaTime;
        if (LaunchBulletTimer < 0)
        {
            LaunchBulletTimer = 1f;
            
            Quaternion q = transform.rotation;
            Instantiate(Bullet, vector, q);
        }
    }
    public void Move() {
        transform.Translate(Vector3.up *Time.deltaTime * speed);
        //StartCoroutine(Wait());
        RotateTimer -= Time.deltaTime;
        if(RotateTimer < 0)
        {
            //StartCoroutine(Wait());
            RotateTimer = 3f;
            Rotate();
        }
    }
    public void Rotate()
    {
        System.Random rnd = new System.Random();
        int number = rnd.Next(1, 4);
        //StartCoroutine(Wait());
        Vector3 rotate = transform.eulerAngles;
        vector = transform.position;
        switch (number)
        {
            case 1: 
                rotate.z = 0;
                break;
            case 2: 
                rotate.z = 90;
                break;
            case 3: 
                rotate.z = -90; 
                break;
            case 4: 
                rotate.z = 180;
                break;
        }
        transform.rotation = Quaternion.Euler(rotate);
    }
    void Update()
    {
        
        Move();
        LaunchBullet();
        //print(MaxHp);
        //print(CurrentHp);
        if (CurrentHp == 0)
        {
            BeDestroyed();
        }
    }
}
