using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPersonText : MonoBehaviour
{
    TextMesh textMesh;

    void Awake()
    {
        textMesh = gameObject.GetComponent<TextMesh>();
    }

    public void SetText(Person person)
    {
        textMesh.text = $"Look for {person.FirstName} {person.LastName}!";
    }
}
