using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ResponsiveGrid : MonoBehaviour
{
	public int columns = 3;
	public int rows = 3;

	public float scale = 1f; // overall scale multiplier

	private GridLayoutGroup grid;
	private RectTransform rectTransform;

	void Start()
	{
		grid = GetComponent<GridLayoutGroup>();
		rectTransform = GetComponent<RectTransform>();

		Resize();
	}

	// Update 'size cells' when parent panel (screen resulation) changed
	// Only Work in Play Mode 
	private void OnRectTransformDimensionsChange()
	{
		Resize();
	}

	void Resize()
	{
		if (rectTransform == null || rectTransform.rect == null)
			return;

		float width = rectTransform.rect.width;
		float height = rectTransform.rect.height;

		float cellWidth =
			(width - grid.padding.left - grid.padding.right -
			grid.spacing.x * (columns - 1)) / columns;

		float cellHeight =
			(height - grid.padding.top - grid.padding.bottom -
			grid.spacing.y * (rows - 1)) / rows;

		float cellSize = Mathf.Min(cellWidth, cellHeight) * scale;

		grid.cellSize = new Vector2(cellSize, cellSize);
	}
}
