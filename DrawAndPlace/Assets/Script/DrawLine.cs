using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<Vector2> fingerPosList;
    [SerializeField] Socket _socket;

     Camera _camera;
     private int fingerPosIndex;
    void Start()
    {
        _camera = Camera.main;
    }

   
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }


        if (Input.GetMouseButton(0))
        {
            Vector2 fingerPos = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(fingerPos, fingerPosList[^1]) >.1f)
            {
                UpdateTheLine(fingerPos);
            }
        }

    }

    void CreateLine()
    {
        fingerPosList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
        fingerPosList.Add(_camera.ScreenToWorldPoint(Input.mousePosition));
        _lineRenderer.SetPosition(0, fingerPosList[0]);
        _lineRenderer.SetPosition(1, fingerPosList[1]);


    }

    void UpdateTheLine(Vector2 incomingFingerPos)
    {
        fingerPosList.Add(incomingFingerPos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount-1,incomingFingerPos);
    }


    public void Startt()
    {
        _socket.place = true;

    }

    public Vector2 LastPosition()
    {
        return fingerPosList[fingerPosIndex];
    }

    public Vector2 NextPosition()
    {
        if (fingerPosIndex == fingerPosList.Count -1)
        {
            _socket.place =false;
            return fingerPosList[fingerPosIndex];
        }
        else
        {
            fingerPosIndex++;
            return fingerPosList[fingerPosIndex];

        }

        

    }
}
