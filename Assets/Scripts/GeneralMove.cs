using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralMove : MonoBehaviour
{
    public float Speed, JumpPower;
    public GameObject[] Buttom;
    [HideInInspector]public Vector2 Velocity;
    private Rigidbody2D Player;
    private bool Jump = false, FaceLeft, FaceRigth, ColorRigth, ColorLeft;
    private int JumpCount = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        Player = GetComponent<Rigidbody2D>();
        Velocity = Vector2.zero;
        FaceLeft = false;
        FaceRigth = true;
        ColorRigth = false;
        ColorLeft = false;
    }
    public void Attakc()
    {

    }
    public void ClickDownJump()
    {
        Jump = true;
        Buttom[2].GetComponent<Image>().color = new Color(75 / 255.0f, 75 / 255.0f, 75 / 255.0f, 1);
    }
    public void JumpDownUp()
    {
        Buttom[2].GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        Jump = false;
        JumpCount += 1;
    }
    public void ClickDownRigth()
    {
        Velocity = Vector2.right;
        if(FaceRigth == false)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            FaceRigth = true;
            FaceLeft = false;
        }
        Buttom[0].GetComponent<Image>().color = new Color(75 / 255.0f, 75 / 255.0f, 75 / 255.0f, 1);
        ColorRigth = true;

    }
    public void ClickDownLeft()
    {
        Velocity = -Vector2.right;
        if (FaceLeft == false)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            FaceLeft = true;
            FaceRigth = false;
        }
        Buttom[1].GetComponent<Image>().color = new Color(75 / 255.0f, 75 / 255.0f, 75 / 255.0f, 1);
        ColorLeft = true;
    }
    public void ClicKUp()
    {
        Velocity = Vector2.zero;
        if (ColorRigth)
        {
            Buttom[0].GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            ColorRigth = false;
        }
        if (ColorLeft)
        {
            Buttom[1].GetComponent<Image>().color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            ColorLeft = false;
        }
        
    }
    public void MovePlayer()
    {
        transform.Translate(Velocity * Speed * Time.deltaTime);
        if (Jump && JumpCount > 0)
        {
            Player.AddForce(Vector2.up * JumpPower*1000 * Time.deltaTime);
            JumpCount -= 1;
        }

    }
    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        
    }
}
