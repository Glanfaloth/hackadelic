using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPin : MonoBehaviour
{
    Person person;
    MapManager mapManager;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Initialize(Person person, MapManager mapManager)
    {
        this.person = person;
        this.mapManager = mapManager;
        var sprite = Resources.Load<Sprite>(person.ImagePath);
        transform.localPosition = new Vector3(person.TableLocationX, person.TableLocationY, -1);
        spriteRenderer.sprite = sprite;
    }

    void OnMouseDown()
    {
        mapManager.NextPerson(person);
        Debug.Log($"{person.FirstName} clicked!");
    }
}
