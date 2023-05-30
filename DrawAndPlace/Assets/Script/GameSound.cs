using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject;

public class GameSound : MonoBehaviour
{
    private static GameObject Instance;
    void Start()
    {
        if (MemoryManager.ReadDataInt("GameSound")==0)
        {
            GetComponent<AudioSource>().mute =true;
            
        }

        DontDestroyOnLoad(gameObject);

        if (Instance ==null)
        {
            Instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
