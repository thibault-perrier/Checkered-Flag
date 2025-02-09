using UnityEngine;

public class MapCreator : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private float _tileWidth;
    [SerializeField] private float _tileLength;

    [SerializeField] private int _mapWidth;
    [SerializeField] private int _mapLength;

    [ContextMenu("Create Map")]
    public void CreateMap()
    {
        for (int x = 0; x < _mapWidth; x++)
        {
            for (int z = 0; z < _mapLength; z++)
            {
                GameObject tile = Instantiate(_tilePrefab, new Vector3(x * _tileLength, 0, z * _tileWidth), Quaternion.identity);
                tile.transform.SetParent(transform);
            }
        }
    }

    [ContextMenu("Clear Map")]
    public void ClearMap()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
