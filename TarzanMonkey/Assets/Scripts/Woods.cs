using UnityEngine;
using System.Collections;

public class Woods : MonoBehaviour {
    public GameObject Woood;
   

    float BwoodX,NwoodX;
    public float hareketHizi = 15f;
    public float rangeMin = 1.5f;
    public float rangeMax = 3.5f;
    float rangex;
	// Use this for initialization
	void Start () {
        BwoodX = Woood.transform.position.x;
        rangex = UnityEngine.Random.RandomRange(rangeMin, rangeMax);
	}
	
	// Update is called once per frame
	void Update () {
        NwoodX = Woood.transform.position.x;
        HareketEt(rangex);
	}

    void HareketEt(float range) {

        if (Mathf.Abs(NwoodX - BwoodX) >= range)
        {
            hareketHizi *= -1;
        }

        Woood.transform.position = new Vector3(Woood.transform.position.x + hareketHizi*Time.deltaTime, Woood.transform.position.y, Woood.transform.position.z);

    
    }

  
}
