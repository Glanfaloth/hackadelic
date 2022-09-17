using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPin : MonoBehaviour
{
    Person person;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Initialize(Person person)
    {
        this.person = person;
        var sprite = Resources.Load<Sprite>(person.ImagePath);
        spriteRenderer.sprite = sprite;
    }


}
