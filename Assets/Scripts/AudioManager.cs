using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("===AudioSources====")]
    [SerializeField] AudioSource _mainMusic;
    [SerializeField] AudioSource _clockMusic;
    [SerializeField] AudioSource _buttonPress;
    [SerializeField] AudioSource _sliderSlide;
    [SerializeField] AudioSource _cannon;
    [SerializeField] AudioSource _jammer;
    [SerializeField] AudioSource _monitor;
    [SerializeField] AudioSource _book;
    [SerializeField] AudioSource _backArrow;
    [SerializeField] AudioSource _guideBookToogle;
    [SerializeField] AudioSource _previousPage;
    [SerializeField] AudioSource _nextPage;

    [Header("===Sliders====")]
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] float _soundVolume;
    [SerializeField] float _musicVolume;
    [SerializeField] string _soundKey;
    [SerializeField] string _musicKey;

    private void Start()
    {
        _soundVolume = 0f;
        if (PlayerPrefs.HasKey(_soundKey)) _soundVolume = PlayerPrefs.GetFloat(_soundKey);
        else PlayerPrefs.SetFloat(_soundKey, _soundVolume);
        _soundSlider.value = _soundVolume;

        _musicVolume = 0f;
        if (PlayerPrefs.HasKey(_musicKey)) _musicVolume = PlayerPrefs.GetFloat(_musicKey);
        else PlayerPrefs.SetFloat(_musicKey, _musicVolume);
        _musicSlider.value = _musicVolume;

        ChangeSoundVolume();
        ChangeMusicVolume();
    }
    public void SoundVolume()
    {
        _soundVolume = _soundSlider.value;
        PlayerPrefs.SetFloat(_soundKey, _soundVolume);
        ChangeSoundVolume();
    }
    public void MusicVolume()
    {
        _musicVolume = _musicSlider.value;
        PlayerPrefs.SetFloat(_musicKey, _musicVolume);
        ChangeMusicVolume();
    }
    private void ChangeSoundVolume()
    {
        _buttonPress.volume = _soundVolume;
        _cannon.volume = _soundVolume;
        _jammer.volume = _soundVolume;
        _monitor.volume = _soundVolume;
        _book.volume = _soundVolume;
        _backArrow.volume = _soundVolume;
        _guideBookToogle.volume = _soundVolume;
        _previousPage.volume = _soundVolume;
        _nextPage.volume = _soundVolume;
    }
    private void ChangeMusicVolume()
    {
        _mainMusic.volume = _musicVolume;
        _clockMusic.volume = _musicVolume;
    }

    public void SwitchMusic(bool mute)
    {
        _mainMusic.mute = !mute;
        _clockMusic.mute = mute;
    }


    public void PlayCannon()
    {
        _cannon.Play();
    }
    public void PlayJammer()
    {
        _jammer.Play();
    }

    public void PlayPreviousPage()
    {
        _previousPage.Play();
    }
    public void PlayNextPage()
    {
        _nextPage.Play();
    }
}
