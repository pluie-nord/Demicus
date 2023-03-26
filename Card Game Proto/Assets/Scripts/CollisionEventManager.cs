using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventManager : MonoBehaviour, ICollision
{
    private bool inTrigger = false;
    public string ID { get; set; }
    public string collisionID;
    // Start is called before the first frame update
    void Start()
    {
        ID = collisionID; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inTrigger = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inTrigger&Input.GetKeyDown(KeyCode.F)) 
        {
            print("Вызвали ивент коллайдера");
            CollisionEvents.Collided(this);
        }
    }
}
