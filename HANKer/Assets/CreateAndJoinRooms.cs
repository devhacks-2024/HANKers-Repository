using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;



public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;


    //craete a room 
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);

    }

    //join a room
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    //once we join a room
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Nathan-Sandbox");
    }
}
