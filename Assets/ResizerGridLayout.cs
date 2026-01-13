using Unity.VisualScripting;
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
	public GameObject DefaultItem;

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


		if (content.childCount > sizeTarget.x * sizeTarget.y || content.childCount < sizeTarget.x * sizeTarget.y)
		{
			Debug.Log("Updated number cells , Number elements inside contant is not matched with size target: " + sizeTarget);
			UpdateContantElements();

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


	void UpdateContantElements()
	{
		int numberCells = sizeTarget.x * sizeTarget.y;
		
		for(int i = 0; i < content.childCount; i++)
		{
			if (content.childCount > numberCells)
			{
				Destroy(content.GetChild(0).gameObject);
			}
			else
			if (content.childCount < 0)
			{
				Instantiate(DefaultItem, content.transform);
			}
			else
				break;
		}
	}
}
