using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class GamePlayManager : Singleton
{

	private PhotonView view;

	[SerializeField]
	private GameObject cameraControl;

	private bool cameraUpdate;

	public new static GamePlayManager Instance
	{
		get;
		private set;
	}

	private void SetInstance()
	{
		if (Instance == null)
		{
			Instance = (GamePlayManager)this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Awake()
	{
		SetInstance();
	}

	// Use this for initialization
	void Start()
	{
		view = GetComponent<PhotonView>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!view.isMine)
			return;
	}

	public void CameraUpdate()
	{
		cameraUpdate = true;
	}


	void DaysUpdate()
	{
	}

	[PunRPC]
	private void RPCDayUpdate()
	{
		//UIManager.Instance.AddProgressDays();
	}
}

