using UnityEngine;

public class CanonScript : MonoBehaviour
{
    [SerializeField] GameObject Canon;
    [SerializeField] Bullet Bullet;
    [SerializeField] float minRot = 0;
    [SerializeField] float maxRot = 180;
    [SerializeField] float rotSpd = 15;
    [SerializeField] float chargeSpd = 10;
    [SerializeField]  bool IsLeft;
    private Vector3 initRot;
    private float charge;
    private GameManager GM;
    // Start is called before the first frame update
    void Start() {
        charge = 0;
        initRot = Canon.transform.rotation.eulerAngles;
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
         if((IsLeft && GM.IsLeftTurn()) || (!IsLeft && !GM.IsLeftTurn())){
        if (Input.GetKeyUp(KeyCode.Space)) {
            Bullet.Launch(initRot.z, charge, IsLeft);
        }
 
        if (!Input.GetKey(KeyCode.Space)){
            charge = 0;
            initRot.z += rotSpd * Time.deltaTime * Input.GetAxis("Vertical");
            if (initRot.z > maxRot) { initRot.z = maxRot;}
            if (initRot.z < minRot) { initRot.z = minRot;}
            Vector3 rot = initRot;
            if(!IsLeft){rot.z *= -1;}
            Canon.transform.rotation = Quaternion.Euler(rot);

        } else {            
                charge += chargeSpd * Time.deltaTime;
        }
        }   
    }
}
