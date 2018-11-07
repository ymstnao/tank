using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton
{

	[SerializeField, Tooltip("一日の時間（ｓ）")]
	float dayTime = 300.0f;
	float dayTimeCount = 0;

	PhotonView view;

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

	void DaysUpdate()
	{
	}

	[PunRPC]
	private void RPCDayUpdate()
	{
		//UIManager.Instance.AddProgressDays();
	}
}

