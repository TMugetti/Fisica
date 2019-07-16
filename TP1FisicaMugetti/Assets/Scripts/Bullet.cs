using UnityEngine;
using System.Collections.Generic;
using MPhysics;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private GameObject trailPrefab;
    [SerializeField] private float trailTiming;
    [SerializeField] private Transform LaunchPoint;
    private List<GameObject> trail = new List<GameObject>();
    private bool active; //variable posiblemente inutil
    private Vector3 initialPosition;
    private Vector2 initialSpeeds;
    private float initialtime;
    private float trailCounter;

    void Start()
    {
        active = false;
        initialtime = 0;
        trailCounter = 0;
        initialPosition = Vector3.zero;
        initialSpeeds = Vector2.zero;
        MugettiPhysics.StateGravity(gravity);
    }


    void Update()
    {
        if (active)
        {
            if (transform.position.y <= 0)
            {
                initialtime = 0;
                trailCounter = 0;
                initialPosition = Vector3.one * 600;
                transform.position = initialPosition;
                initialSpeeds = Vector2.zero;
                active = false;
                DeactivateTrail();
                gameObject.SetActive(false);
                return;
            }
            MugettiPhysics.MVec2 initPos;
            initPos.X = initialPosition.x;
            initPos.Y = initialPosition.y;
            MugettiPhysics.MVec2 initSpds;
            initSpds.X = initialSpeeds.x;
            initSpds.Y = initialSpeeds.y;
            MugettiPhysics.MVec2 newPos =  MugettiPhysics.TiroOblicuo(initialtime,Time.time,initPos,initSpds);
            Vector3 newPosition = transform.position;
            newPosition.x = newPos.X;
            newPosition.y = newPos.Y;
            transform.position = newPosition;
            Trail(newPosition);
            Debug.Log(newPos.X + " " + newPos.Y);
        }
    }

    public void Launch(float initAngleZ, float initSpeed)
    {
        initialPosition = LaunchPoint.position;
        initialSpeeds = new Vector2(initSpeed * Mathf.Cos(initAngleZ), initSpeed * Mathf.Sin(initAngleZ));
        active = true;
        initialtime = Time.time;
        Debug.Log(initialSpeeds);
        gameObject.SetActive(true);
    }

    void DeactivateTrail() {
        foreach (GameObject go in trail) {
            go.SetActive(false);
        }
    }

    void Trail(Vector3 position){
        trailCounter += Time.deltaTime;
        if ((trailCounter >= trailTiming && active) && (trail.Count <= 20)) {
            trailCounter = 0;
            position.z++;
            bool shouldCreate = true;
            if (trail.Count == 0) {
                shouldCreate = true;
            } else { shouldCreate = trail.TrueForAll(s => s.activeInHierarchy); }
            if (shouldCreate) {
                GameObject go = Instantiate(trailPrefab) as GameObject;
                go.transform.position = position;
                trail.Add(go);
            } else {
                GameObject go = trail.Find(s => s.activeInHierarchy == false);
                go.transform.position = position;
                go.SetActive(true);
            }

        }
    }

}


