using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
    private float _width;
    private float _height;
    private Vector3 position;
    private bool _canSpawn = false;

    private int balls = 0;


    [SerializeField] private GameObject _mainBallsPrefab;

    public int ballsAmount = 5;
    private float timer = 0f;
    void Awake()
    {
        _width = (float)Screen.width / 2.0f;
        _height = (float)Screen.height / 2.0f;

    }

    void Update()
    {
        timer += Time.deltaTime;
        
        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            _canSpawn = true;
            Touch touch = Input.GetTouch(0);
            // Move the ballGen if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                   Vector2 pos = touch.position;
                   pos.x = (pos.x - _width) / _width;
                   pos.y = (pos.y - _height) / _height;
                   position = new Vector3(pos.x, transform.position.y, 0.0f);

                   // Position the BallGen.
                   transform.position = position;


            }
        }
        
        if(_canSpawn == true && timer > 1f && balls < ballsAmount)
        {
            Create();
            balls++;
            timer = 0f;
        }
   


    }

    public void Create()
    {
            Instantiate(_mainBallsPrefab, transform.position, Quaternion.identity); 
    }
}
