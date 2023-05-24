using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityProject;

[Serializable]

public class StartObjects
{
    public GameObject _startObject;
    public GameObject _socketStartPosition;

}
public class GameManager : MonoBehaviour
{
    public DrawLine[] _drawLine;

    private Generalmanagement _Generalmanagement;
    [SerializeField] private int _topObjnumber;

    private bool timeStart; 
    private int _totalGirSocketNum;

    [SerializeField] List<StartObjects> _StartObjects;
    void Awake()
    {
        _Generalmanagement = new(this);
        _totalGirSocketNum = _topObjnumber;
    }
    void Start()
    {
        
    }

    
    void Update()
    {

       

    }

    void Win()
    {
        Debug.Log("Win");
    }

    void Lost()
    {
        Debug.Log("Lost");
    }

    void Begin()
    {
        foreach (var item in _drawLine)
        {
            item.Startt();
            
        }
    }
    public void TheLineisOver()
    {
        _topObjnumber--;

        if (_topObjnumber ==0)
        {
            Begin();
        }
    }

    public void SocketOtr()
    {
        _totalGirSocketNum--;
        if (!timeStart)
        {
            Invoke("SocketControl",.5f);
            timeStart = true;
        }
        if (_totalGirSocketNum == 0)
        {
            Win();
        }
    }

    void SocketControl()
    {
        if (_totalGirSocketNum != 0)
        {
            Lost();
        }
    }
}
