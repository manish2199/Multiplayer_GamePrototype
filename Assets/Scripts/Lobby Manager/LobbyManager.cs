using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager Instance;

    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;

    public Text roomText;

    public RoomItem roomItem;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject; 

    float NextTimeToUpdate;
    public float TimeBetweenUpdates = 1.5f;

    List<PlayerItem> playerItemList = new List<PlayerItem>();
    public PlayerItem playerItem;
    public Transform playerItemParent;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
       if(roomInputField.text.Length >= 1)
       {
           PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions(){ MaxPlayers = 2});
       }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomText.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    } 

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if( Time.time >= NextTimeToUpdate)
        {
          UpdateRoomList(roomList);
           NextTimeToUpdate = Time.time + TimeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach(RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in roomList)
        {
           RoomItem newRoom = Instantiate(roomItem,contentObject);
           newRoom.SetRoomName(room.Name);
           roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();

        if( PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach(KeyValuePair<int , Player> player in PhotonNetwork.CurrentRoom.Players)
        {
           PlayerItem newplayerItem = Instantiate(playerItem, playerItemParent);
           newplayerItem.SetPlayerInfo(player.Value);
           playerItemList.Add(newplayerItem);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
}
