using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    private bool thirdperson = true;
    //[SerializeField] private InputAction action;
    private CinemachineFreeLook thirdpersoncamera;
    private CinemachineVirtualCamera fpscamera;




    // Start is called before the first frame update
    void Start()
    {
        thirdpersoncamera = GameObject.Find("third person shoot").GetComponent<CinemachineFreeLook>();
        fpscamera = GameObject.Find("fps").GetComponent<CinemachineVirtualCamera>();

        //action.performed += _ => SwitchPriority();

    }

    /*
    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }*/


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchPriority();
        }
    }

    private void SwitchPriority()
    {
        if (thirdperson)
        {
            thirdpersoncamera.Priority = 0;
            fpscamera.Priority = 1;
        }else
        {
            thirdpersoncamera.Priority = 1;
            fpscamera.Priority = 0;
        }
        thirdperson = !thirdperson; 
    }
}