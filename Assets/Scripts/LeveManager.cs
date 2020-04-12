using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeveManager : MonoBehaviour
{
    [SerializeField] float gameTime;

    private void Update() 
    {
        Counter();    
    }

    private void Counter()
    {
        gameTime -= Time.deltaTime;
        
        if(gameTime <= 0)
        {
            Debug.Log("Lo lograste");
        }
    }
}
