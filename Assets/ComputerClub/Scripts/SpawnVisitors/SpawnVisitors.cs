using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpawnVisitors : MonoBehaviour
{
    [SerializeField] private Visitor _visitor;
    [SerializeField] private Interior _interiorBonus;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private AdminQueue _adminQueue;

    private float _elapsedTimeOfLastSpawned;
    private float _spawnTime;
    private float _startTimeSpawn = 2;
    private float _startNumberOfComputers = 5;
    private int _spawnVisitorCount;
    private bool _isStartSpawning;

    private void Start()
    {
        if (PlayerPrefs.HasKey("startSpawn"))
            StartSpawn();
    }

    private void Update()
    {
        if (_isStartSpawning)
        {
            _elapsedTimeOfLastSpawned += Time.deltaTime;

            if (_elapsedTimeOfLastSpawned >= _spawnTime)
            {
                StartCoroutine(Spawn());
                CalculateSpawnTime();

                _elapsedTimeOfLastSpawned = 0;
            }
        }
    }

    private IEnumerator Spawn()
    {
        _spawnVisitorCount = Random.Range(2, 6);

        for (int i = 0; i < _spawnVisitorCount; i++)
        {
            Visitor v = Instantiate(_visitor, _spawnPosition, new Quaternion(0, 180, 0, 0));
            v.GetComponent<StartVisitorMovement>().Init(_adminQueue);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void CalculateSpawnTime()
    {
        _spawnTime = _startTimeSpawn * _startNumberOfComputers / _interiorBonus.GetCurrentInteriorBonus();
    }

    public void StartSpawn()
    {
        _isStartSpawning = true;

        CalculateSpawnTime();
        _elapsedTimeOfLastSpawned = _spawnTime;
    }
}
