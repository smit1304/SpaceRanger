
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class hoverScriptQuit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Button;
    private void Start()
    {
        Button.GetComponent<Animator>().Play("Hover off(quit)");
    }
    // Set those in the inspector or via AddListener exactly the same as onClick of a button

    public void OnPointerEnter(PointerEventData eventData)
    {
        // evtl put some general button fucntionality here

        Button.GetComponent<Animator>().Play("Hover on(quit)");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // evtl put some general button fucntionalit here

        Button.GetComponent<Animator>().Play("Hover off(quit)");
    }
}

