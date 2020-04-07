﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBase : MonoBehaviour
{
    public virtual void Update()
    {
        if (this.transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
