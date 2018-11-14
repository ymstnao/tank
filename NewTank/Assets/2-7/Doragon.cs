using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Complete;
using System.Linq;

public class Doragon : Character
{
    private Animator anim;// キャラにアタッチされるアニメーターへの参照
    private AnimatorStateInfo currentBaseState;// base layerで使われる、アニメーターの現在の状態の参照

    //sliderObject
    [SerializeField]
    private Slider hpBar;

    [SerializeField]
    private GameObject deathEffect;//死亡時エフェクト

    [SerializeField]
    private HP hp;
    [SerializeField]
    private TestDragon testDragon;
    [SerializeField]
    private float interval = 2f;

    [SerializeField]
    PhotonView view;

    private List<TankHealth> players = new List<TankHealth>();
    private Transform targetTransform;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        hpBar.GetComponent<Slider>();
        hpBar.value = hp.Rate();
        view = GetComponent<PhotonView>();
    }

    private void Init()
    {
        players = GameObject.FindGameObjectsWithTag("Player")
                                       .Select(g => g.GetComponent<TankHealth>())
                                       .ToList();

        var r = Random.Range(0, players.Count);
        targetTransform = players[r].transform;

        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Shot()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            testDragon.ShotPhoton(targetTransform.position);
            targetTransform = RandomPlayerExtraction();

            yield return new WaitForEndOfFrame();
        }
    }

    private void AnimationController()
    {
        anim.speed = animSpeed;// Animatorのモーション再生速度に animSpeedを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
    }

    private Transform RandomPlayerExtraction()
    {
        List<int> indexs = new List<int>();

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].IsDead())
            {
                continue;
            }
            indexs.Add(i);
        }

        var random = Random.Range(0, indexs.Count);

        return players[indexs[random]].transform;
    }

    private void Dead()
    {

        if (hp.IsDaed())
        {


        }
    }
}