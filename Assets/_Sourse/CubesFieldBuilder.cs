using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CubesFieldBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _redCube;
    [SerializeField] private GameObject _blueCube;
    [SerializeField] private GameObject _yellowCube;
    [SerializeField] private GameObject _purpleCube;
    
    private string _path = @"Assets\_Sourse\Array.txt";
    private ArrayFileReader _arrayFileReader = new ArrayFileReader();
    private CurrentField _currentField = new CurrentField();

    private GameObject[,] _cubesField = new GameObject[3, 3];
    
    void Awake()
    {
        _arrayFileReader.ReadFromFile(_path);
        _currentField.SetField(_arrayFileReader);
        BuildCurrentField(_currentField);
    }
    
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            DestroyField();
            _currentField.UpdateField(_arrayFileReader, -1, 0);
            BuildCurrentField(_currentField);
        }
        if (Input.GetKeyDown("a"))
        {
            DestroyField();
            _currentField.UpdateField(_arrayFileReader, 0, -1);
            BuildCurrentField(_currentField);
        }
        if (Input.GetKeyDown("s"))
        {
            DestroyField();
            _currentField.UpdateField(_arrayFileReader, 1, 0);
            BuildCurrentField(_currentField);
        }
        if (Input.GetKeyDown("d"))
        {
            DestroyField();
            _currentField.UpdateField(_arrayFileReader, 0, 1);
            BuildCurrentField(_currentField);
        }
    }

    void DestroyField()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Destroy(_cubesField[i, j]);
            }
        }
    }
    void BuildCurrentField(CurrentField currentField)
    {
        int[,] currentArray = new int[3, 3];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                currentArray[i, j] = currentField.GetCurrentField(i, j);
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                switch (currentArray[i, j])
                {
                    case 1:
                        _cubesField[i, j] = _redCube;
                        _cubesField[i, j] = Instantiate(_cubesField[i, j], new Vector3(4 - 2*i, 0, 4 - 2*j), Quaternion.identity);
                        break;
                    case 2:
                        _cubesField[i, j] = _yellowCube;
                        _cubesField[i, j] = Instantiate(_cubesField[i, j], new Vector3(4 - 2*i, 0, 4 - 2*j), Quaternion.identity);
                        break;
                    case 3:
                        _cubesField[i, j] = _blueCube;
                        _cubesField[i, j] = Instantiate(_cubesField[i, j], new Vector3(4 - 2*i, 0, 4 - 2*j), Quaternion.identity);
                        break;
                    case 4:
                        _cubesField[i, j] = _purpleCube;
                        _cubesField[i, j] = Instantiate(_cubesField[i, j], new Vector3(4 - 2*i, 0, 4 - 2*j), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
