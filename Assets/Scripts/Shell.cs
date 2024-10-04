using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float speed = 0f;
    float yspeed = 0f;
    float mass = 10f;
    float force = 2f;
    float drag = 10f;
    float gravity = -9.81f;
    float gravityAcceleration;
    float accelaration;



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        accelaration = force / mass; 
        speed += accelaration * 1f;
        gravityAcceleration = gravity/mass;  
    }

    // Update is called once per frame
    void LateUpdate()
    {       
        speed *= (1-Time.deltaTime * drag);
        yspeed += gravityAcceleration * Time.deltaTime;
        this.transform.Translate(0, yspeed, speed);
    }
}
