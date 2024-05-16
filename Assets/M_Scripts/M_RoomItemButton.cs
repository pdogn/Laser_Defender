using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_RoomItemButton : MonoBehaviour
{

    public string RoomName;

    public void OnButtonPressed()
    {
        M_RoomList.ins.JoinRoomByName(RoomName);
    }
}
