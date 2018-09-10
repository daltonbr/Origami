using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SphereCommands : MonoBehaviour, IFocusable, IInputHandler/*, ISpeechHandler*/
{

    Vector3 _originalPosition;
    //private KeywordRecognizer _keywordRecognizer = null;
    //private Dictionary<string, System.Action> _keywords = new Dictionary<string, System.Action>();
    
    // Use this for initialization
    void Start()
    {        
        // Grab the original local position of the sphere when the app starts.
        _originalPosition = this.transform.localPosition;

        //_keywords.Add("Reset world", () => { this.BroadcastMessage("OnReset"); });

        //_keywords.Add("Drop Sphere", () =>
        //{
        //    var focusObject = GazeManager.Instance.HitObject;
        //    if (focusObject != null)
        //    {
        //        // Call the OnDrop method on just the focused object.
        //        focusObject.SendMessage("OnDrop", SendMessageOptions.DontRequireReceiver);
        //    }
        //});

        //// Tell the KeywordRecognizer about our keywords.
        //_keywordRecognizer = new KeywordRecognizer(_keywords.Keys.ToArray());

        //// Register a callback for the KeywordRecognizer and start recognizing!
        ////_keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        //_keywordRecognizer.Start();
    }

    //private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    //{
    //    System.Action keywordAction;
    //    if (_keywords.TryGetValue(args.text, out keywordAction))
    //    {
    //        keywordAction.Invoke();
    //    }
    //}

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
        OnSelect();
    }

    //void ISpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
    //{
    //    switch (eventData.RecognizedText.ToLower())
    //    {
    //        case "reset":
    //            this.BroadcastMessage("OnReset");
    //            break;
    //        case "drop":
    //            OnDrop();
    //            break;
    //    }
    //}
    
    public void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
            Destroy(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = _originalPosition;
    }

    public void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    public void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
}
