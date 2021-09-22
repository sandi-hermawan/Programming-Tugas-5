using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : Bird
{
    //settingan ledakan
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;

    //settingan fx
    public GameObject ExplosionEffect;

    private bool _isHit = false;
    public float Health = 15f;

    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);

        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        //mengatur fx
        GameObject ExplosionEffectIns = Instantiate(ExplosionEffect,transform.position, Quaternion.identity);
        Destroy(ExplosionEffectIns, 10);
        Destroy(gameObject);
    }
    //method ini untuk menampilkan area bom agar terlihat tanpa perlu di play terlebih dahulu
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //supaya meledaknya tidak instan saya berikan hp
        if (col.gameObject.tag == "Obstacle")
        {
            //Hitung damage yang diperoleh
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;
            //ketika hpnya 0 method explode akan dijalankan
            if (Health <= 0)
            {
                _isHit = true;
                explode();
                SoundManagerScript.PlaySound("hit");
            }
        }
    }
    
}
