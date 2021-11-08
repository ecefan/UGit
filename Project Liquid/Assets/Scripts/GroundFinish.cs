using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFinish : MonoBehaviour
{
    [SerializeField]private UI ui;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("NewBalls"))
        {
            ui.balls++;
        }
    }
}