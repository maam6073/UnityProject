using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 1) 발급받은 id로 마스터 서버에 접속
 * 2) 첫번째 join버튼을 누른 접속자가 방을 만들고 Main씬으로 전환
 * 3) 나머지 join버튼을 누른 접속자는 자동으로 방에 들어가고 Main씬으로 전환
 */

public class csLobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";

    public Text connectionInfoText; // 접속상태 정보 보이기
    public Button joinButton;       // 게임방으로 진입 

    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;

        // 마스터 서버에 접속 시도
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;

        connectionInfoText.text = "마스터 서버에 접속 중...";
    }

    // 마스터 서버에 접속되었다면
    public override void OnConnectedToMaster()
    {
        // 버튼 활성화
        joinButton.interactable = true;

        connectionInfoText.text = "온라인 : 마스터 서버와 연결됨";
    }

    // 마스터 서버에 접속시도했는데 접속이 안되었다면
    public override void OnDisconnected(DisconnectCause cause)
    {
        // 버튼 비활성화
        joinButton.interactable = false;
        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";

        // 다시 마스터 서버에 접속 시도
        PhotonNetwork.ConnectUsingSettings();
    }

    // Join 버튼을 누르면 호출되는 함수
    public void Connect()
    {
        joinButton.interactable = false;

        // 마스터 서버와 연결되어 있다면
        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "룸에 접속...";
            // 룸에 접속을 시도한다
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";
            // 마스터 서버에 접속
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // 첫번째 접속자가 방에 들어가려고 했으나 방이 없어서 방을 만든다
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "빈 방이 없음, 새로운 방 생성...";

        // 20명 접속가능
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }

    // 방 참가 성공
    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "방 참가 성공";
        //PhotonNetwork.LoadLevel("02.Main");

        // 씬 전환
        PhotonNetwork.LoadLevel("02.UnityProject");
    }
}
