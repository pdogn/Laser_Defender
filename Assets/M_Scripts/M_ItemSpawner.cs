using Photon.Pun;
using UnityEngine;

public class M_ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject item;
    public float timeDL = 5;
    float time;

    public float currentItem = 0;

    private void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem < 25 && PhotonNetwork.IsMasterClient == true)
        {
            ItemSpawn();

        }
    }

    void ItemSpawn()
    {
        if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount < 2)
        {
            return;
        }

        time += Time.deltaTime;
        if(time >= timeDL)
        {
            
            float pX = Random.Range(-10, 10);
            float pY = Random.Range(-10, 10);
            Vector2 spawnPoint = new Vector2(pX, pY);

            PhotonNetwork.Instantiate(item.name, spawnPoint, Quaternion.identity);

            currentItem++;

            time = 0;

        }
        else
        {
            time += Time.deltaTime;
        }
    }
}
