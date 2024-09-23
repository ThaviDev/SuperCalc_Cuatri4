using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=k4JlFxPcqlg
    public static Action<string> Result;

    string _num1;
    string _num2;
    string _oper;
    string _currentResult;

    private static CalcManager _instance;
    public static CalcManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Buscar una instancia existente en la escena.
                _instance = FindObjectOfType<CalcManager>();

                if (_instance == null)
                {
                    // Crear un nuevo GameObject con el script adjunto si no se encuentra ninguna instancia.
                    GameObject singletonObject = new GameObject("CalcManager");
                    _instance = singletonObject.AddComponent<CalcManager>();

                    // Opcional: Evitar que el objeto sea destruido al cambiar de escena.
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Evitar que el objeto sea destruido al cambiar de escena.
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // Destruir instancias adicionales si ya existe una instancia.
        }
    }

    void Start()
    {
        _num1 = ""; _num2 = ""; _oper = "+";
        //print(float.Parse(num1) + float.Parse(num2));
    }

    public string GetElements()
    {
        return _num1 + " " + _oper + " " + _num2 + " = ";
    }

    public void GetNewResult()
    {
        print("Hora de poner resultado");
        Operation();
        //Result += Operation();
        Result?.Invoke(_currentResult);
    }

    void Operation()
    {
        var _result = "";
        // Switch que maneja la posible operacion
        switch (_oper) {
            case "+":
                _result = "" + (float.Parse(_num1) + float.Parse(_num2));
                break;
            case "-":
                _result = "" + (float.Parse(_num1) - float.Parse(_num2));
                break;
            case "*":
                _result = "" + (float.Parse(_num1) * float.Parse(_num2));
                break;
            case "/":
                try {
                    _result = "" + (float.Parse(_num1) / float.Parse(_num2));
                }
                catch {
                    _result = "No dividir por 0";
                }
                break;
        }
        _currentResult = _result;
        //return _result;
    }

    public void NewNumberScreen1(string _string)
    {
        _num1 += _string;
        //print("Nuevo numero en pantalla 1: " + _string + " Que hace el numero: " + num1);
        UI_Manager.Instance.UpdateScreen1Num(_num1);
    }
    public void NewNumberScreen2(string _string) 
    {
        _num2 += _string;
        UI_Manager.Instance.UpdateScreen2Num(_num2);
    }
    public void OperationType(string _string)
    {
        _oper = _string;
        UI_Manager.Instance.UpdateOperation(_oper);
    }
    public void ErraseScreen1()
    {
        _num1 = "";
        UI_Manager.Instance.UpdateScreen1Num(_num1);
    }
    public void ErraseScreen2()
    {
        _num2 = "";
        UI_Manager.Instance.UpdateScreen2Num(_num2);
    }

}
