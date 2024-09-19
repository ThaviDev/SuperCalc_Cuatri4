using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=k4JlFxPcqlg
    public delegate string NewResult(string result);
    public static event NewResult Result;

    string num1;
    string num2;
    string oper;

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

    // Start is called before the first frame update
    void Start()
    {
        num1 = ""; num2 = ""; oper = "+";
        //print(float.Parse(num1) + float.Parse(num2));
    }

    public void GetNewResult()
    {
        Result(Operation());
    }

    string Operation()
    {
        var _result = "";
        // Switch que maneja la posible operacion
        switch (oper) {
            case "+":
                _result = "" + (float.Parse(num1) + float.Parse(num2));
                break;
            case "-":
                _result = "" + (float.Parse(num1) - float.Parse(num2));
                break;
            case "*":
                _result = "" + (float.Parse(num1) * float.Parse(num2));
                break;
            case "/":
                try {
                    _result = "" + (float.Parse(num1) / float.Parse(num2));
                }
                catch {
                    _result = "No dividir por 0";
                }
                break;
        }
        return _result;
    }

    public void NewNumberScreen1(string _string)
    {
        num1 += _string;
        print("Nuevo numero en pantalla 1: " + _string + " Que hace el numero: " + num1);
        UI_Manager.Instance.UpdateScreen1Num(num1);
    }
    public void NewNumberScreen2(string _string) 
    {
        num2 += _string;
    }
    public void OperationType(string _string)
    {
        oper = _string;
    }
    public void ErraseScreen1()
    {
        num1 = "";
        UI_Manager.Instance.UpdateScreen1Num(num1);
    }
    public void ErraseScreen2()
    {
        num2 = "";
    }

}
