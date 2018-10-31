using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour, IDamagable
{
    [SerializeField]
    private float currnetHP;
    [SerializeField]
    private float maxHP;

    // Use this for initialization
    void Start()
    {

    }

    public void Damage(float damage)
    {
        currnetHP -= damage;
    }

    public void Recover(float recover)
    {
        currnetHP += recover;
    }

    public void Death()
    {
        currnetHP = 0;
    }

    public bool IsDaed()
    {
        return currnetHP <= 0;
    }

    public float CurrentHP
    {
        get
        {
            return currnetHP;
        }
    }
}
