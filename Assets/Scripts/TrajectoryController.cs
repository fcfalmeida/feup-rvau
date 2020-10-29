using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/Biebras/Unity-3D-Trajectoryv-Prediction/tree/master
public class TrajectoryController : MonoBehaviour
{
    [Header("Line renderer veriables")]
    public LineRenderer line;
    [Range(2, 30)]
    public int resolution;

    [Header("Formula variables")]
    public float velocity;
    public float yLimit;
    private float g;
    private Vector3 velocityVector;

    [Header("Linecast variables")]
    [Range(2, 30)]
    public int linecastResolution;
    public LayerMask canHit;

    private void Start()
    {
        g = Mathf.Abs(Physics.gravity.y);
    }

    private void Update()
    {
        Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
        velocityVector = Quaternion.AngleAxis(-45, transform.right) * forward * velocity;
        StartCoroutine(RenderArc());
    }

    private IEnumerator RenderArc()
    {
        line.positionCount = resolution + 1;
        line.SetPositions(CalculateLineArray());
        yield return null;
    }

    private Vector3[] CalculateLineArray()
    {
        Vector3[] lineArray = new Vector3[resolution + 1];

        var lowestTimeValueX = MaxTimeX() / resolution;
        var lowestTimeValueZ = MaxTimeZ() / resolution;
        var lowestTimeValue = lowestTimeValueX > lowestTimeValueZ ? lowestTimeValueZ : lowestTimeValueX;

        for (int i = 0; i < lineArray.Length; i++)
        {
            var t = lowestTimeValue * i;
            lineArray[i] = CalculateLinePoint(t);
        }

        return lineArray;
    }

    private Vector3 HitPosition()
    {
        var lowestTimeValue = MaxTimeY() / linecastResolution;

        for (int i = 0; i < linecastResolution + 1; i++)
        {
            RaycastHit rayHit;

            var t = lowestTimeValue * i;
            var tt = lowestTimeValue * (i + 1);

            if (Physics.Linecast(CalculateLinePoint(t), CalculateLinePoint(tt), out rayHit, canHit))
                return rayHit.point;
        }

        return CalculateLinePoint(MaxTimeY());
    }

    private Vector3 CalculateLinePoint(float t)
    {
        float x = velocityVector.x * t;
        float z = velocityVector.z * t;
        float y = (velocityVector.y * t) - (g * Mathf.Pow(t, 2) / 2);
        return new Vector3(x + transform.position.x, y + transform.position.y, z + transform.position.z);
    }

    private float MaxTimeY()
    {
        var v = velocityVector.y;
        var vv = v * v;

        var t = (v + Mathf.Sqrt(vv + 2 * g * (transform.position.y - yLimit))) / g;
        return t;
    }

    private float MaxTimeX()
    {
        if (IsValueAlmostZero(velocityVector.x))
            SetValueToAlmostZero(ref velocityVector.x);

        var x = velocityVector.x;

        var t = (HitPosition().x - transform.position.x) / x;
        return t;
    }

    private float MaxTimeZ()
    {
        if (IsValueAlmostZero(velocityVector.z))
            SetValueToAlmostZero(ref velocityVector.z);

        var z = velocityVector.z;

        var t = (HitPosition().z - transform.position.z) / z;
        return t;
    }

    private bool IsValueAlmostZero(float value)
    {
        return value < 0.0001f && value > -0.0001f;
    }

    private void SetValueToAlmostZero(ref float value)
    {
        value = 0.0001f;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocityVector = velocity;
    }
}
