using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balls : MonoBehaviour
{
    
    [SerializeField] private float _bouncingForce;
    private Rigidbody2D _rb;
    private Vector3 _lastVelosity;



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        _lastVelosity = _rb.velocity;



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bounce"))
        {
            var direction = Vector3.Reflect(_lastVelosity.normalized, collision.contacts[0].normal);
            _rb.velocity = direction * Mathf.Max(_bouncingForce, 10);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject, 0.2f);
            //Here particle effect
        }


        if (collision.gameObject.CompareTag("Death"))
        {
                Destroy(this.gameObject);
                //Here Death Particle
        }
        }





}
