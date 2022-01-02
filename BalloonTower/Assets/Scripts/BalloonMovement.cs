using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class BalloonMovement : MonoSingleton<BalloonMovement>
{
    [SerializeField] float speed;
    [SerializeField] float swipeSensitivity;

    private bool move = false;

    [SerializeField] private float distance = 0f;

    private List<Transform> items = new List<Transform>();
    private int itemCounter = 0;
    public void StartHandlePlayer()
    {
        LeanTouch.OnFingerUpdate += HandlePlayer;
        IsMove = true;
    }
    public void StopHandlePlayer()
    {
        LeanTouch.OnFingerUpdate -= HandlePlayer;
        IsMove = false;
    }
    public bool IsMove
    {
        get => move;
        set
        {
            move = value;
        }
    }
    void FixedUpdate()
    {
        if (move)
        {
            transform.Translate(Vector3.forward * speed);
            FollowObject();
        }
    }
    public void FollowObject()
    {
        if (items.Count != 0)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].DOMoveX(gameObject.transform.position.x, (float)i / 5);
            }
        }
    }
    public void AddItem(Transform newItem)
    {
        var spawnPoint = BalloonSpawn.Instance.GetSpawnPoint();

        newItem.rotation = Quaternion.identity;
        newItem.GetComponent<Girl>().listNumber = itemCounter;
        itemCounter++;

        newItem.transform.SetParent(gameObject.transform);
        newItem.transform.position = new Vector3(spawnPoint.position.x
            , spawnPoint.position.y + distance
                , spawnPoint.position.z);
        items.Add(newItem);
        distance -= 1f;

        gameObject.transform.DOMoveY(gameObject.transform.position.y + 1f , 0.5f);
        CameraMovement.Instance.SetOffset();

    }
    private void HandlePlayer(LeanFinger obj)
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.transform.position += Vector3.right * (obj.ScaledDelta.x * swipeSensitivity);
            var clampXPos = Mathf.Clamp(gameObject.transform.position.x, -2.5f, 5);
            gameObject.transform.position = new Vector3(clampXPos, gameObject.transform.position.y,
                  gameObject.transform.position.z);
        }
    }
}
