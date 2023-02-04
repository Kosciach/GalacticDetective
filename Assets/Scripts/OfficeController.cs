using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeController : MonoBehaviour
{
    [SerializeField] GameObject[] _screens;
    [SerializeField] GameObject _buttons;
    [SerializeField] GameObject _mainCanvas;

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
        _mainCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Cannon()
    {

        ExitOffice();
    }
    public void Jammer()
    {

        ExitOffice();
    }
    public void Nothing()
    {

        ExitOffice();
    }
}
