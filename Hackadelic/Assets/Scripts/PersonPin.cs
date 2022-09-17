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
        var sprite = Resources.Load(person.ImagePath) as Sprite;
        spriteRenderer.sprite = sprite;
    }


}
