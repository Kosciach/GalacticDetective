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
    [SerializeField] GameObject _decoder;

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


    private void Start()
    {
        _currentInputFieldIndex = 0;
    }


    public void PlayMessage()
    {

    }

    public void AddSymbol(string selectedSymbol)
    {
        if (_currentInputFieldIndex < _inputFields.Length - 1)
        {
            _inputFields[_currentInputFieldIndex].text = selectedSymbol;
            _code += selectedSymbol;
            _currentInputFieldIndex++;
        }
        else if (_currentInputFieldIndex == _inputFields.Length - 1)
            CheckCode();
    }
    public void RemoveSymbol()
    {
        if (_currentInputFieldIndex == 0) return;

        _inputFields[_currentInputFieldIndex].text = "";
        _code.Remove(_code.Length-1);
        _currentInputFieldIndex--;
    }

    private void CheckCode()
    {
        _decoder.SetActive(false);
        if(_code == _receivedCode)
        {
            //show correct data
            WriteData(_correctSpaceShipData);
        }
        else
        {
            //show random data
            int randomSpaceShipIndex = Random.Range(0, _spaceShips.Length-1);
            SpaceShip randomSpaceShip = _spaceShips[randomSpaceShipIndex];
            WriteData(randomSpaceShip);
        }
    }

    private void WriteData(SpaceShip spaceShipData)
    {
        _speed.text = "Speed: " + spaceShipData.Speed.ToString();
        _size.text = "Size: " + spaceShipData.Size.ToString();
        _engine.text = "Engine: " + spaceShipData.EngineType;
        _magneticStrength.text = "MS: " + spaceShipData.MagneticFieldStrength.ToString();
        _noise.text = "Noise: " + spaceShipData.Loudness.ToString();
    }
}
