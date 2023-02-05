using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OfficeController : MonoBehaviour
{
    [SerializeField] GameObject[] _screens;
    [SerializeField] GameObject _buttons;
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] SpaceShipSpawnerScript _spaceShipSpawner;
    [SerializeField] AudioManager _audioManager;
    [SerializeField] RectTransform _clockValue;
    [SerializeField] Image _isPlayingIndicator;
    [SerializeField] float _time; public float Time { get { return _time; } }

    public void SwitchScreenOn(GameObject selectedScreen)
    {
        selectedScreen.SetActive(true);
        _buttons.SetActive(false);
    }

    public void ExitScreen()
    {
        foreach (GameObject screen in _screens) screen.SetActive(false);
        _buttons.SetActive(true);
    }
    private void ExitOffice()
    {
        StopAllCoroutines();
        _isPlayingIndicator.color = new Color(1f, 0.01143568f, 0f, 0.4666667f);
        _audioManager.SwitchMusic(true);

        GameObject currentSpaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        currentSpaceShip.layer = LayerMask.NameToLayer("Foreground");
        currentSpaceShip.GetComponent<SpriteRenderer>().enabled = true;
        currentSpaceShip.transform.GetChild(0).gameObject.SetActive(false);

        _screens[0].SetActive(false);
        _screens[1].SetActive(false);
        _buttons.SetActive(true);
        _mainCanvas.SetActive(true);
        gameObject.SetActive(false);
        _clockValue.sizeDelta = new Vector2(162.015f, 59.671f);
        if(_time > 5f) _time -= 2f;
        LeanTween.cancelAll();
    }

    public void Cannon()
    {
        GameObject[] spaceShipControllers = GameObject.FindGameObjectsWithTag("SpaceShip");
        foreach (GameObject spaceShipController in spaceShipControllers)
            spaceShipController.GetComponent<SpaceShipController>().Cannon();
        _audioManager.PlayCannon();
        ExitOffice();
    }
    public void Jammer()
    {
        GameObject[] spaceShipControllers = GameObject.FindGameObjectsWithTag("SpaceShip");
        foreach (GameObject spaceShipController in spaceShipControllers)
            spaceShipController.GetComponent<SpaceShipController>().Jammer();
        _audioManager.PlayJammer();
        ExitOffice();
    }
    public void Nothing()
    {
        GameObject[] spaceShipControllers = GameObject.FindGameObjectsWithTag("SpaceShip");
        foreach (GameObject spaceShipController in spaceShipControllers)
            spaceShipController.GetComponent<SpaceShipController>().Nothing();
        ExitOffice();
    }

    public void LeaveGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
    private void TimeEnd()
    {
        int actionType = Random.Range(0, 3);
        if (actionType == 0) Cannon();
        else if (actionType == 1) Jammer();
        else if (actionType == 2) Nothing();
    }
    private void OnEnable()
    {
        LeanTween.size(_clockValue, new Vector2(0f, 59.671f), _time).setOnComplete(TimeEnd);
    }
}
