using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetControl : MonoBehaviour
{
    [SerializeField] private GameObject _magnetObject;
    [SerializeField] private GameObject resource;
    private bool _isActiveMagnet = false;
    [SerializeField] private Text _text;
    string On = "ON";
    string off = "OFF";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Magnet"))
        {
            collision.gameObject.transform.parent = this.gameObject.transform;
        }
    }

    public void ActivateMagnit()
    {
        if (_isActiveMagnet == false)
        {
            _text.text = off;
            _magnetObject.SetActive(true);
            _isActiveMagnet = true;
            Debug.Log("Active");
            return;
        }
        if (_isActiveMagnet == true)
        {
            _text.text = On;
            resource.transform.parent = null;
            _isActiveMagnet = false;
            _magnetObject.SetActive(false);
            Debug.Log("Off");
            return;
        }
    }
}
