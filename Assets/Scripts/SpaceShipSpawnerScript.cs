using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipSpawnerScript : MonoBehaviour
{
    [SerializeField] Transform _stationDock;
    [SerializeField] GameObject[] _spaceShips;
    [SerializeField] Transform[] _spawnPoints;

    public void SpawnSpaceShip()
    {
        int spaceShipType = Random.Range(0, _spaceShips.Length);
        int spawnPointIndex = Random.Range(0, _spawnPoints.Length);
        GameObject newSpaceShip = Instantiate(_spaceShips[spaceShipType], _spawnPoints[spawnPointIndex].position, Quaternion.identity);
        newSpaceShip.transform.rotation = Quaternion.Euler(0f, spawnPointIndex * 180f, 0f);
        newSpaceShip.GetComponent<SpaceShipController>().StationDock = _stationDock;
    }

}
