using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityProject;

public class DrawLine : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public List<Vector2> fingerPosList =new();
    public Socket _socket;
    public string _Tag;

     Camera _camera;
     private int fingerPosIndex;
     private bool _LineStart;
     private RaycastHit2D hit;
    void Start()
    {
        _camera = Camera.main;
    }

   
    void Update()
    {

        //if (Input.GetMouseButtonDown(0) && !_LineStart)
        //{
        //    CreateLine();
        //    _LineStart =true;;
        //}


        //if (Input.GetMouseButton(0))
        //{
        //    Vector2 fingerPos = _camera.ScreenToWorldPoint(Input.mousePosition);

        //    if (Vector2.Distance(fingerPos, fingerPosList[^1]) >.1f)
        //    {
        //        UpdateTheLine(fingerPos);
        //    }
        //}

        hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-10)),Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag(_Tag) && !_LineStart && Input.GetMouseButtonDown(0))
            {
                CreateLine();
                _LineStart = true;
            }

            if (hit.collider.CompareTag("Obstacle") && _LineStart)
            {
                _LineStart =false;
                Generalmanagement._GameManager.TheLineisOver();


            }

        }

        if (Input.GetMouseButton(0) && _LineStart)
        {
            Vector2 fingerPos = _camera.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(fingerPos, fingerPosList[^1]) > .1f)
            {
                UpdateTheLine(fingerPos);
            }
        }

        if (Input.GetMouseButtonUp(0) && _LineStart)
        {
            enabled=false;
            _LineStart = false;
            Generalmanagement._GameManager.TheLineisOver();
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
        _socket._place = true;

    }

    public Vector2 LastPosition()
    {
        return fingerPosList[fingerPosIndex];
    }

    public Vector2 NextPosition()
    {
        if (fingerPosIndex == fingerPosList.Count -1)
        {
            _socket._place =false;
            return fingerPosList[fingerPosIndex];
        }
        else
        {
            fingerPosIndex++;
            return fingerPosList[fingerPosIndex];

        }

        

    }
}
