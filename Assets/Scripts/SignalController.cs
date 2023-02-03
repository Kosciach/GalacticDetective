using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    private Transform _stationSignalReceiver; public Transform StationSignalReceiver { get { return _stationSignalReceiver; } set { _stationSignalReceiver = value; } }



    private void Start()
    {
        LeanTween.move(gameObject, _stationSignalReceiver.position, 2f).setOnComplete(StartDecode);
    }

    private void StartDecode()
    {
        Debug.Log("StartDecode");
    }
}
