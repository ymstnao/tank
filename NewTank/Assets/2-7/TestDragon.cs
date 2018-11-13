using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDragon : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private Transform muzzle;


    public void Shot(Vector3 targetPosition)
    {
        Vector3 v = targetPosition - muzzle.transform.position;

        GameObject g = Instantiate(fireBall, muzzle.position, Quaternion.identity);

        g.GetComponent<TestFireBall>().Shooting(v.normalized);
    }
}
