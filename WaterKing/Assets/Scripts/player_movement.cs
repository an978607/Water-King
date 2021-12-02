using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Vector2 startPos;
    private int pixelDistToDetect = 50;
    private bool fingerDown;
    public string state = "neutral";
    private float time = 0;
    public SpriteRenderer spriteRenderer;
    public Sprite neutral;
    public Sprite jump;
    public Sprite duck;
    public Sprite rush;
    public Animator anim;
    public AudioSource effect;

    private float moveSpeed = 10;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // For touchscreen
        if(fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        if(fingerDown)
        {
            if(Input.touches[0].position.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;

                if(transform.position.y != 1)
                {
                    Move(Vector3.up);
                }
            }

            else if(Input.touches[0].position.x <= startPos.x - pixelDistToDetect)
            {
                fingerDown = false;
                UnityEngine.Debug.Log("Left");
            }

            else if (Input.touches[0].position.x >= startPos.x + pixelDistToDetect)
            {
                fingerDown = false;
                UnityEngine.Debug.Log("Right");
            }

            else if (Input.touches[0].position.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;

                if (transform.position.y != -3)
                {
                    Move(Vector3.down);
                }
            }
        }
        
        if(fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
            UnityEngine.Debug.Log("Tap");
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        */

        // For PC
        // reset back to neutral state
        if(time > 0)
        {
            time = time - Time.deltaTime;
        }

        else
        {
            state = "neutral";
            ChangeSprite(neutral);
        }

        // check press trigger
        if (fingerDown == false && Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            fingerDown = true;
        }

        // check lift trigger
        if (fingerDown)
        {
            // move up
            if (Input.mousePosition.y >= startPos.y + pixelDistToDetect)
            {
                fingerDown = false;

                if (transform.position.y > -1)
                {
                    return;
                }

                Move(Vector3.up);
            }

            // move left
            else if(Input.mousePosition.x <= startPos.x - pixelDistToDetect)
            {
                if(state == "rush")
                {
                    return;
                }

                else
                {
                    state = "rush";
                    time = 1;
                    ChangeSprite(rush);
                }

                fingerDown = false;
            }

            // move right
            else if (Input.mousePosition.x >= startPos.x + pixelDistToDetect)
            {
                if(state == "duck")
                {
                    return;
                }

                else
                {
                    state = "duck";
                    time = 1;
                    ChangeSprite(duck);
                }

                fingerDown = false;
            }

            // move down
            else if (Input.mousePosition.y <= startPos.y - pixelDistToDetect)
            {
                fingerDown = false;

                if (transform.position.y < -2.47)
                {
                    return;
                }

                Move(Vector3.down);
            }
        }

        // tap
        if(fingerDown && Input.GetMouseButtonUp(0))
        {
            if(state == "jump")
            {
                return;
            }

            else
            {
                state = "jump";
                time = 1;
                anim.SetTrigger("Jumping");
                effect.Play();
                
                //ChangeSprite(jump);
            }

            fingerDown = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    public void Move(Vector3 moveDirection)
    {
        targetPos = targetPos + 2 * moveDirection;
    }

    void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
}
