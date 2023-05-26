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

    //--Auto level
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

    //----- Memory Management

    public static class MemoryManager
    {
        public static void SaveDataInt(string Key,int Value)
        {
            PlayerPrefs.SetInt(Key,Value);
        }

        public static int ReadDataInt(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }

        public static void SaveDataString(string Key, string Value)
        {
            PlayerPrefs.SetString(Key, Value);
        }

        public static string ReadDataString(string Key)
        {
            return PlayerPrefs.GetString(Key);
        }

        public static bool Is_There_a_Key(string Key)
        {
            return PlayerPrefs.HasKey(Key);
        }
    }
}