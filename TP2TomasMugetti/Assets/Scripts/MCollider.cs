using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MCollider : MonoBehaviour
{
    [SerializeField] int Layer = 0;
    [SerializeField] bool BoxOrCircle = true; //true = box, false = circle
    [SerializeField] float HeightOrRadius = 1.0f;
    [SerializeField] float Width = 1.0f;
    public UnityEvent OnColEnter;
    void Awake(){
        OnColEnter = new UnityEvent();
    }
    public bool GetColType(){ return BoxOrCircle;}
    public float GetHeightOrRadius(){return HeightOrRadius;}
    public float GetWidth(){return Width;}
    public Transform GetTransform(){return gameObject.transform;}
    public int GetLayer(){return Layer;}
}
