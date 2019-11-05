using UnityEngine;
using System.Collections;
/* Written by Elmar Hanlhofer  http://www.plop.at  2015 06 10*/

[ExecuteInEditMode]
public class AlignInEditor : MonoBehaviour 
{
	public bool align = false;
	public bool showLineToSurface = false;

	public enum Orientation { left, right, up, down, forward, back};
	public Orientation orientation;

	private Vector3 d;


	void Update ()
	{
		if (orientation == Orientation.left) { d = Vector3.left; }
		if (orientation == Orientation.right) { d = Vector3.right; }
		if (orientation == Orientation.up) { d = Vector3.up; }
		if (orientation == Orientation.down) { d = Vector3.down; }
		if (orientation == Orientation.forward) { d = Vector3.forward; }
		if (orientation == Orientation.back) { d = Vector3.back; }


		if (align)
		{
			RaycastHit hit;
			Ray ray = new Ray (transform.position, d);
			if (Physics.Raycast(ray, out hit))
			{
				transform.position = hit.point;
				Debug.Log (transform.name + " aligned.");
			}
			else
			{
				Debug.Log ("No surface found for " + transform.name);
			}
			align = false;

		}

		if (showLineToSurface)
		{
			RaycastHit hit;
			Ray ray = new Ray (transform.position, d);
			if (Physics.Raycast(ray, out hit))
			{
				Debug.DrawLine (transform.position, hit.point);
			}
		}
	}
}
