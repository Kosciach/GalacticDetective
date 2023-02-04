using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] SpaceShip _spaceShipData; public SpaceShip SpaceShip { get { return _spaceShipData; } }
    [SerializeField] GameObject _signalPrefab;
    [SerializeField] ParticleSystem _destroyParticle;
    [SerializeField] ParticleSystem _jammerParticle;
    private SpaceShipSpawnerScript _spaceShipSpawner;
    private Camera _camera;
    private ScoreScript _scoreScript;
    private int _direction; public int Direction { get { return _direction; } set { _direction = value; } }
    private Transform _stationDock; public Transform StationDock { get { return _stationDock; } set { _stationDock = value; } }

    private void Awake()
    {
        _spaceShipSpawner = GameObject.FindGameObjectWithTag("SpaceShipSpawner").GetComponent<SpaceShipSpawnerScript>();
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _scoreScript = FindObjectOfType<ScoreScript>();
    }
    private void Start()
    {
        LeanTween.scale(gameObject, Vector2.one * _spaceShipData.Size, _spaceShipData.Speed);
        LeanTween.move(gameObject, _stationDock.position, _spaceShipData.Speed).setOnComplete(SendSignal);
    }

    private void SendSignal()
    {
        StartCoroutine(Signal());
    }

    public void Cannon()
    {
        Instantiate(_destroyParticle, transform.position, transform.rotation);
        CheckAction(0);
        SpawnNewSpaceShip();
    }
    public void Jammer()
    {
        Instantiate(_jammerParticle, transform.position, transform.rotation);
        CheckAction(1);
        Invoke("SpaceCraftLeave", 1f);
    }
    public void Nothing()
    {
        CheckAction(2); 
        SpaceCraftLeave();
    }
    private void SpaceCraftLeave()
    {
        Vector3 targetPosition = new Vector3((_camera.orthographicSize * _camera.aspect + 2f) * _direction, 0f, 0f);
        LeanTween.move(gameObject, targetPosition, _spaceShipData.Speed).setOnComplete(SpawnNewSpaceShip);
    }

    private void CheckAction(int correctAction)
    {
        if ((int)_spaceShipData.SpaceShipType == correctAction) _scoreScript.AddScore();
        else _scoreScript.TakeLife();
    }
    private void SpawnNewSpaceShip()
    {
        _spaceShipSpawner.SpawnSpaceShip();
        Destroy(gameObject);
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
