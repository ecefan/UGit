using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField] private Material day;
    [SerializeField] private Material night;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSky()
    {
     
            RenderSettings.skybox = night;
  

    }

    public void Resart()
    {
        SceneManager.LoadScene(0);
    }
}
