using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PolygonCollider2D))]
public class PolygonColliderFix : MonoBehaviour {

    public float pixelsPerUnit;

    PolygonCollider2D col;

    void Start() {
        col = GetComponent<PolygonCollider2D>();
        FixPolygon();
    }

    void FixPolygon() {
        Vector2[] fixedPoints = new Vector2[col.points.Length];
        for (int i = 0; i < col.points.Length; ++i)
            fixedPoints[i] = FixPoint(col.points[i]);
        col.points = fixedPoints;
    }

    Vector2 FixPoint(Vector2 point) {
        point.x = Mathf.Round(point.x * pixelsPerUnit) / pixelsPerUnit;
        point.y = Mathf.Round(point.y * pixelsPerUnit) / pixelsPerUnit;
        return point;
    }
}
