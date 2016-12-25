using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraTakip : MonoBehaviour {
    public GameObject PMaymun;
    public GameObject Su1, Su2;
    public GameObject Woood;
    public GameObject MovingWoood;
    public GameObject Orman1, Orman2;

    float oncekiX;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        oncekiX = this.transform.position.x;
        
	}
	
	// Update is called once per frame
	void Update () {

       this.transform.position = new Vector3(PMaymun.transform.position.x+3, 0, -10);
       arkaPlanlar();
      float fark = this.transform.position.x - oncekiX;
        

      if (fark >= 3.5f)
      {
          OdunOlustur();
          oncekiX = this.transform.position.x;
      }

         

       /*
      if (fark >= 3.5f && Player.Skor < 100) {
          OdunOlustur();
          oncekiX = this.transform.position.x;
      }
      else if (fark >= 3.5f && Player.Skor >= 100) {
          HareketliOdunOlustur();
          oncekiX = this.transform.position.x;
      }  
        
        */

        

	}

    void OdunOlustur()
    {
        float randX, randY;
        //randEkleme;

        randX = UnityEngine.Random.RandomRange(5f, 6f); // 5 ~ 5.5f
        randY = UnityEngine.Random.RandomRange(-4.7f, -1f);

        randX += this.transform.position.x;


        Vector3 pos = new Vector3(randX, randY, 0);
        Instantiate(Woood, pos, Quaternion.identity);
    }

    void HareketliOdunOlustur() {
        float randX, randY;

        randX = UnityEngine.Random.RandomRange(8f, 10f);
        randY = UnityEngine.Random.RandomRange(-4.7f, -1f);

        randX += this.transform.position.x;

        Vector3 pos = new Vector3(randX, randY, 0);
        Instantiate(MovingWoood, pos, Quaternion.identity);
        


    }

    void arkaPlanlar() {
        if (this.transform.position.x - Orman1.transform.position.x > 15)
        {
            Orman1.transform.position = new Vector3(Orman2.transform.position.x + 14.94f, 2.2f, 0);
        }

        if (this.transform.position.x - Orman2.transform.position.x > 15)
        {
            Orman2.transform.position = new Vector3(Orman1.transform.position.x + 14.94f, 2.2f, 0);
        }

        if (this.transform.position.x - Su1.transform.position.x > 15)
        {
            Su1.transform.position = new Vector3(Su2.transform.position.x + 14.94f, -2.92f, 0);
        }

        if (this.transform.position.x - Su2.transform.position.x > 15)
        {
            Su2.transform.position = new Vector3(Su1.transform.position.x + 14.94f, -2.92f, 0);
        }
    }

    

}
