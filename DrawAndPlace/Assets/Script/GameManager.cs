using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject;

public class GameManager : MonoBehaviour
{
    public DrawLine[] _drawLine;

    private Generalmanagement _Generalmanagement;

    void Awake()
    {
        _Generalmanagement = new(this);
    }
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in _drawLine)
            {
                item.Startt();
            }
        }

    }
}
