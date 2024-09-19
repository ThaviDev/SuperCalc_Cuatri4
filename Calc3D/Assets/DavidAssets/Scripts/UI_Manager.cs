using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager _instance;
    public static UI_Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Buscar una instancia existente en la escena.
                _instance = FindObjectOfType<UI_Manager>();

                if (_instance == null)
                {
                    // Crear un nuevo GameObject con el script adjunto si no se encuentra ninguna instancia.
                    GameObject singletonObject = new GameObject("UI_Manager");
                    _instance = singletonObject.AddComponent<UI_Manager>();

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

    // Lista de historial
    List<string> resHistory = new List<string>();

    [SerializeField] TMP_Text _screen1Number;
    [SerializeField] TMP_Text _screen2Number;
    [SerializeField] TMP_Text _operationText;
    [SerializeField] TMP_Text _resultText;
    [SerializeField] TMP_Text _historyText;

    void Start()
    {
        //CalcManager.Result += UpdateResult(string _strng);
        CalcManager.Result += UpdateResult;
        CalcManager.Result += AddHistoryElement;
    }

    void Update()
    {

    }

    void AddHistoryElement(string _strng)
    {
        resHistory.Add(_strng);
        if (resHistory.Count >= 10)
        {
            resHistory.RemoveAt(10);
        }
        PrintHistory();
    }

    void PrintHistory()
    {
        _historyText.text = "";
        _historyText.text += "History: \n";
        print(resHistory.Count);
        for (int i = resHistory.Count; i >= 0; i--) {
            print("iteracion: " + i);
            _historyText.text += resHistory[i] + "\n";
        }
    }

    public void UpdateScreen1Num(string _strng)
    {
        _screen1Number.text = _strng;
    }
    public void UpdateScreen2Num(string _strng)
    {
        _screen2Number.text = _strng;
    }
    public void UpdateOperation(string _strng)
    {
        _operationText.text = _strng;
    }
    void UpdateResult(string _strng)
    {
        _resultText.text = _strng;
    }
}
