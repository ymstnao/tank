using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDragon : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBall;
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void ShotPhoton(Vector3 targetPosition)
    {
        view.RPC("Shot", PhotonTargets.All, targetPosition);
    }

    [PunRPC]
    private void Shot(Vector3 targetPosition)
    {
        Vector3 v = targetPosition - muzzle.transform.position;

        GameObject g = PhotonNetwork.Instantiate(fireBall.name, muzzle.position, Quaternion.identity, 0);

        g.GetComponent<TestFireBall>().Shooting(v.normalized);
    }
}
