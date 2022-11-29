using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
