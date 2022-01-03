using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{

    public enum Type { App };
    public Type type;
    public float rate;
    public BoxCollider pushArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        StopCoroutine("Push");
        StartCoroutine("Push");
    }

    IEnumerator Push()
    {
        yield return new WaitForSeconds(0.1f);
        pushArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.3f);
        pushArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;
    }
}
