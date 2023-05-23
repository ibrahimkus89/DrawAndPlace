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
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_socketColor))
       {
            Debug.Log("deðru renk" +_socketColor);
       }
    }
}
