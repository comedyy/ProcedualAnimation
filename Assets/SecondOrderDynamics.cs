using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondOrderDynamics : MonoBehaviour
{
    Vector3 xp;
    Vector3 y, yd;
    public float f, z, r;
    public Transform target;

    float k1, k2, k3;


    // Start is called before the first frame update
    void Start()
    {
        xp = target.position;
        y = target.position;
        yd = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        k1 = z / (Mathf.PI * f);
        k2 = 1 / ((2 * Mathf.PI * f) * (2 * Mathf.PI * f));
        k3 = r * z  / (2 * Mathf.PI * f);


        var T = Time.deltaTime;
        var x = target.position;
        var xd = (x - xp) / T;
        xp = x;

        float K2_stable = Mathf.Max(k2, 1.1f * (T * T / 4f + T * k1 / 2f));
        y = y + T * yd;
        yd = yd + T * (x + k3 * xd - y - k1 * yd) / K2_stable;

        transform.position = y;
    }
}
