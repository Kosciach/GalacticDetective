using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MenuController : MonoBehaviour
{
    [SerializeField] SpaceShipSpawnerScript _spaceShipSpawner;

    [Header("====Menu====")]
    [SerializeField] Volume _blur;
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] GameObject[] _screens;

    [Header("====Office====")]
    [SerializeField] GameObject _officeCanvas;
    [SerializeField] MonitorController _monitorController;
    [SerializeField] char[] _symbols;

    private float _desiredBlurWeight = 1f;
    private bool _isStarted;

    private void Start()
    {
        _spaceShipSpawner.gameObject.SetActive(false);
    }
    private void Update()
    {
        _blur.weight = Mathf.Lerp(_blur.weight, _desiredBlurWeight, 1f * Time.deltaTime);
    }

    public void StartButton()
    {
        if (_isStarted) return;

        _isStarted = true;
        _desiredBlurWeight = 0f;
        LeanTween.alphaCanvas(_canvasGroup, 0f, 1f).setOnComplete(ProperStart);
    }
    private void ProperStart()
    {
        foreach (GameObject screen in _screens) screen.SetActive(false);
        _spaceShipSpawner.gameObject.SetActive(true);
        _spaceShipSpawner.SpawnSpaceShip();
    }
    public void SwitchScreen(GameObject selectedScreen)
    {
        foreach (GameObject screen in _screens) screen.SetActive(false);
        selectedScreen.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();
    }


    public void OfficeCanvas(SpaceShip spaceShipData)
    {
        _monitorController.ReceivedCode = GenerateCode();
        _monitorController.CorrectSpaceShipData = spaceShipData;
        _monitorController.ResetMonitor();
        _officeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    private string GenerateCode()
    {
        string generatedCode = "";
        string generatedIntCode = "";
        int randomSymbolIndex = 0;
        for (int i = 0; i < 6; i++)
        {
            randomSymbolIndex = Random.Range(0, _symbols.Length);
            generatedCode += _symbols[randomSymbolIndex];
            generatedIntCode += randomSymbolIndex.ToString();
        }
        _monitorController.ReceivedIntCode = generatedIntCode;
        return generatedCode;
    }
    private void OnEnable()
    {
        _isStarted = false;
    }
}
