using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookInfoWriter : MonoBehaviour
{
    [SerializeField] SpaceShip _spaceShipData;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _speed;
    [SerializeField] TextMeshProUGUI _size;
    [SerializeField] TextMeshProUGUI _engineType;
    [SerializeField] TextMeshProUGUI _magneticFieldStrength;
    [SerializeField] TextMeshProUGUI _loudness;

    private void Start()
    {
        GetTexts();
        SetText();
    }

    private void GetTexts()
    {
        _name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _speed = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _size = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _engineType = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _magneticFieldStrength = transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        _loudness = transform.GetChild(5).GetComponent<TextMeshProUGUI>();
    }

    private void SetText()
    {
        _name.text = _spaceShipData.Name;
        _speed.text = "Speed: " + (_spaceShipData.Speed * 1000).ToString();
        _size.text = "Size: " + (_spaceShipData.Size * 200).ToString();
        _engineType.text = "Engine: " + _spaceShipData.EngineType;
        _magneticFieldStrength.text = "MS: " + _spaceShipData.MagneticFieldStrength.ToString();
        _loudness.text = "Noise: " + _spaceShipData.Loudness.ToString();
    }
}
