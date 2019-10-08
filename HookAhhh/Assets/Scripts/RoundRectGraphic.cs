using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class RoundRectGraphic : Graphic {

    [Range(0, 200)]
    public int radius;
    public bool hasTop;

    protected override void OnPopulateMesh(VertexHelper vh) {
        Vector2 corner1 = Vector2.zero;
        Vector2 corner2 = Vector2.zero;

        corner1.x = 0f;
        corner1.y = 0f;
        corner2.x = 1f;
        corner2.y = 1f;

        corner1.x -= rectTransform.pivot.x;
        corner1.y -= rectTransform.pivot.y;
        corner2.x -= rectTransform.pivot.x;
        corner2.y -= rectTransform.pivot.y;

        corner1.x *= rectTransform.rect.width;
        corner1.y *= rectTransform.rect.height;
        corner2.x *= rectTransform.rect.width;
        corner2.y *= rectTransform.rect.height;

        vh.Clear();

        UIVertex vert = UIVertex.simpleVert;

        // CENTRAL HORIZONTAL RECT
        vert.position = new Vector2(corner1.x, corner1.y + radius); // 0
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner1.x, corner2.y - (hasTop ? radius : 0)); // 1
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x, corner2.y - (hasTop ? radius : 0)); // 2
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x, corner1.y + radius); // 3
        vert.color = color;
        vh.AddVert(vert);

        // TOP RECT
        vert.position = new Vector2(corner1.x + radius, corner2.y - radius); // 4
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner1.x + radius, corner2.y); // 5
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x - radius, corner2.y); // 6
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x - radius, corner2.y - radius); // 7
        vert.color = color;
        vh.AddVert(vert);

        // BOTTOM RECT
        vert.position = new Vector2(corner1.x + radius, corner1.y + radius); // 8
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner1.x + radius, corner1.y); // 9
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x - radius, corner1.y); // 10
        vert.color = color;
        vh.AddVert(vert);

        vert.position = new Vector2(corner2.x - radius, corner1.y + radius); // 11
        vert.color = color;
        vh.AddVert(vert);

        int pointCount = 20;

        // BOTTOM LEFT CORNER
        // 12 -> 12 + pointCount - 1
        for(int i = 1; i <= pointCount; i++) {
            float angle = -Mathf.PI / 2 * (1 + ((float)i) / (pointCount + 1));
            vert.position = new Vector2(corner1.x + radius + Mathf.Cos(angle) * radius, corner1.y + radius + Mathf.Sin(angle) * radius);
            vert.color = color;
            vh.AddVert(vert);
        }

        // BOTTOM RIGHT CORNER
        // 12 + pointCount -> 12 + 2 * pointCount - 1
        for(int i = 1; i <= pointCount; i++) {
            float angle = -Mathf.PI / 2 * (((float) i) / (pointCount + 1));
            vert.position = new Vector2(corner2.x - radius + Mathf.Cos(angle) * radius, corner1.y + radius + Mathf.Sin(angle) * radius);
            vert.color = color;
            vh.AddVert(vert);
        }

        // TOP LEFT CORNER
        // 12 + 2 * pointCount -> 12 + 3 * pointCount - 1
        for(int i = 1; i <= pointCount; i++) {
            float angle = Mathf.PI / 2 * (1 + ((float)i) / (pointCount + 1));
            vert.position = new Vector2(corner1.x + radius + Mathf.Cos(angle) * radius, corner2.y - radius + Mathf.Sin(angle) * radius);
            vert.color = color;
            vh.AddVert(vert);
        }

        // TOP RIGHT CORNER
        // 12 + 3 * pointCount -> 12 + 4 * pointCount - 1
        for(int i = 1; i <= pointCount; i++) {
            float angle = Mathf.PI / 2 * (((float) i) / (pointCount + 1));
            vert.position = new Vector2(corner2.x - radius + Mathf.Cos(angle) * radius, corner2.y - radius + Mathf.Sin(angle) * radius);
            vert.color = color;
            vh.AddVert(vert);
        }

        // HORIZONTAL RECT
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);

        // TOP RECT
        if(hasTop) {
	        vh.AddTriangle(4, 5, 6);
	        vh.AddTriangle(6, 7, 4);
        }

        // BOTTOM RECT
        vh.AddTriangle(8, 9, 10);
        vh.AddTriangle(10, 11, 8);

        // BOTTOM LEFT CORNER
        for(int i = 12; i < 12 + pointCount - 1; i++) {
            vh.AddTriangle(8, i, i+1);
        }

        vh.AddTriangle(8, 9, 12);
        vh.AddTriangle(8, 0, 12 + pointCount - 1);

        // BOTTOM RIGHT CORNER
        for(int i = 12 + pointCount; i < 12 + 2 * pointCount - 1; i++) {
            vh.AddTriangle(11, i, i + 1);
        }

        vh.AddTriangle(11, 3, 12 + pointCount);
        vh.AddTriangle(11, 10, 12 + 2 * pointCount - 1);

        if(hasTop) {
            // TOP LEFT CORNER
            for(int i = 12 + 2 * pointCount; i < 12 + 3 * pointCount - 1; i++) {
                vh.AddTriangle(4 , i , i + 1);
            }

            vh.AddTriangle(4 , 5 , 12 + 2 * pointCount);
            vh.AddTriangle(4 , 1 , 12 + 3 * pointCount - 1);

            // TOP RIGHT CORNER
            for(int i = 12 + 3 * pointCount; i < 12 + 4 * pointCount - 1; i++) {
                vh.AddTriangle(7 , i , i + 1);
            }

            vh.AddTriangle(7 , 2 , 12 + 3 * pointCount);
            vh.AddTriangle(7 , 6 , 12 + 4 * pointCount - 1);
        }
    }
}
