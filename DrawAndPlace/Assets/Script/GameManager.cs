using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityProject;


    public class GameManager : MonoBehaviour
    {
        [Header("---GENERAL OBJECTS")]
        public List<DrawLine> _drawLine;
        [SerializeField] private int _topObjnumber;
        [SerializeField] private GameObject[] _Panels;

        [Header("---AUTO LEVEL")]
        [SerializeField] List<AutoLevel> _AutoLevel;

       private Generalmanagement _Generalmanagement;
       private bool timeStart;
       private int _totalGirSocketNum;

    void Awake()
        {
            _Generalmanagement = new(this);
            _totalGirSocketNum = _topObjnumber;
        }

        void Start()
        {
            for (int i = 0; i <_AutoLevel[0]._StartObjects.Count; i++)
            {
                _AutoLevel[0]._StartObjects[i]._startObject.tag = "Start" + (i+1);

                _AutoLevel[0]._Sockets[i]._Socket.transform.position = _AutoLevel[0]._StartObjects[i]._socketStartPosition.transform.position;

                _AutoLevel[0]._Sockets[i]._spriteRenderer.color = _AutoLevel[0]._Sockets[i]._SocketColor;

                _AutoLevel[0]._Sockets[i]._Socket._LineIndex = i;

               _AutoLevel[0]._Sockets[i]._Socket._socketColor = _AutoLevel[0]._Sockets[i]._socket_color;

              _AutoLevel[0]._Sockets[i]._VarYuvSpriteRenderer.gameObject.tag = _AutoLevel[0]._Sockets[i]._socket_color;

              _AutoLevel[0]._Sockets[i]._VarYuvSpriteRenderer.color = _AutoLevel[0]._Sockets[i]._SocketColor;

              _AutoLevel[0]._Sockets[i]._Socket._arrivalYuv = _AutoLevel[0]._Sockets[i]._VarYuvCenter;


            // Optional start and end color settings
            //_LineRenderer[i].startColor = _Sockets[i]._SocketColor;
            //_LineRenderer[i].endColor = _Sockets[i]._SocketColor;

            DrawLine _Dl = gameObject.AddComponent<DrawLine>();

            _Dl._lineRenderer = _AutoLevel[0]._LineRenderer[i];

            _Dl._socket =_AutoLevel[0]._Sockets[i]._Socket;

            _Dl._Tag = "Start" + (i + 1);


            _drawLine.Add(_Dl);
        }

    }


        void TurnOnPanel(int Indexx)
        {
        _Panels[Indexx].SetActive(true);

        }

     void TurnOffPanel(int Indexx)
     {
        _Panels[Indexx].SetActive(false);

     }

    void Win()
        {
            Debug.Log("Win");
        }

        void Lost()
        {
            Debug.Log("Lost");
        }

        public void ButtonTechPro(string Process)
        {
            switch (Process)
            {
             case "Pause":
                 TurnOnPanel(0);
                 Time.timeScale = 0;
                break;
            }
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

            if (_topObjnumber == 0)
            {
                Begin();
            }
        }

        public void SocketOtr()
        {
            _totalGirSocketNum--;
            if (!timeStart)
            {
                Invoke("SocketControl", .5f);
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
