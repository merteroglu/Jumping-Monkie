using UnityEngine;
using System.Collections;

public class destroyer : MonoBehaviour {

    public GameObject Kamera;
    public GameObject DestUst;
    public GameObject DestAlt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float kameraX;
        kameraX = Kamera.transform.position.x;
       DestUst.transform.position = new Vector2(kameraX - 10, DestUst.transform.position.y);
     
      DestAlt.transform.position = new Vector2(kameraX, DestAlt.transform.position.y);

	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "maymunn")
		{

           
		}

        if (col.gameObject.tag == "odun")
        {
          
            Destroy(col.gameObject);
        }

	}

   
}
