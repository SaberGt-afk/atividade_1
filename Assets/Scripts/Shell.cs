using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion; // Prefab da explosão
    public float speed = 50.0f;  // Velocidade inicial do projétil
    public float lifeTime = 5.0f; // Tempo de vida do projétil
    public float gravity = -9.8f; // Gravidade simulada

    private Vector3 velocity; // Vetor de velocidade do projétil
    private float verticalSpeed; // Velocidade vertical acumulada pela gravidade

    private void Start()
    {
        // Calcula a velocidade inicial na direção em que o projétil está apontando
        velocity = transform.forward * speed;

        // Destrói o projétil após o tempo de vida
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Aplica a gravidade no eixo Y
        verticalSpeed += gravity * Time.deltaTime;

        // Atualiza a posição do projétil com base na velocidade horizontal e vertical
        Vector3 displacement = velocity * Time.deltaTime;
        displacement.y += verticalSpeed * Time.deltaTime;

        transform.position += displacement;

        // Rotaciona o projétil para apontar na direção do movimento
        transform.rotation = Quaternion.LookRotation(velocity + Vector3.up * verticalSpeed);
    }

    private void OnCollisionEnter(Collision col)
    {
        // Checa se o projétil atingiu o inimigo (tag "tank")
        if (col.gameObject.CompareTag("tank"))
        {
            // Cria a explosão na posição do impacto
            if (explosion != null)
            {
                GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(exp, 0.5f); // Remove a explosão após 0.5 segundos
            }

            // Destroi o projétil
            Destroy(gameObject);
        }
        else
        {
            // Caso colida com outro objeto, o projétil também é destruído
            Destroy(gameObject);
        }
    }
}
