using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public int listNumber;
    private bool isCollect = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BalloonHolder"))
        {
            if (isCollect)
                return;
            BalloonMovement.Instance.AddItem(gameObject.transform);
            isCollect = true;
        }
        if (other.CompareTag("Girl"))
        {
            if (isCollect)
                return;
            BalloonMovement.Instance.AddItem(gameObject.transform);
            isCollect = true;
        }
    }
}
