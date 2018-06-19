namespace PlayerMovement
{
    
    using System.Collections.Generic;
    using InControl;
    using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;

        public Camera Camera;

        Vector3 movement;
        Rigidbody playerRigidbody;
        int floorMask;
        float camRayLength = 100f;

        void Awake()
        {
            floorMask = LayerMask.GetMask("Floor");
            playerRigidbody = GetComponent <Rigidbody> ();
        }

        void FixedUpdate()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            var device = InputManager.ActiveDevice;

            /*float h = Input.GetAxisRaw("PS4_DPadHorizontal");
            float v = Input.GetAxisRaw("PS4_DPadVertical");*/

            Move (h, v);
        }

        void Move(float h, float v)
        {
            float translationVertical = v;
            translationVertical = translationVertical * speed;
            translationVertical *= Time.deltaTime;
             
            float translationHorizontal = h;
            translationHorizontal = translationHorizontal * speed;
            translationHorizontal *= Time.deltaTime;
             
            movement = Camera.transform.TransformDirection (0, 0, -1);
            playerRigidbody.position -= new Vector3((movement.x * translationVertical), 0,(movement.z * translationVertical) );
            movement = Camera.transform.TransformDirection (-1, 0, 0);
             
            playerRigidbody.position -= new Vector3 ((movement.x * translationHorizontal), 0,(movement.z * translationHorizontal) );
        }


        void OnGUI()
        {
            const float h = 22.0f;
            var y = 10.0f;

            GUI.Label( new Rect( 10, y, 300, y + h ), "Holaaaa" );
        }

        void OnCollisionStay(Collision collision)
        {
			if (collision.gameObject.name == "ArmChair_off") {
				if (Input.GetKeyDown ("space") || Input.GetKeyDown("joystick button 1")) {
					int idx = collision.gameObject.transform.GetSiblingIndex ();
					GameObject s = collision.gameObject.transform.parent.GetChild (idx + 1).gameObject;
					var active_screen = s.transform.Find ("active_screen").gameObject;
					var blue_screen = s.transform.Find ("blue_screen").gameObject;
					Debug.Log (active_screen);
					if (active_screen.GetComponent<RandomActive>().enabled) {
						active_screen.GetComponent<RandomActive> ().onClickScreen();
						blue_screen.GetComponent<OnLockComputer>().onLockScreen();
					}
				}
			}

			if (collision.gameObject.tag == "Wall") {
				playerRigidbody.velocity = Vector3.zero;
			}
        }
    }

}
