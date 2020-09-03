using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityMVVM.Binding;

public class TestEvent : MonoBehaviour, IPointerEnterHandler
{

    private  UnityEvent ue=new UnityEvent();

    public UnityEvent Ue
    {
        get => ue;
        set => ue = value;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ue.Invoke();
    }
    public void Down()
    {
    }
}
