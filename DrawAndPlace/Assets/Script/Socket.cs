using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject;

public class Socket : MonoBehaviour
{
    public bool place;
    [SerializeField] private int LineIndex;
    
    void Update()
    {

        if (place)
        {

            if (Vector2.Distance(transform.position, Generalmanagement._GameManager._drawLine[0].LastPosition()) > .1f)
            {
                transform.position = Vector2.Lerp(transform.position, Generalmanagement._GameManager._drawLine[0].LastPosition(),.2f);
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, Generalmanagement._GameManager._drawLine[0].NextPosition(),.2f);

            }

        }
    }
}
