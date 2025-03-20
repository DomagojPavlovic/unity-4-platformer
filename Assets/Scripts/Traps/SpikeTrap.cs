using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Trap
{
    [SerializeField]
    private GameObject hitbox;

    [SerializeField]
    private float spikeUpTime;

    [SerializeField]
    private float spikeDownTime;

    private Vector3 beginPos;
    private Vector3 endPos;

    public void Start()
    {
        beginPos = transform.position;
        endPos = beginPos + new Vector3(0, 1, 0);
    }

    public override void Activate()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        StartCoroutine(MoveSpikes(beginPos, endPos, spikeUpTime));
    }

    public override void Deactivate()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        StartCoroutine(MoveSpikes(endPos, beginPos, spikeDownTime));
    }

    IEnumerator MoveSpikes(Vector3 beginPos, Vector3 endPos, float time)
    {
        for (float t = 0; t < 1; t += Time.deltaTime / time)
        {
            hitbox.transform.position = Vector3.Lerp(beginPos, endPos, t);
            yield return null;
        }
    }
}
