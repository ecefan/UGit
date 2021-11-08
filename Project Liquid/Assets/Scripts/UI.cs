using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _ballsCount;
    public int balls;
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        _ballsCount.text = balls.ToString();
    }
}
