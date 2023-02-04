using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [Header("====Decoding====")]
    [SerializeField] TextMeshProUGUI[] _inputFields;
    [SerializeField] string _code;
    [SerializeField] string _receivedCode; public string ReceivedCode { get { return _receivedCode; } set { _receivedCode = value; } }
    [SerializeField] string _receivedIntCode; public string ReceivedIntCode { get { return _receivedIntCode; } set { _receivedIntCode = value; } }
    [SerializeField] GameObject _decoder;
    [SerializeField] GameObject _spyDot;

    [Header("====DataFields====")]
    [SerializeField] TextMeshProUGUI _speed;
    [SerializeField] TextMeshProUGUI _size;
    [SerializeField] TextMeshProUGUI _engine;
    [SerializeField] TextMeshProUGUI _magneticStrength;
    [SerializeField] TextMeshProUGUI _noise;

    [Header("====SpaceShipsData====")]
    [SerializeField] SpaceShip[] _spaceShips;
    [SerializeField] SpaceShip _correctSpaceShipData; public SpaceShip CorrectSpaceShipData { get { return _correctSpaceShipData; } set { _correctSpaceShipData = value; } }
    [SerializeField] int _currentInputFieldIndex;

    [Header("====Audio====")]
    [SerializeField] AudioClip[] _audioClips;
    [SerializeField] AudioSource _audioSource;
    private int _currentAutoIndex;
    private int _audioCodeIndex;

    private void Start()
    {
        _currentInputFieldIndex = 0;
    }

    public void AddSymbol(string selectedSymbol)
    {
        _inputFields[_currentInputFieldIndex].text = selectedSymbol;
        _code += selectedSymbol;
        _currentInputFieldIndex++;
        if (_currentInputFieldIndex == _inputFields.Length)
            CheckCode();
    }
    public void RemoveSymbol()
    {
        _inputFields[_currentInputFieldIndex].text = "";
        _code.Remove(_code.Length-1);
        _currentInputFieldIndex--;
    }
    public void ResetMonitor()
    {
        _code = "";
        _currentInputFieldIndex = 0;
        foreach (TextMeshProUGUI inputField in _inputFields) inputField.text = "";
        _decoder.SetActive(true);

        _speed.text = "Speed: ";
        _size.text = "Size: ";
        _engine.text = "Engine: ";
        _magneticStrength.text = "MS: ";
        _noise.text = "Noise: ";
    }
    private void CheckCode()
    {
        StopAllCoroutines();
        _audioSource.mute = true;
        _decoder.SetActive(false);
        Debug.Log(_code);
        if (_code == _receivedCode)
        {
            if ((int)_correctSpaceShipData.SpaceShipType == 1) _spyDot.SetActive(true);
            WriteData(_correctSpaceShipData);
        }
        else
        {
            int randomSpaceShipIndex = Random.Range(0, _spaceShips.Length - 1);
            SpaceShip randomSpaceShip = _spaceShips[randomSpaceShipIndex];
            WriteData(randomSpaceShip);
        }

    }

    private void WriteData(SpaceShip spaceShipData)
    {
        _speed.text = "Speed: " + (spaceShipData.Speed * 1000).ToString();
        _size.text = "Size: " + (spaceShipData.Size * 200).ToString();
        _engine.text = "Engine: " + spaceShipData.EngineType;
        _magneticStrength.text = "MS: " + spaceShipData.MagneticFieldStrength.ToString();
        _noise.text = "Noise: " + spaceShipData.Loudness.ToString();


    }


    public void PlayMessage()
    {
        StopCoroutine(StartMessage());

        PlayMessageAudio(0);
        StartCoroutine(StartMessage());
    }

    IEnumerator StartMessage()
    {
        for (int i = 1; i < 6; i++)
        {
            yield return new WaitForSeconds(_audioSource.clip.length + 2);
            PlayMessageAudio(i);
        }
    }
    private void PlayMessageAudio(int i)
    {
        _currentAutoIndex = i;
        _audioCodeIndex = int.Parse(_receivedIntCode[_currentAutoIndex].ToString());
        _audioSource.clip = _audioClips[_audioCodeIndex];
        _audioSource.Play();
    }


    private void OnEnable()
    {
        _audioSource.mute = false;
        _spyDot.SetActive(false);
    }
}
