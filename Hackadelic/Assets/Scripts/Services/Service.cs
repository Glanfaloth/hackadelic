using System.IO;
using UnityEngine;

public abstract class Service
{
    protected string FileContent;

    protected Service(string fileName) {
        var filePath = $"{Application.dataPath}/Database/{fileName}";
        
        using StreamReader streamReader = new StreamReader(filePath);
        FileContent = streamReader.ReadToEnd();
    }
}