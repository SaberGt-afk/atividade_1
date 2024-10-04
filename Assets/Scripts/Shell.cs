using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 3.0f;
    float mass = 10f;
    float force = 1000f;
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

    }

    // Update is called once per frame
    void LateUpdate()
    {
        accelaration = force / mass;
        speed += accelaration * Time.deltaTime;        
        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
