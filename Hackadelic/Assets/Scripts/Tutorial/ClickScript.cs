using System.Threading.Tasks;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public HttpClientScript httpClientScript;

    async Task OnMouseDown()
    {
        Debug.Log($"The gameObject {gameObject.name} was clicked.");
        await httpClientScript.SendMessage();
    }
}
