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
    private HP hp;
    [SerializeField]
    private TestDragon testDragon;
    [SerializeField]
    private float interval = 2f;


    private List<TankHealth> players = new List<TankHealth>();
    private Transform targetPlayer;

    // アニメーター各ステートへの参照
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int runState = Animator.StringToHash("Base Layer.Run");
    static int attackState = Animator.StringToHash("Base Layer.Attack");

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();
        hpBar.GetComponent<Slider>();
        hpBar.value = hp.Rate();
        
    }

    private void Init()
    {
        players = GameObject.FindGameObjectsWithTag("Player")
                                       .Select(g => g.GetComponent<TankHealth>())
                                       .ToList();

        var r = Random.Range(0, players.Count);
        targetPlayer = players[r].transform;

        StartCoroutine(Shot());
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(targetPlayer);
        //AnimationController();
        hpBar.value = hp.Rate();
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            testDragon.Shot(targetPlayer.position);

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