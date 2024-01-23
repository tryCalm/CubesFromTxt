using System;
using System.IO;
using UnityEngine;

public class ArrayFileReader
{
    private int[,] _cubesColorsArray = new int[9,10];

    public void ReadFromFile(string path)
    {
        string[] linesFromFile = File.ReadAllLines(path);
        for (int i = 0; i < linesFromFile.Length; i++)
        {
            string tmp = linesFromFile[i];
            for (int j = 0; j < tmp.Length; j++)
                _cubesColorsArray[i, j] = int.Parse(tmp[j].ToString());
        }
    }
    public int GetLenght(int dimension)
    {
        return _cubesColorsArray.GetLength(dimension);
    }
    public int GetCubesColorsArray(int i, int j)
    {
        return _cubesColorsArray[i, j];
    }
}
