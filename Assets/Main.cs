using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	public LineRenderer lineRenderer;
	public List<Vector2Int> w;
	public int x;
	public int y;
	public int m;
	public int s;
	public int maxs;


	void Update() {
		for (int i = 0; i < 50; i++) {
			if (s < maxs) {
				s++;
				if (x > s / m && !Contains(w, x - s / m, y)) {
					x -= s / m;
				} else if (y > s / m && !Contains(w, x, y - s / m)) {
					y -= s / m;
				} else if (!Contains(w, y,x)) {
					int a = x;
					x = y;
					y = a;
				} else {
					x += s / m;
					y += s / m;
				}

				lineRenderer.positionCount++;
				lineRenderer.SetPosition(lineRenderer.positionCount - 1, new Vector3(x, y, 0));
				w.Add(new Vector2Int(x, y));
			}
		}
    }

	public bool Contains(List<Vector2Int> w, int x, int y) {
		for (int i = 0; i < w.Count; i++) {
			if (w[i].x == x && w[i].y==y)
				return true;
		}
		return false;
	}

}
