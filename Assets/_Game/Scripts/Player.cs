using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundPlayer;
    [SerializeField] private float speed=10;
    private bool isGrounded = true;
    private bool isJumping= false;
    private bool isAttack= false;
    private bool isDeath= false;
    private float horizontal;
    private string currentAnimName;
    private int coin = 0 ;
    [SerializeField] private float jumpForce = 350;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeath){
            
            return;
        }
        isGrounded = CheckGrounded();
        horizontal = Input.GetAxisRaw("Horizontal"); // di chuyển với chiều ngang
        //float vertical = Input.GetAxisRaw("Vertical");  di chuyển với chiều dọc
        //Debug.Log(CheckGrounded());
        if(isAttack){
            rb.velocity=Vector2.zero;
            return;
        }
        if(isGrounded){
            if(isJumping){
                return;
            }

            if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                Jump();
            }   
            if(Mathf.Abs(horizontal) >0.1f){
                ChangeAnim("run");
            }
            if(Input.GetKey(KeyCode.C) && isGrounded){
                Attack();
                
            }
            if(Input.GetKey(KeyCode.V) && isGrounded){
                Throw();
            }
        }

        if( !isGrounded && rb.velocity.y <0 ){
                ChangeAnim("fall");
                isJumping = false;
        }
    }
    private void FixedUpdate(){
        
        move();
    }
    private void move(){
        if(Mathf.Abs(horizontal) >0.1f){
            ChangeAnim("run");
            rb.velocity = new Vector2(horizontal*Time.fixedDeltaTime * speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0,horizontal >0 ? 0: 180,0)); 
        }else if(isGrounded && !isJumping && !isAttack){
            ChangeAnim("idle");
            rb.velocity = Vector2.zero;
        }
    }

    private bool CheckGrounded(){
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,1.1f,groundPlayer);
        return hit.collider!= null; //trả về collider đầu tiên mà tia hit chạm vô
        
    }

        private void Attack(){
            ChangeAnim("attack");
            isAttack=true;
            Invoke(nameof(ResetAttack),0.5f);
        }
        private void Throw(){
            ChangeAnim("throw");
            isAttack=true;
            Invoke(nameof(ResetAttack),0.5f);
            

        }
        private void ResetAttack(){
            isAttack=false;
            ChangeAnim("idle");
        }
        private void Jump(){
            isJumping = true;
            ChangeAnim("jump");
            rb.AddForce(jumpForce * Vector2.up);
        }

        //ChangeAnim dùng cho mọi project
        private void ChangeAnim(string animName){
            if(currentAnimName != animName){
                anim.ResetTrigger(currentAnimName);
                currentAnimName = animName;
                anim.SetTrigger(currentAnimName);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Coin"){
            Debug.Log("Coin" + collision.gameObject.name);
            coin++;
            Destroy(collision.gameObject);
        }
        

    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag =="DeathZone"){
                    Debug.Log(collision.gameObject.name);
                    isDeath= true;
                    ChangeAnim("die");
                    
                }
            }
    
}
