using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
	public static string checkpointscene="Level1";
	public static bool die=false;

	Vector3 ScaleCh;
	Animator anim;
	public Slider slid;
	float chjump = 0;
	bool jumpwallkeydown=false;
	bool wallchk;//include from wallcontroller.staywall
	bool keepwall=false;
	bool right=false;
	bool left=false;
	bool upar=false;
	bool idle=false;
	bool runb=false;
	float jumpS=0;
	int oldheart=0;
	bool jumpformwall=false;
	Vector3 posjump;
	public static bool jumpinwall=false;
	bool runinwall=false;
	 float dietime=0;
	bool dieanim=false;
	float dietimeanim=0;
	AudioSource ani;
	public AudioClip[] clip;
	// Use this for initialization
	public static bool isground= true;
	void Start () {
		die=false;
		oldheart = DataSaveGame.heart;
		anim = GetComponent<Animator> ();
	 posjump = gameObject.GetComponent<Transform> ().position;
		ScaleCh = gameObject.GetComponent<Transform> ().localScale;
		ani = GetComponent<AudioSource> ();
	}





	// Update is called once per frame


	void ondie(){
		
		if (dietime <0.3f) {
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.5f);
		}if (dietime > 0.3f && dietime < 0.6f) {
			GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
		} 
		if(dietime > 0.6f){
			dietime = 0;
		}
	}

	void Update () {
        float runh = Input.GetAxis("Horizontal");
        float upv = Input.GetAxis("Vertical");
		dietime += Time.deltaTime;
		dietimeanim += Time.deltaTime;
		if (DataSaveGame.heart <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
		if(die==true){
			DataSaveGame.heart -=1;

			dietime = 0;
			dietimeanim = 0;
			keepwall = false;
			dieanim = true;
			die=false;

		}
		if (dieanim == true) {
			if (dietimeanim < 1.5f) {
				ondie ();
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
				dieanim = false;
			}
		}
		if (jumpS < gameObject.GetComponent<Transform> ().position.y) {
			jumpS = gameObject.GetComponent<Transform> ().position.y;
		}
		if (DataSaveGame.heart < oldheart) {
			DataSaveGame.die = true;
		}
			wallchk = WallController.staywall;

		if (runh>0) {
			right = true;
			ani.clip = clip[0];
			if (left == true||upar==true) {
				left = false;
				upar = false;
			}
			if (isground == true) {
				idle = false;
				runb = true;
                runinwall = false;
            }
			if (keepwall == true) {
				runinwall=true;
			}
		}
	 if (runh<0) {
			left = true;
			ani.clip = clip[0];
			if (right == true||upar==true) {
				right = false;
				upar = false;
			}
			if (isground == true) {
				idle = false;
				runb = true;
                runinwall = false;
            }
			if (keepwall == true) {
				runinwall=true;
			}
		}
		if (upv>0) {
			upar = true;
			if (right == true||left==true) {
				right = false;
				left = false;
			}
			if (keepwall == true) {
				runinwall=true;
			}
		}
		if (upv<0) {
			
			if (keepwall == true) {
				runinwall=true;
			}
		}
		if (upv==0) {

			if (keepwall == true&&(left==false&&right==false)) {
				runinwall=false;;
			}
		}
		if (runh==0) {
			if (left == false) {
				runb = false;
				idle = true;
			}
			if (keepwall == true && upar == false) {
				runinwall=false;
			}

		}
		if (runh==0) {
			if (right == false) {
				runb = false;
				idle = true;
			}
			if (keepwall == true&&upar == false) {
				runinwall=false;
			}
		}

		if (runb == true) {
			if (isground == true) {
				setani ("runR");
			}
		}
		if (idle == true&&runb==false	) {
			if(isground==true){
				setani ("idle");
			}

		}

		if (right == true) {
			Flip ();
		}
		if (left == true) {
			Flip ();
		}


		if (wallchk == false) {
			keepwall = false;
		}
		if (wallchk == true) {
			if (Input.GetKeyDown (KeyCode.X)||Input.GetKeyDown(KeyCode.Joystick1Button1)) {
				keepwall = true;
			}
			if (jumpinwall == true && keepwall == true) {
				if (Input.GetKey (KeyCode.Z)||Input.GetKeyDown(KeyCode.Joystick1Button0)) {
					jumpwallkeydown = true;
					ChJump.hide = false;
					chjump += 3;
					if (chjump > 100) {
						chjump = 100;
					}
					slid.value = chjump;
				}
				if (Input.GetKeyUp (KeyCode.Z)||Input.GetKeyDown(KeyCode.Joystick1Button0)) {
					ChJump.hide = true;
					ani.clip = clip[1];
					if (right == true) {
						keepwall = false;
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chjump*8, chjump*10));
						chjump = 0;

					}
					if (left == true) {
						keepwall = false;
						gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chjump*8, chjump*10));
						chjump = 0;

					} 
					if(upar==true) {
						keepwall = false;
						gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up*chjump*13);
						chjump = 0;
					}
					jumpformwall = true;
					slid.value = chjump;
					jumpwallkeydown = false;
				}
			}
		}





		if (keepwall == true) {
			gameObject.GetComponent<Rigidbody2D> ().Sleep ();
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
			if (runinwall == false) {
				setani ("climbidle");
			}

			if (jumpwallkeydown == false&&runinwall==true) {
				Debug.Log(upv);
				transform.Translate (8 * runh * Time.deltaTime, 8 * upv * Time.deltaTime, 0);
				setani ("climbrun");
			}
        }
				




		if (isground == true) {
			jumpS = 0f;
			if (jumpformwall == true) {
				jumpformwall = false;
				gameObject.GetComponent<Rigidbody2D> ().Sleep ();
			}
			if (Input.GetKeyDown (KeyCode.Z)&&keepwall==false) {
				posjump = gameObject.GetComponent<Transform> ().position;
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up*800);
				ani.clip = clip[1];
				setani ("jumpstay");

			}
		}
		if (isground == false&&keepwall==false) {
			if (gameObject.GetComponent<Transform> ().position.y > posjump.y + 4) {
				GetComponent<Rigidbody2D> ().AddForce (Vector2.down*50);

			}
			if (gameObject.GetComponent<Transform> ().position.y<jumpS) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 5;
				ani.clip = clip[2];
				setani ("jumpdrop");
			}
		}
		if (jumpwallkeydown == false&&keepwall==false) {
			transform.Translate (15 * runh * Time.deltaTime, 0, 0);
		}
	}

	void Flip(){
		Vector3 Sca=gameObject.GetComponent<Transform>().localScale;
		if (right == true) {
			Sca.Set (ScaleCh.x, ScaleCh.y, ScaleCh.z);
			gameObject.GetComponent<Transform> ().localScale = Sca;
		}
		if (left == true) {
			Sca.Set (-ScaleCh.x, ScaleCh.y, ScaleCh.z);
			gameObject.GetComponent<Transform> ().localScale = Sca;
		}
	}
	void setani(string name){
		anim.SetBool ("jumpstay", false);
		anim.SetBool ("idle", false);
		anim.SetBool ("runR", false);
		anim.SetBool ("jumpdrop", false);
		anim.SetBool ("climbidle", false);
		anim.SetBool ("climbrun", false);
		if (name == "jumpstay") {
			anim.SetBool ("jumpstay", true);
		}
		if (name == "climbidle") {
			anim.SetBool ("climbidle", true);
		}if (name == "climbrun") {
			anim.SetBool ("climbrun", true);
		}

		if (name == "idle") {
			anim.SetBool ("idle", true);
		}
		if (name == "runR") {
			anim.SetBool ("runR", true);
		}
		if (name == "jumpdrop") {
			anim.SetBool ("jumpdrop", true);
		}
	}
}
