using UnityEngine;
using System.Collections;

public class NetWork01 : MonoBehaviour
{
	void Start()
	{
		// Photonに接続する(引数でゲームのバージョンを指定できる)
		PhotonNetwork.ConnectUsingSettings(null);
	}

	// ロビーに入ると呼ばれる
	void OnJoinedLobby()
	{

		RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, TypedLobby.Default);
        // 部屋に参加、存在しない時作成して参加
		
		// Debug.Log("ロビーに入りました。");

		// // ルームに入室する
		// PhotonNetwork.JoinRandomRoom();
	}

	// ルームに入室すると呼ばれる
	void OnJoinedRoom()
	{
		Debug.Log("ルームへ入室しました。");
		//   Vector3 pos;
        // pos = spawnPoint.position;
        // GameObject obj = PhotonNetwork.Instantiate(player.name, pos, Quaternion.identity, 0);
        // GetComponent<Camera>().transform.position = pos + cameraOffset;
        // GetComponent<Camera>().transform.parent = obj.transform;

        // if (PhotonNetwork.isMasterClient)
        //     PhotonNetwork.InstantiateSceneObject(gameManager.name, Vector3.zero, Quaternion.identity, 0, null);
	}

	// ルームの入室に失敗すると呼ばれる
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("ルームの入室に失敗しました。");

		// ルームがないと入室に失敗するため、その時は自分で作る
		// 引数でルーム名を指定できる
		PhotonNetwork.CreateRoom("myRoomName");
	}
}