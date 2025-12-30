using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitEntity : MonoBehaviour
{
    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
