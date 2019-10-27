using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveUI : MonoBehaviour
{
    public UnityEvent OnHoverEnterEvent;
    public UnityEvent OnHoverExitEvent;
    public UnityEvent OnClickEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnHoverEnter()
    {
        OnHoverEnterEvent.Invoke();
        Debug.Log("Hovered");
    }

    public void OnHoverExit()
    {
        OnHoverExitEvent.Invoke();
        Debug.Log("Hovered Off");

    }

    public void OnClick()
    {
        OnClickEvent.Invoke();
        Debug.Log("Clicked");
    }

}
