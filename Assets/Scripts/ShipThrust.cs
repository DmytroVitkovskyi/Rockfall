using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipThrust : MonoBehaviour
{
    public float speed = 5.0f;

    // ѕеремещает корабль вперед с посто€нной скоростью
    void Update()
    {
        var offset = Vector3.forward * Time.deltaTime * speed;
        this.transform.Translate(offset);
    }
}
