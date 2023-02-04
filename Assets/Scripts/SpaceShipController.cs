using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] SpaceShip _spaceShipData; public SpaceShip SpaceShip { get { return _spaceShipData; } }
    [SerializeField] GameObject _signalPrefab;
    private Transform _stationDock; public Transform StationDock { get { return _stationDock; } set { _stationDock = value; } }


    private void Start()
    {
        LeanTween.scale(gameObject, Vector2.one * _spaceShipData.Size, _spaceShipData.Speed);
        LeanTween.move(gameObject, _stationDock.position, _spaceShipData.Speed).setOnComplete(SendSignal);
    }

    private void SendSignal()
    {
        StartCoroutine(Signal());
    }

    IEnumerator Signal()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject newSignal = Instantiate(_signalPrefab, transform.position, transform.rotation);
        SignalController newSignalController = newSignal.GetComponent<SignalController>();
        newSignalController.StationSignalReceiver = _stationDock.parent.GetChild(1);
        newSignalController.SpaceShipData = _spaceShipData;
    }
}
