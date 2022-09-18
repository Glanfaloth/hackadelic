
using System;
using System.IO;
using UnityEngine;

public abstract class Service
{
    protected string FileContent;

    protected Service(string fileName) {
        var filePath = Environment.ExpandEnvironmentVariables($"%UserProfile%/Desktop/Database/{fileName}");
        
        using StreamReader streamReader = new StreamReader(filePath);
        FileContent = streamReader.ReadToEnd();
    }
}