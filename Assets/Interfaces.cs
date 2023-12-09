using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObject
{
    //int Hp { get; set; }
    //void GetDamage(int damage);
    void Move();
    
}

public interface ITank : IObject
{

    //public int Hp { get; set; }
    public void BeDestroyed();
    public void GetDamage(int damage);


}

//public interface IBullet:I
