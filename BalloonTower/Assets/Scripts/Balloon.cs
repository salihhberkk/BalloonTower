using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] private List<Material> colors = new List<Material>();

    private int randomColor;
    private MeshRenderer mesh;

    private LineRenderer line;

    private Vector3 lineStartPos;
    private Vector3 lineEndPos;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = true;
        mesh = gameObject.GetComponent<MeshRenderer>();
        randomColor = Random.Range(0, colors.Count);

        mesh.material = colors[randomColor];
    }
    private void Update()
    {
        lineStartPos = BalloonSpawn.Instance.GetSpawnPoint().position;
        line.SetPosition(0, lineStartPos);

        lineEndPos = gameObject.transform.position;
        line.SetPosition(1, lineEndPos);
    }
}
