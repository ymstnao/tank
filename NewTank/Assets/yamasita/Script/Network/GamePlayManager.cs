using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : Singleton
{
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
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void CameraUpdate()
	{
		cameraUpdate = true;
	}


	void DaysUpdate()
	{
	}


}

