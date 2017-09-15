using UnityEngine;

public class ClickPosition : MonoBehaviour
{
	[SerializeField] private FloodFill _floodFill;
	[SerializeField] private GridRenderer _gridRenderer;
	
	private void Update()
	{
		Ray ray;
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out hit)) return;
			_floodFill.Fill(hit.transform.position, Vector2.zero);
		}
		if (!Input.GetMouseButtonDown(1)) return;
		
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (!Physics.Raycast(ray, out hit)) return;
			var currentTile = _gridRenderer.GetGrid()[(int) hit.transform.position.x, (int) hit.transform.position.y];
			if (currentTile.hide) return;
			_gridRenderer.GetObject(currentTile).GetComponent<SpriteSwapper>().SwapSpecificSprite(2);
	}
}
