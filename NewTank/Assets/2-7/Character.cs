﻿using UnityEngine;

//必要なものをオブジェクトにつける
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour {
    [SerializeField]
    protected float animSpeed = 1.5f;// アニメーション再生速度設定
    [SerializeField]
    private float lookSmoother = 3.0f;// a smoothing setting for camera motion
    // 以下キャラクターコントローラ用パラメタ
    // 動く速度
    [SerializeField]
    private float moveSpeed = 10.0f;
    // 旋回速度
    [SerializeField]
    private float rotateSpeed = 2.0f;
    //落下速度
    [SerializeField]
    private float ForceGravity = 100.0f;
    private Rigidbody rb;
    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    
    //攻撃力
    [SerializeField]
    protected float attackPower=10;
   
    
    //初期化
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public virtual void Move(Vector3 velocity)
    {
        if (velocity.magnitude > 0.01)
        {
            transform.rotation = Quaternion.LookRotation(velocity);
        }

        velocity *= moveSpeed;// 移動速度を掛ける

        // 上下のキー入力でキャラクターを移動させる
        transform.Translate(velocity * Time.fixedDeltaTime, Space.World);


        //高いところからの落下速度が不自然に見えないように
        if (rb.useGravity)
        {
            rb.AddForce(Vector3.down * ForceGravity, ForceMode.Acceleration);
        }

    }
}
