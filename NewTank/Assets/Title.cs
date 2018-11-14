using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	AudioSource audio;//サウンド

	[SerializeField] private AudioClip TitleSelectSE_1;//タイトル決定SE_1
	private bool isSelectFlag;//タイトル決定判定

	[SerializeField] private string mainScene;

	// Use this for initialization
	void Start()
	{
		audio = gameObject.GetComponent<AudioSource>();
		GetComponent<AudioSource>().clip = null;//一応
	}

	// Update is called once per frame
	void Update()
	{
			TitleSelect();//タイトル決定処理

		if (isSelectFlag)
			TitleSceneSelect();
	}

	private void TitleSelect()
	{
		if (isSelectFlag)
			return;//押されている場合は処理を行わない

		if (Input.GetKey (KeyCode.Space)) {//決定キーが押下されたら
			GetComponent<AudioSource> ().PlayOneShot (TitleSelectSE_1);//SEを鳴らす

			isSelectFlag = true;//タイトル決定処理終了
		}
	}

	private void TitleSceneSelect()
	{
		SceneManager.LoadScene (mainScene);
	}
}