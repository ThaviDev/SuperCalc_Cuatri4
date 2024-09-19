using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class My3DButton : MonoBehaviour
{
    [SerializeField] string bChar; // Valor del boton
    [SerializeField] bool isScreen1; // Definir que pantalla pertenece
    [SerializeField] bool isNumber; // Definir si es un numero o una expresion de operacion
    [SerializeField] bool isErrase; // Define si es un boton de borrar
    [SerializeField] bool isResult; // Define si es el boton para dar resultado
    public void MyButtonPressed()
    {
        if (isErrase)
        {
            if (isScreen1)
            {
                CalcManager.Instance.ErraseScreen1();
            }
            else
            {
                CalcManager.Instance.ErraseScreen2();
            }
            return;
        }
        if (isResult)
        {
            CalcManager.Instance.GetNewResult();
        }
        // Checa que tipo de boton es
        if (isNumber)
        {
            if (isScreen1)
            {
                CalcManager.Instance.NewNumberScreen1(bChar);
            }
            else
            {
                CalcManager.Instance.NewNumberScreen1(bChar);
            }
        }
        else
        {
            CalcManager.Instance.OperationType(bChar);
        }

    }
}
