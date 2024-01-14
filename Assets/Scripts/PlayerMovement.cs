using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    int current_Position;
    public float for_Speed;
    public Transform center_Pos;
    public Transform left_Pos;
    public Transform right_Pos;
    public float side_Speed;
    public Animator anim;
    public Text coin;
    int i = 0;
    public static int CurrentTile = 0;
    public Rigidbody rb;
    public float jumpAmount = 2;
    public bool inJump;
    //public float gravityScale = 5;
    private float y;
    public bool isGrounded;
    void Start()
    {
        current_Position = 0;
        anim = GetComponent<Animator>();
    }

   


    //private void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
        
    //}

    void Update()
    {
        
        
            
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + for_Speed * Time.fixedDeltaTime);
        //for_Speed = for_Speed + 0.005f *Time.deltaTime;
        

       
        if (current_Position == 0)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3 (center_Pos.position.x, transform.position.y, transform.position.z), side_Speed * Time.deltaTime);
        }

        if (current_Position == 1)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(left_Pos.position.x, transform.position.y, transform.position.z), side_Speed * Time.deltaTime);
        }

        if (current_Position == 2)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(right_Pos.position.x, transform.position.y, transform.position.z), side_Speed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (current_Position == 0)
            {
                current_Position = 1;
            }

            else if (current_Position == 2)
            {
                current_Position = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (current_Position == 1)
            {
                current_Position = 0;
            }

            else if (current_Position == 0)
            {
                current_Position = 2;
            }
        }



        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            anim.SetBool("Jump", true);
           
            rb.AddForce(transform.up * jumpAmount, ForceMode.Impulse);
            isGrounded =false;
            StartCoroutine(Jump());

        }

      


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetBool("Slide", true);
        }

        else
        {
            anim.SetBool("Slide", false);

        }

    }

    void ToggleOff(string Name)
    {
        anim.SetBool(Name, false);
    }


    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log("" + coll.gameObject.name);
        if (coll.gameObject.tag == "Coin")
        {
            Debug.Log("" + coll.gameObject);
            Destroy(coll.gameObject);
            i++;
            coin.text = i.ToString();

        }

        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Run", true);

        }

    }





    //private void OnAnimatorMove()
    //{
    //    if (anim.GetBool("Jump"))
    //    {

    //    }
    //    else
    //    {

    //    }
    //}

    IEnumerator Jump()
    {
        anim.SetInteger("IsJump", 1);
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("IsJump", 0);
    }

}
