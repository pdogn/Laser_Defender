using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Hastable = ExitGames.Client.Photon.Hashtable;

public class M_RoomManager : MonoBehaviourPunCallbacks
{
    //public static M_RoomManager instance;

    public GameObject player;
    public Transform spawnPoint;

    //[SerializeField] TextMeshProUGUI heal1;
    //[SerializeField] TextMeshProUGUI heal2;

    //public M_PlayerSetup[] players;

    // Start is called before the first frame update

    [Space]
    public GameObject roomCam;

    [Space]
    public GameObject nameUI;

    [Space]
    public GameObject leaderBoard;

    public TMP_InputField nameInput;

    public string nickName = "unnamed";

    public bool haveOnePlayer;

    public int score = 0;


    //public string roomNameToJoin = "test";

    //GameObject x;

    ////private void Awake()
    ////{
    ////    instance = this;
    ////}

    void Start()
    {
        //players = FindObjectsOfType<M_PlayerSetup>();
        //PhotonNetwork.ConnectUsingSettings();
        //SpawnPlayer();
        nameUI.SetActive(true);
        haveOnePlayer = false;
    }


    //public override void OnConnectedToMaster()
    //{
    //    base.OnConnectedToMaster();

    //    Debug.Log("Connected to sever");
    //    PhotonNetwork.JoinLobby();
    //}

    //public override void OnJoinedLobby()
    //{
    //    base.OnJoinedLobby();

    //    Debug.Log("We're in the lobby");
    //    PhotonNetwork.JoinOrCreateRoom("test", null, null);
    //}

    //public override void OnJoinedRoom()
    //{
    //    base.OnJoinedRoom();

    //    Debug.Log("We're in a room now");

    //    GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    //    _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    //}

    //public void ChangeNickname(string _name)
    //{
    //    nickName = _name;
    //}
    bool x = false;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            x = !x;
            leaderBoard.SetActive(x);
        }
    }


    public void ChooseNameButtonPressed()
    {
        //Debug.Log("connecting...");

        //PhotonNetwork.ConnectUsingSettings();
        nickName = nameInput.text;
        
        //connectingUi.SetActive(true);

        SpawnPlayer();

        nameUI.SetActive(false);
        roomCam.SetActive(false);
        //leaderBoard.SetActive(true);
        haveOnePlayer = true;
    }


    ////public override void OnConnectedToMaster()
    ////{
    ////    base.OnConnectedToMaster();

    ////    PhotonNetwork.JoinLobby();
    ////}

    ////public override void OnJoinedLobby()
    ////{
    ////    base.OnJoinedLobby();

    ////    PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, null, null);
    ////}

    ////public override void OnJoinedRoom()
    ////{
    ////    base.OnJoinedRoom();

    ////    SpawnPlayer();
    ////}

    public GameObject enemy;
    public void SpawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponentInChildren<M_PlayerSetup>().IsLocalPlayer();

        GameObject _enemy = PhotonNetwork.Instantiate(enemy.name, spawnPoint.position + Vector3.right * 3f, Quaternion.identity);

        var x = _player.GetComponentInChildren<M_PlayerSetup>().gameObject;
        //Debug.Log(x.name+"AAAA");
        x.GetComponentInChildren<PhotonView>().RPC("SetNickname", RpcTarget.AllBuffered, nickName);
        PhotonNetwork.LocalPlayer.NickName = nickName;
        
    }


    public void SetHashes()
    {
        try
        {
            Hastable hash = PhotonNetwork.LocalPlayer.CustomProperties;

            //hash["kills"] = kills;
            //hash["deaths"] = deaths;

            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
        catch
        {
            //do nothing
        }
    }


}
