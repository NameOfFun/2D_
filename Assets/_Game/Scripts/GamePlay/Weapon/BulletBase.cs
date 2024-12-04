using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public const float TIME_ALIVE = 2f;

    public Transform tf;
    [SerializeField] private TrailRenderer trail;

    float timeAlive;
    protected float damage;
    bool isActive;
    [SerializeField] private float moveSpeed = 20;

    public void OnInit(float damage)
    {
        this.damage = damage;
        this.timeAlive = Time.time + TIME_ALIVE;
        trail.Clear();
        isActive = true;
    }

    // kết thúc khi khôg dùng nữa
    public void OnDespawn()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isActive){
            tf.Translate(tf.up * Time.deltaTime * moveSpeed, Space.World);
            if(timeAlive <= Time.time)
            {
                isActive = false;
                OnDespawn();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            Character c = collision.GetComponent<Character>();
            if (c != null)
            {
                // TODO: something
                OnDespawn();
            }
        }
    }

}
