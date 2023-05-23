using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityProject;

public class Socket : MonoBehaviour
{
    public bool _place;
    [SerializeField] private int _LineIndex;
    [SerializeField] private string _socketColor;

     bool _yuvOt;
     private Vector2 _yuvPosition;
     [SerializeField] private GameObject _arrivalYuv;
    void Update()
    {

        if (_place)
        {

            if (Vector2.Distance(transform.position, Generalmanagement._GameManager._drawLine[_LineIndex].LastPosition()) > .1f)
            {
                transform.position = Vector2.Lerp(transform.position, Generalmanagement._GameManager._drawLine[_LineIndex].LastPosition(),.2f);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, Generalmanagement._GameManager._drawLine[_LineIndex].NextPosition(),.2f);

            }

        }

        if (_yuvOt)
        {
            if (Vector2.Distance(transform.position, _yuvPosition) > .1f)
            {
                transform.position = Vector2.Lerp(transform.position, _yuvPosition, .2f);
            }
            else
            {
                transform.position = _yuvPosition;
                _yuvOt =false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag(_socketColor))
        {
            //Debug.Log("doðru renk" +_socketColor);
            _yuvOt =true;
            _yuvPosition = _arrivalYuv.transform.position;

            //Optional
            //GetComponent<CircleCollider2D>().enabled = false;
        }

        else if (collision.CompareTag("Socket"))
        {
            //Debug.Log("baþka renk" + _socketColor);
            _place = false;
        }
        else
        {
            if (!collision.CompareTag(Generalmanagement._GameManager._drawLine[_LineIndex]._Tag))
            {
                _place = false;
                //Debug.Log("Game Over" + collision.gameObject.name);

            }
        }
    }
}
