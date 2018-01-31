using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    Animator anim;
    Rigidbody2D rb2d;
    SpriteRenderer sr;
    public Camera cam;
    private float speed = 5f;
    private float jumpForce = 250f;
    private bool facingRight = true;
    AudioSource sound;
    float time = 50f;
    float timelapse = 0f;
    bool jump = false;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        anim = GetComponent<Animator>();        sound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update () {

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        if (move != 0) {
            rb2d.transform.Translate(new Vector3(1, 0, 0) * move * speed * Time.deltaTime);
            cam.transform.position = new Vector3(rb2d.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            facingRight = move > 0;
        }
        
        sr.flipX = !facingRight;
        if(jump == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                rb2d.AddForce(Vector2.up * jumpForce);
                sound.Play();
            }
        }
            
        
        if(jump == true)
        {
            timelapse += Time.fixedTime;
            if(timelapse >= time)
            {
                jump = false;
                timelapse = 0;
            }
        }
        
	}
}
