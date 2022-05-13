using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomItem : MonoBehaviour
{
   public Text roomName;

   public void SetRoomName(string roomName)
   {
      this.roomName.text = roomName;
   }

   public void OnClickItem()
   {
       LobbyManager.Instance.JoinRoom(roomName.text);
   }
}
