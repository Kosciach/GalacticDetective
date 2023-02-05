using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBookController : MonoBehaviour
{
    [SerializeField] GameObject _mainCanvas;
    [SerializeField] GameObject _guideBookOpened;
    [SerializeField] GameObject[] _pages;
    [SerializeField] int _currentPage;
    [SerializeField] AudioManager _audioManager;

    public void SwitchBook(bool isOpened)
    {
        _currentPage = 0;
        _mainCanvas.SetActive(!isOpened);
        _guideBookOpened.SetActive(isOpened);
    }

    public void NextPage()
    {
        if (_currentPage == _pages.Length - 1) return;

        _audioManager.PlayNextPage();
        _currentPage++;
        _pages[_currentPage - 1].SetActive(false);
        _pages[_currentPage].SetActive(true);
    }
    public void PreviousPage()
    {
        if (_currentPage == 0) return;

        _audioManager.PlayPreviousPage();
        _currentPage--;
        _pages[_currentPage + 1].SetActive(false);
        _pages[_currentPage].SetActive(true);
    }
}
