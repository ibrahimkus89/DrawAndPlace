using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityProject;
using UnityEngine.SceneManagement;


    public class GameManager : MonoBehaviour
    {
        [Header("---GENERAL OBJECTS")]
        public List<DrawLine> _drawLine;
        [SerializeField] private int _topObjnumber;
        [SerializeField] private GameObject[] _Panels;
        [SerializeField] private TextMeshProUGUI _scoreText;

        [Header("---AUTO LEVEL")]
        [SerializeField] List<AutoLevel> _AutoLevel;

       private Generalmanagement _Generalmanagement;
       private bool timeStart;
       private int _totalGirSocketNum;
       private int _sceneIndex;
         void Awake()
        {
            _Generalmanagement = new(this);
            _totalGirSocketNum = _topObjnumber;
            _scoreText.text = MemoryManager.ReadDataInt("Score").ToString();
        }

        void Start()
        {
            _sceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            
            TurnOnPanel(1);
            MemoryManager.SaveDataInt("Level",_sceneIndex+1);
            MemoryManager.SaveDataInt("Score",MemoryManager.ReadDataInt("Score")+50);
            _scoreText.text = MemoryManager.ReadDataInt("Score").ToString();
            Time.timeScale = 0;

       }

         public void Lost()
        {
            TurnOnPanel(2); 
            Time.timeScale = 0;
        }

    public void ButtonTech(string Pro)
        {
            switch (Pro)
            {
              case "Pause":
                TurnOnPanel(0);
                Time.timeScale = 0;
                break;

              case "Resume":
                  TurnOffPanel(0);
                  Time.timeScale = 1;
                  break;

              case "Again":
                  SceneManager.LoadScene(_sceneIndex);
                  Time.timeScale = 1;
                  break;
              case "NextLevel":
                  SceneManager.LoadScene(_sceneIndex+1);
                  Time.timeScale = 1;
                  break;

              case "Exit":
                 TurnOnPanel(3);
                  break;

              case "Yes":
                  Application.Quit();
                  break;

              case "No":
                  TurnOffPanel(3);
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
