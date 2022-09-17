using System.IO;
using UnityEngine;

public abstract class Service
{
    protected string FilePath;
    protected StreamReader StreamReader;

    protected Service(string fileName) {
        FilePath = $"{Application.dataPath}/Database/{fileName}";
        StreamReader = new StreamReader(FilePath);
    }
}