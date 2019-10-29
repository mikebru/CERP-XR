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

    public virtual void OnHoverEnter()
    {
        OnHoverEnterEvent.Invoke();
        //Debug.Log("Hovered");
    }

    public virtual void OnHoverExit()
    {
        OnHoverExitEvent.Invoke();
        //Debug.Log("Hovered Off");

    }

    public virtual void OnClick()
    {
        OnClickEvent.Invoke();
        //Debug.Log("Clicked");
    }

}
