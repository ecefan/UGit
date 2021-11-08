using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private GameObject _newBallsPrefab;

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Ball")
        {
            for (int i = 0; i < x; i++)
            {
                var location = collision.gameObject.transform.position;

                location.y -= Random.Range((float)-0.5, (float)0.5);
                location.x -= Random.Range((float)-0.5, (float)0.5);

                Instantiate(_newBallsPrefab, location, collision.gameObject.transform.rotation);

            }
        }
    }
}
