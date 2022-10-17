
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Button;
    private void Start()
    {
        Button.GetComponent<Animator>().Play("Hover off(start)");
        Button.GetComponent<Animator>().Play("Hover off(quit)");
        Button.GetComponent<Animator>().Play("Hover off(Quit)");
        Button.GetComponent<Animator>().Play("Hover off(restart)");
        Button.GetComponent<Animator>().Play("Hover off(main-menu)");
        Button.GetComponent<Animator>().Play("Hover off(Main menu)");
        Button.GetComponent<Animator>().Play("Hover off(next)");


    }
    // Set those in the inspector or via AddListener exactly the same as onClick of a button

    public void OnPointerEnter(PointerEventData eventData)
    {
        // evtl put some general button fucntionality here


        Button.GetComponent<Animator>().Play("Hover on(strat)");
        Button.GetComponent<Animator>().Play("Hover on(quit)");
        Button.GetComponent<Animator>().Play("Hover on(Quit)");
        Button.GetComponent<Animator>().Play("Hover on(restart)");
        Button.GetComponent<Animator>().Play("Hover on(main-menu)");
        Button.GetComponent<Animator>().Play("Hover on(Main menu)");
        Button.GetComponent<Animator>().Play("Hover on(next)");


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // evtl put some general button fucntionalit here

        Button.GetComponent<Animator>().Play("Hover off(start)");
        Button.GetComponent<Animator>().Play("Hover off(quit)");
        Button.GetComponent<Animator>().Play("Hover off(Quit)");
        Button.GetComponent<Animator>().Play("Hover off(main-menu)");
        Button.GetComponent<Animator>().Play("Hover off(restart)");
        Button.GetComponent<Animator>().Play("Hover off(Main menu)");
        Button.GetComponent<Animator>().Play("Hover off(next)");


    }
}
