using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject
{
    public class Generalmanagement
    {
        public static GameManager _GameManager;

        public Generalmanagement(GameManager _gameManager)
        {
            _GameManager = _gameManager;
        }

    }

    [Serializable]
    public class AutoLevel
    {
        
        public List<StartObjects> _StartObjects;
        public List<Sockets> _Sockets;
        public List<LineRenderer> _LineRenderer;

    }

    [Serializable]
    public class StartObjects
    {
        public GameObject _startObject;
        public GameObject _socketStartPosition;

    }

    [Serializable]
    public class Sockets
    {
        public Color _SocketColor;
        public SpriteRenderer _spriteRenderer;

        [Header("---- SOCKET SCRÝPT PROCESS")] public Socket _Socket;
        public string _socket_color;
        public SpriteRenderer _VarYuvSpriteRenderer;
        public GameObject _VarYuvCenter;

    }

}