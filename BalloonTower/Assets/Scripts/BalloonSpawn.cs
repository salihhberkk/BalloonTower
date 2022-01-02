using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalloonSpawn : MonoSingleton<BalloonSpawn>
{
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform endPoint;
    private Rigidbody rb;

    private void Start()
    {
        rb = spawnPoint.GetComponent<Rigidbody>();
    }
    public void StartBalloonSpawn()
    {
        InvokeRepeating("SpawnBalloon", 1f, 3f);
    }
   
    private void SpawnBalloon()
    {
        var newBalloon = Instantiate(balloonPrefab, spawnPoint.position, Quaternion.identity, gameObject.transform);
        newBalloon.transform.DOScale(Vector3.one, 2f);

        newBalloon.transform.DOMoveY(endPoint.position.y, 1f).OnComplete(() =>
        {
            var joint = newBalloon.AddComponent<SpringJoint>();
            joint.connectedBody = rb;
            joint.anchor = new Vector3(0, -0.5f, 0);
        });
    }
    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
    public Transform GetEndPoint()
    {
        return endPoint;
    }
}
