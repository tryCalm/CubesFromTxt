using UnityEngine;

public class CurrentField 
{
    private int _iStartPoint;
    private int _jStartPoint;
    private int[,] _currentFieldArray = new int[3, 3];

    public void SetField(ArrayFileReader arrayFileReader)
    {
        _iStartPoint = Random.Range(0, 6);
        _jStartPoint = Random.Range(0, 7);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _currentFieldArray[i, j] = arrayFileReader.GetCubesColorsArray(i + _iStartPoint, j + _jStartPoint);
            }
        }
    }
    
    public void UpdateField(ArrayFileReader arrayFileReader, int changeStarti, int changeStartj)
    {
        _iStartPoint += changeStarti;
        _jStartPoint += changeStartj;
        
        if (_iStartPoint >= 9)
            _iStartPoint = 0;
        if (_iStartPoint <= -1)
            _iStartPoint = 8;
        if (_jStartPoint >= 10) 
            _jStartPoint = 0;
        if (_jStartPoint <= -1)
            _jStartPoint = 9;
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int tmpi = i + _iStartPoint;
                int tmpj = j + _jStartPoint;
                
                if (i + _iStartPoint > 8)
                {
                    tmpi = (i + _iStartPoint) - 9;
                }
                if (j + _jStartPoint > 9)
                {
                    tmpj = (j + _jStartPoint) - 10;
                }
                    
                _currentFieldArray[i, j] = arrayFileReader.GetCubesColorsArray(tmpi, tmpj);
            }
        }
    }
    
    public int GetLenght(int dimension)
    {
        return _currentFieldArray.GetLength(dimension);
    }
    
    public int GetCurrentField(int i, int j)
    {
        return _currentFieldArray[i, j];
    }
}
