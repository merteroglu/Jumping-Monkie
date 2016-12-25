using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class kipirda : MonoBehaviour {
	public int kere = 0;
    public GameObject ElliPuan;
    private GameObject instantiated;
    public Sprite ZiplaSpr;
    public Sprite JumpSpr;
    public GameObject JumpLa;
    private GameObject JumplaP;
    bool ifJumpla = false;
    public bool hareketlimi = false;
    private GameObject Maymunnn;
	public static int gezinme = 0; 

   public float playerX;
   public float odunX;
	// Use this for initialization
	void Start () {
		gezinme = 0;
        Maymunnn = GameObject.Find("maymunn");

        if (string.Compare(PlayerPrefs.GetString("Dil"), "TR") == 0)
        {
            JumpLa.GetComponent<SpriteRenderer>().sprite = ZiplaSpr;
        }
        else {
            JumpLa.GetComponent<SpriteRenderer>().sprite = JumpSpr;
        }
	}
	
	// Update is called once per frame
	void Update () {
        playerX = Maymunnn.GetComponent<Rigidbody2D>().position.x;
        odunX = this.GetComponent<Rigidbody2D>().position.x;
       EkstraKontrol();
       JumpKontrol();

		if (gezinme == 1) {
			Maymunnn.transform.position = new Vector3 (odunX, Maymunnn.transform.position.y,Maymunnn.transform.position.z);
		}
      
	}

    void JumpKontrol() {

        if (kere == 2 && ifJumpla == false) {
            Vector2 pos = new Vector2(this.GetComponent<Rigidbody2D>().position.x, this.GetComponent<Rigidbody2D>().position.y - 0.5f);
            JumplaP = (GameObject)Instantiate(JumpLa, pos, Quaternion.identity);
            ifJumpla = true;
        }
        if (!GameObject.Find("maymunn").GetComponent<Player>().grounded) {
            Destroy(JumplaP);
        }
    
    }

    void EkstraKontrol() {

        if ((playerX - odunX) >= 1.9f && kere == 0) {
           EkstraPuan();
            Vector2 pos = new Vector2(this.GetComponent<Rigidbody2D>().position.x, this.GetComponent<Rigidbody2D>().position.y);
            Vector2 forces = new Vector2(0,20f);

            instantiated = (GameObject)Instantiate(ElliPuan, pos, Quaternion.identity);
            ElliPuan.GetComponent<Rigidbody2D>().AddForce(forces);
            kere++;
            Destroy(instantiated, 1.5f);
           
        }
    
    }

    void EkstraPuan() {
        Player.Skor += 50;
    }

	void OnCollisionEnter2D (Collision2D col)
	{
       
		if(col.gameObject.name == "maymunn" && Player.yerdemi == 0)
		{
            if(hareketlimi == false)
            kere++;
            

            if (kere <= 2)
            {
               StartCoroutine(Kipirda());
            }
            else {
                StartCoroutine(KompleDus());
            
            }

		}

        if (col.gameObject.name == "maymunn" && hareketlimi == true) {
			gezinme = 1;
        }
         
    }

   

	IEnumerator Kipirda() {
		this.transform.position = new Vector2 (transform.position.x, transform.position.y - 0.05f);
    
		yield return new WaitForSeconds (0.1f);
		this.transform.position = new Vector2 (transform.position.x, transform.position.y + 0.05f);
       
	}

	IEnumerator KompleDus() {
        GetComponent<Rigidbody2D>().isKinematic = false;
       GetComponent<BoxCollider2D>().isTrigger = true;
		yield return new WaitForSeconds (1f);
	}
}
