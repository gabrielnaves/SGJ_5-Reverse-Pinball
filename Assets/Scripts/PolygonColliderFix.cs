using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonColliderFix : MonoBehaviour {

    public float pixelsPerUnit = 64f;
    public bool edgeCollider;

    PolygonCollider2D col;
    EdgeCollider2D edge;

    void Start() {
        if (edgeCollider) {
            edge = GetComponent<EdgeCollider2D>();
            FixEdge();
        }
        else {
            col = GetComponent<PolygonCollider2D>();
            FixPolygon();
        }
    }

    void FixPolygon() {
        Vector2[] fixedPoints = new Vector2[col.points.Length];
        for (int i = 0; i < col.points.Length; ++i)
            fixedPoints[i] = FixPoint(col.points[i]);
        col.points = fixedPoints;
    }

    void FixEdge() {
        Vector2[] fixedPoints = new Vector2[edge.points.Length];
        for (int i = 0; i < edge.points.Length; ++i)
            fixedPoints[i] = FixPoint(edge.points[i]);
        edge.points = fixedPoints;
    }

    Vector2 FixPoint(Vector2 point) {
        point.x = Mathf.Round(point.x * pixelsPerUnit) / pixelsPerUnit;
        point.y = Mathf.Round(point.y * pixelsPerUnit) / pixelsPerUnit;
        return point;
    }
}
