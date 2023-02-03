using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


    private float _desiredBlurWeight = 1f;
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


    public void OfficeCanvas()
    {
        _officeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
