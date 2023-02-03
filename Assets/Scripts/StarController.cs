using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] GameObject _starPrefab;
    [SerializeField] float _rotationSpeedMultiplier;
    [SerializeField] int _numberOfStars;

    private float _starPositionX = 0;
    private float _starPositionY = 0;


    private void Start()
    {
        for (int i=0; i<_numberOfStars; i++)
        {
            GameObject newStar = SpawnStar();
            SetStarTransform(newStar);
            SetStarVariables(newStar);
        }
    }
    private GameObject SpawnStar()
    {
        _starPositionX = Random.Range(-(_mainCamera.orthographicSize * _mainCamera.aspect), (_mainCamera.orthographicSize * _mainCamera.aspect));
        _starPositionY = Random.Range(-(_mainCamera.orthographicSize * _mainCamera.aspect), (_mainCamera.orthographicSize * _mainCamera.aspect));
        return Instantiate(_starPrefab, transform);
    }
    private void SetStarTransform(GameObject newStar)
    {
        newStar.transform.localPosition = new Vector3(_starPositionX, _starPositionY, 1);
        newStar.transform.localScale = Vector3.one * Random.Range(0.05f, 0.2f);
        newStar.GetComponent<TrailRenderer>().widthMultiplier = newStar.transform.localScale.x*6f;
    }
    private void SetStarVariables(GameObject newStar)
    {
        Rotator newStarRotator = newStar.GetComponent<Rotator>();
        newStarRotator.Center = transform;
        newStarRotator.Speed = (1f - newStar.transform.localScale.x) * _rotationSpeedMultiplier;
    }
}
