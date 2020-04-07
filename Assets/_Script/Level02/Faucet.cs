using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faucet : MonoBehaviour
{
    public GameObject waterPfb;
    public float time = 1f;
    private bool isDripping;

    private void Start()
    {
    }

    public void FaucetOn()
    {
        isDripping = true;
        StartCoroutine(Dripping());
    }

    public void FauectOff()
    {
        isDripping = false
;    }

    IEnumerator Dripping()
    {
        while (isDripping)
        {
            yield return new WaitForSeconds(time);
            Instantiate(waterPfb, this.transform.position, Quaternion.identity);
        }
    }

}
