using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*************************************************************************************************************************************************************
Se usarán datos abiertos de https://www.aemet.es/es/eltiempo/prediccion/espana?p=28&w=
    Sería interesante cruzar los datos de radiación solar potencial con los datos de consumo de energía para mover los paneles (pythonMQTT?)
    
    El resultado de la simulación puede ser útil:
        - Ahorrar el movimiento de los paneles en caso de no haber un claro indicio de recepción de radiación solar.
        - Adquirir con anticipación energía de otras fuentes que pueden ser más rentables.
Mejoras: 
    - Posicionar las nubes de los datos recogidos de Aemet y asignarles un collider para que con Raycast, 
    los paneles nos devuelvan la info de horas de exposición a la radiación.
**************************************************************************************************************************************************************/

public class PanelRotation : MonoBehaviour
{


    // El sistema debería hacer que cada panel siga la rotación relativamente a la luz que recibe.
    //  Para simplificar, empleamos la luz por defecto de unity.
    //  Se usará su rotación en las x y se vinculará directamente a la rotación del panel.

    public float maxRotationX = -45f;
    [SerializeField] float minRotationX = -135f;
    // int minRotationY = -135;
    // int maxRotationY = -135;
    // int minRotationZ = -135;
    // int maxRotationZ = -135;


    // Transform myTransform;
    private Transform localTrans;
    [SerializeField] Transform sunTarget;


    private void Awake()
    {
        if(sunTarget == null) throw new Exception("FALTA ASIGNAR sunTarget");
    }

    private void Start() {
        localTrans = GetComponent<Transform>();

    }
    private void FixedUpdate()
    {

        transform.LookAt(sunTarget);

        // SetPanelLimits();
        SetLimits();

    }

    private void SetLimits()
    {
        Vector3 panelEulerAngles = localTrans.rotation.eulerAngles;

        panelEulerAngles.x = (panelEulerAngles.x> 180) ? panelEulerAngles.x - 360 : panelEulerAngles.x;
        panelEulerAngles.x = Mathf.Clamp(panelEulerAngles.x, minRotationX, maxRotationX);
    
        localTrans.rotation = Quaternion.Euler(panelEulerAngles);
            
    }

    // private void SetPanelLimits()
    // {
    //     // transform.rotation.ToEuler
    //     // set a limit to the transform rotation in 45 and -135 degrees around the x axis
    //     if (transform.rotation.x < maxRotationX)
    //     {
    //         transform.rotation = Quaternion.Euler(maxRotationX, transform.rotation.y, transform.rotation.z);
    //     }
    //     Debug.Log(transform.rotation.eulerAngles.x);

    // }


}
