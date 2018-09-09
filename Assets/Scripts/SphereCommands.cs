using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class SphereCommands : MonoBehaviour, IFocusable, IInputHandler
{    

    void IFocusable.OnFocusEnter()
    {
        Debug.Log("OnFocusEnter");        
    }

    void IFocusable.OnFocusExit()
    {
        Debug.Log("OnFocusExit");
    }

    void IInputHandler.OnInputDown(InputEventData eventData)
    {
        Debug.Log("OnInputDown");
    }

    void IInputHandler.OnInputUp(InputEventData eventData)
    {
        Debug.Log("OnInputUp");
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }    

}
