using UnityEngine;

public class FloodFill : MonoBehaviour
{	
	[SerializeField] private GridRenderer _gridRenderer;

	public void Fill(Vector3 node, Vector2 direction)
	{
		var NextNode = new Vector2(direction.x + node.x, direction.y + node.y);
		var gameBoard = _gridRenderer.GetGrid();

		if(NextNode.x > _gridRenderer.GetWidthHeight().x -1 || NextNode.y > _gridRenderer.GetWidthHeight().y -1)return;
		if(NextNode.x < 0 || NextNode.y < 0)return;

		_gridRenderer.GetObject(gameBoard[(int) node.x, (int) node.y]).GetComponent<SpriteSwapper>().SwapSprite();
		
		if (gameBoard[(int) node.x, (int) node.y].name == "Bomb")
		{
			
			return;
		}
		if (gameBoard[(int) NextNode.x, (int) NextNode.y].name == "Bomb") return;
		
		if (gameBoard[(int) NextNode.x, (int) NextNode.y].hide) return;

		gameBoard[(int) node.x, (int) node.y].hide = true;
		
		if (gameBoard[(int) node.x, (int) node.y].bomCount > 0)
		{
			_gridRenderer.GetObject(gameBoard[(int) node.x, (int) node.y]).GetComponentInChildren<TextMesh>().text =
				gameBoard[(int) node.x, (int) node.y].bomCount.ToString();
			return;
		}
		
		Fill(NextNode, Vector2.down);
		Fill(NextNode, Vector2.up);
		Fill(NextNode, Vector2.left);
		Fill(NextNode, Vector2.right);
		Fill(NextNode, Vector2.one);
		Fill(NextNode, -Vector2.one);
		Fill(NextNode, new Vector2(-1,1));
		Fill(NextNode, new Vector2(1,-1));
	}
}
