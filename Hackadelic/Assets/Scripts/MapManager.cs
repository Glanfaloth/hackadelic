using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject PersonPinPrefab;

    public void InitializeMap()
    {
        var person = GameManager.PeopleService.GetPerson(1);
        Instantiate(PersonPinPrefab, new Vector3(person.TableLocationX, person.TableLocationY, 0), Quaternion.identity);
    }

    public string Test()
    {
        return "This is a test message.";
    }
}
