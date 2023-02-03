using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    private Transform _stationSignalReceiver; public Transform StationSignalReceiver { get { return _stationSignalReceiver; } set { _stationSignalReceiver = value; } }
    private MenuController _mainController;


    private void Awake()
    {
        _mainController = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<MenuController>();
    }
    private void Start()
    {
        LeanTween.move(gameObject, _stationSignalReceiver.position, 2f).setOnComplete(StartDecode);
    }

    private void StartDecode()
    {
        _mainController.OfficeCanvas();
    }
}
