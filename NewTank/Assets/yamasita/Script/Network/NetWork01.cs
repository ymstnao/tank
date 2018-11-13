using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetWork01 : MonoBehaviour
{

	[SerializeField]
	Text textStatus;
	[SerializeField]
	GameObject player;
	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	GameObject gameManager;

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
		Vector3 pos;
		pos = spawnPoint.position;
		GameObject obj = PhotonNetwork.Instantiate(player.name, pos, Quaternion.identity, 0);
		if (PhotonNetwork.isMasterClient)
		{
			PhotonNetwork.InstantiateSceneObject(gameManager.name, Vector3.zero, Quaternion.identity, 0, null);
		}

	}


	void Update()
	{
		if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined")
		{
			Debug.Log(PhotonNetwork.connectionStateDetailed.ToString());
			//textStatus.text = PhotonNetwork.connectionStateDetailed.ToString();
		}
		//else
		// textStatus.text = "Connect to the room" + PhotonNetwork.room.Name
		// 	+ "Players Online" + PhotonNetwork.room.PlayerCount
		// 	+ "Master: " + PhotonNetwork.isMasterClient;
	}
}