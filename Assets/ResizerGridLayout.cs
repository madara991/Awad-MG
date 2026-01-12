using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class ResizerGridLayout : MonoBehaviour
{
	private GridLayoutGroup grid;
	private RectTransform rect;

	[Header("Grid Settings")]
	public Transform content;
	public Vector2Int sizeTarget = new Vector2Int(3, 3); // rows , columns

	private void Awake()
	{
		
	}

	private void OnEnable()
	{
		grid = GetComponent<GridLayoutGroup>();
		rect = GetComponent<RectTransform>();
		Resize();
	}



	void Resize()
	{
		if (content == null || content.childCount == 0)
			return;

		if (content.childCount > sizeTarget.x * sizeTarget.y)
		{
			Debug.Log("Number elements inside contant is not matched with size target " + sizeTarget);
			return;
		}


		int rows = sizeTarget.x;
		int columns = sizeTarget.y;

		float width = rect.rect.width;
		float height = rect.rect.height;

		// total spacing
		float totalSpacingX = grid.spacing.x * (columns - 1);
		float totalSpacingY = grid.spacing.y * (rows - 1);

		// available size
		float availableWidth =
			width - grid.padding.left - grid.padding.right - totalSpacingX;

		float availableHeight =
			height - grid.padding.top - grid.padding.bottom - totalSpacingY;

		float cellWidth = availableWidth / columns;
		float cellHeight = availableHeight / rows;

		grid.cellSize = new Vector2(cellWidth, cellHeight);
	}
}
