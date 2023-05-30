using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;
using UnityProject;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;


public class GameManager : MonoBehaviour
    {
        [Header("---GENERAL OBJECTS")]
        public List<DrawLine> _drawLine;
        [SerializeField] private int _topObjnumber;
        [SerializeField] private GameObject[] _Panels;
        [SerializeField] private AudioSource[] _Sounds;
        [SerializeField] private Image[] _ButtonImages;
        [SerializeField] private Sprite[] _SpriteObjects;
        [SerializeField] private ParticleSystem[] _CollisionEffects;
        private int _CollisionEffectsIndex;
        [SerializeField] private ParticleSystem[] _OtrEffects;
        private int _OtrEffectsIndex;
        [SerializeField] private ParticleSystem _WinEffect;
        [SerializeField] private TextMeshProUGUI _scoreText;

        [Header("---AUTO LEVEL")]
        [SerializeField] List<AutoLevel> _AutoLevel;

       private Generalmanagement _Generalmanagement;
       private bool timeStart;
       private int _totalGirSocketNum;
       private int _sceneIndex;
       private AudioSource _GameSound;
         void Awake()
        {
            _Generalmanagement = new(this);
             SceneFirstPro();
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

      public void PlaySound(int Indexx)
     {
        _Sounds[Indexx].Play();
     }

       void Win()
        {
            _WinEffect.gameObject.SetActive(true);
            _WinEffect.Play();
            TurnOnPanel(1);
            PlaySound(2);
            MemoryManager.SaveDataInt("Level",_sceneIndex+1);
            MemoryManager.SaveDataInt("Score",MemoryManager.ReadDataInt("Score")+50);
            _scoreText.text = MemoryManager.ReadDataInt("Score").ToString();
            Time.timeScale = 0;

       }

         public void Lost()
        {
            TurnOnPanel(2);
            PlaySound(1);
            Time.timeScale = 0;
        }

    public void ButtonTech(string Pro)
        {
            switch (Pro)
            {
              case "Pause":
                  PlaySound(0);
                  TurnOnPanel(0);
                Time.timeScale = 0;
                break;

              case "Resume":
                  PlaySound(0);
                  TurnOffPanel(0);
                  Time.timeScale = 1;
                  break;

              case "Again":
                  PlaySound(0);
                  SceneManager.LoadScene(_sceneIndex);
                  Time.timeScale = 1;
                  break;
              case "NextLevel":
                  PlaySound(0);
                  SceneManager.LoadScene(_sceneIndex+1);
                  Time.timeScale = 1;
                  break;

              case "Exit":
                  PlaySound(0);
                  TurnOnPanel(3);
                  break;

              case "Yes":
                  PlaySound(0);
                  Application.Quit();
                  break;

              case "No":
                  PlaySound(0);
                  TurnOffPanel(3);
                  break;

              case "GameSoundSettings":
                  PlaySound(0);

                  if (MemoryManager.ReadDataInt("GameSound")==0)
                  {
                      MemoryManager.SaveDataInt("GameSound",1);
                      _ButtonImages[0].sprite = _SpriteObjects[0];
                      _GameSound.mute = false;
                  }
                  else
                  {
                    MemoryManager.SaveDataInt("GameSound", 0);
                    _ButtonImages[0].sprite = _SpriteObjects[1];
                    _GameSound.mute = true;
                  }
                  break;

              case "EffectSoundSettings":
                  PlaySound(0);

                  if (MemoryManager.ReadDataInt("EffectSound") == 0)
                  {
                      MemoryManager.SaveDataInt("EffectSound", 1);
                      _ButtonImages[1].sprite = _SpriteObjects[2];

                    foreach (var item in _Sounds)
                      {
                          item.mute = false;
                      }
                  }
                  else
                  {
                      MemoryManager.SaveDataInt("EffectSound", 0);
                      _ButtonImages[1].sprite = _SpriteObjects[3];
                      foreach (var item in _Sounds)
                    {
                        item.mute = true;
                    }
                   }
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

        public void SocketOtr(Vector2 SocketPosition)
        {
            PlaySound(4);
            _totalGirSocketNum--;

            _OtrEffects[_OtrEffectsIndex].gameObject.SetActive(true);
            _OtrEffects[_OtrEffectsIndex].transform.position = SocketPosition;
            _OtrEffects[_OtrEffectsIndex].Play();
            _OtrEffectsIndex++;

            if (_OtrEffects.Length - 1 == _OtrEffectsIndex)
            {
                _OtrEffectsIndex = 0;
            }




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

        void SceneFirstPro()
        {
          _totalGirSocketNum = _topObjnumber;
         _scoreText.text = MemoryManager.ReadDataInt("Score").ToString();
           _GameSound = GameObject.FindGameObjectWithTag("GameSound").GetComponent<AudioSource>();
           _sceneIndex = SceneManager.GetActiveScene().buildIndex;


        if (MemoryManager.ReadDataInt("GameSound") == 0)
            {
                
                _ButtonImages[0].sprite = _SpriteObjects[1];
                _GameSound.mute = true;
            }
            else
            {
                
                _ButtonImages[0].sprite = _SpriteObjects[0];
                _GameSound.mute = false;
            }
           

            if (MemoryManager.ReadDataInt("EffectSound") == 0)
            {
                
                _ButtonImages[1].sprite = _SpriteObjects[3];

                foreach (var item in _Sounds)
                {
                    item.mute = true;
                }
            }
            else
            {
                _ButtonImages[1].sprite = _SpriteObjects[2];
                foreach (var item in _Sounds)
                {
                    item.mute =false;
                }
            }
    }

        public void SocketCollision(Vector2 SocketPosition)
        {
            PlaySound(3);
            _CollisionEffects[_CollisionEffectsIndex].gameObject.SetActive(true);
            _CollisionEffects[_CollisionEffectsIndex].transform.position = SocketPosition;
            _CollisionEffects[_CollisionEffectsIndex].Play();
            _CollisionEffectsIndex++;

            if (_CollisionEffects.Length-1==_CollisionEffectsIndex)
            {
                _CollisionEffectsIndex = 0;
            }
        }
    }
