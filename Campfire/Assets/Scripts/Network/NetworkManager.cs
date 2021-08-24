using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    #region ���� ����
    static bool isOnConnected = false;
    static bool isOnLobby = false;

    public static string GetStatus()
    {
        if (isOnLobby)
            return "isOnLobby";
        else if (isOnConnected)
            return "isOnConnected";
        else
            return "isDisConnected";
    }

    public string Status() => PhotonNetwork.NetworkClientState.ToString();
    #endregion

    #region ���� ����/����
    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster()
    {
        Debug.Log("Photon ���� ���� �Ϸ�");
        isOnConnected = true;
        JoinLobby();
    }

    public void JoinLobby() => PhotonNetwork.JoinLobby();

    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� �Ϸ�");
        isOnLobby = true;
    }

    public void Disconnect() => PhotonNetwork.Disconnect();

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Photon ���� ���� ����");
        isOnLobby = false;
        isOnConnected = false;
    }



    #endregion

    #region ��

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(Random.Range(10, 1000).ToString(), new RoomOptions { MaxPlayers = 4 });
    }

    public void LeaveRoom() => PhotonNetwork.LeaveRoom();

    public void JoinRoom(string RoomName) => PhotonNetwork.JoinRoom(RoomName);

    #endregion

}
