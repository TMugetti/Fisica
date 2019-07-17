using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPhysics;

public class CollisionManager : MonoBehaviour
{
    private List<Collider> layer1 = new List<Collider>();
    private List<Collider> layer2 = new List<Collider>();
    void Start()
    {
        var colliders = FindObjectsOfType<Collider>();
        foreach (Collider col in colliders)
        {
            if(col.GetLayer() == 1){ layer1.Add(col);}
            else if(col.GetLayer() == 2){layer2.Add(col);}
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach (Collider col1 in layer1){
            MugettiPhysics.MVec2 col1Pos;
            col1Pos.X = col1.GetTransform().position.x;
            col1Pos.Y = col1.GetTransform().position.y;
            foreach (Collider col2 in layer2)
            {
                bool collided = false;
                MugettiPhysics.MVec2 col2Pos;
                col2Pos.X = col2.GetTransform().position.x;
                col2Pos.Y = col2.GetTransform().position.y;
                if(col1.GetColType()){
                    
                    MugettiPhysics.MVec2 col1Size;
                    col1Size.X = col1.GetWidth();
                    col1Size.Y = col1.GetHeightOrRadius();
                    
                    if(col2.GetColType()){
                        MugettiPhysics.MVec2 col2Size;
                        col2Size.X = col2.GetWidth();
                        col2Size.Y = col2.GetHeightOrRadius();

                        collided = MugettiPhysics.CheckBoxCollision(col1Pos,col1Size,col2Pos,col2Size);
                       //Debug.Log("A");
                    } else {
                        collided = MugettiPhysics.CheckBoxCircleCollision(col1Pos,col1Size,col2Pos, col2.GetHeightOrRadius());
                        //Debug.Log("B");
                    }
                } else {
                    if(col2.GetColType()){
                        MugettiPhysics.MVec2 col2Size;
                        col2Size.X = col2.GetWidth();
                        col2Size.Y = col2.GetHeightOrRadius();

                        collided = MugettiPhysics.CheckBoxCircleCollision(col2Pos,col2Size,col1Pos,col1.GetHeightOrRadius());
                        //Debug.Log("C");
                    } else {
                        collided = MugettiPhysics.CheckCircleCollision(col1Pos, col1.GetHeightOrRadius(), col2Pos, col2.GetHeightOrRadius());
                       // Debug.Log("D");
                    }
                }
                if(collided){ col1.OnColEnter.Invoke(); col2.OnColEnter.Invoke();}
            }
        }
    }
}
