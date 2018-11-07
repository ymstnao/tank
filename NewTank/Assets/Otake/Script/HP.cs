using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour, IDamagable
{
    private float currnetHP;
    [SerializeField]
    private float maxHP;

    // Use this for initialization
    void Start()
    {
        currnetHP = maxHP;
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

    public float Rate() {
        var r = (float)currnetHP / (float)maxHP;
        return Mathf.Lerp(0, 1, r);
    }

    public float CurrentHP
    {
        get
        {
            return currnetHP;
        }
    }
}
