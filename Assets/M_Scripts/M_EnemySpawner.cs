using Photon.Pun;
using UnityEngine;

public class M_EnemySpawner : MonoBehaviour
{
    public M_RoomManager roomManager;

    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] float timeDelay = 1f;
    [SerializeField] float timer;

    [SerializeField] int numberOFEnemies = 25;
    public int currentEnemies = 0;
    private void Start()
    {
        roomManager = FindObjectOfType<M_RoomManager>();

        timer = timeDelay;
        currentEnemies = 0;
    }

    void Update()
    {
        if (currentEnemies < numberOFEnemies && PhotonNetwork.IsMasterClient == true)
        {
            Spawning();
            
        }
        
    }

    void Spawning()
    {
        if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount < 2 || !roomManager.haveOnePlayer)
        {
            return;
        }

        if (timer < 0)
        {
            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name, spawnPoint, Quaternion.identity);
            currentEnemies++;
            timer = timeDelay;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
