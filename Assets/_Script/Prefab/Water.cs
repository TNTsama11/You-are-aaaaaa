using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : PrefabBase
{
    
    public override void Update()
    {
        base.Update();

    }

    IEnumerator WaterDisappear()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            StartCoroutine(WaterDisappear());
        }
    }
}
