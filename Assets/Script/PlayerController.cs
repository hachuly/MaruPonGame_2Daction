using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private LifeScript gauge;
    private TimerController stopTime;
    private GhostSprites special;
    private float speed = 3f;
    private float jump = 700f;
    public int skill = 0;
    public bool kill = false;
    private bool killAll;
    public LayerMask groundLayer;
    public GameObject mainCamera;
    public GameObject gorlBar;
    public GameObject bullet;
    public GameObject but;
    public GameObject butPos;
    public bool onStop;

    private bool isGrounded;
    private Vector3 cameraPos;
    private Vector2 temp;
    private Vector2 butTemp;
    private Vector2 max;
    private Vector2 min;
    private Vector2 pos;
    private Rigidbody2D rigid2D;
    private Animator anim;
    private float JampRecastTimer;
    private float DashRecastTimer;
    private bool JampRecastTrigger;
    private bool gorlBool;
    private bool hitBool;
    private bool hitFlash;
    private int isFrame;
    private int isKillTime;
    private int isBullet;
    private int isFlashFrame;
    private string name;

    private float axis;

	// Use this for initialization
	void Start () {
        gauge = GameObject.Find("HP").GetComponent<LifeScript>();
        stopTime = GameObject.Find("TimerText").GetComponent<TimerController>();
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        special = GetComponent<GhostSprites>();
        special.getTrailSize(2);
        name = GetComponent<isName>().getName();

	}

    void Update(){
        if(gorlBool){
            stopTime.gaming_state(false);
        }else if(onStop){
            if(name == "z"){
                butController();
            }else if(name == "x"){
                bulletController();
            }

            if(kill){
                if(name == "z"){
                    hitBool = false;
                    if(isKillTime + 3 < Time.time){
                        kill = false;
                        skill = 0;
                        speed = 3f;
                        jump = 700f;
                        special.getTrailSize(2);
                    }else{

                        speed = 8f;
                        jump = 800f;
                        special.getTrailSize(7);
                    }

                }else if(name == "x"){
                    DashControll();
                    if(hitBool){
                        isFlash();
                        if(isFrame + 40 < Time.frameCount){
                            hitBool = false;
                            gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        }

                    }
                    if(Input.GetKeyDown(KeyCode.V)){
                        kill = false;
                        killRay();
                        gauge.inState(true);
                        gauge.skill();
                    }

                }

                //
                JumpControll();

            }else if(hitBool){
                isFlash();
                if(isFrame + 40 < Time.frameCount){
                    hitBool = false;
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
            }else{
                DashControll();
                JumpControll();
            }

        }

    }

	// Update is called once per frame
	void FixedUpdate () {
        if(gorlBool){

            isGrounded = Physics2D.Linecast(transform.position + transform.up * 1, transform.position - transform.up * 0.01f, groundLayer);
            if(isGrounded == true){
                anim.SetBool("Runner", true);
                anim.SetBool("Dash", false);
                rigid2D.velocity = new Vector2( 3f , rigid2D.velocity.y);
            }

            float velY = rigid2D.velocity.y;

            //移動速度0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true:false;

            //移動速度-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true:false;

            //結果をアニメータービューの変数へ反映
            anim.SetBool("isJumping", isJumping);
            anim.SetBool("isFalling", isFalling);
            anim.SetBool("isGround", isGrounded);

        }else if(onStop){
            if(hitBool != true){
                RunControll();
            }CameraControll();

        }

	}

    private void RunControll(){

        axis = Input.GetAxisRaw("Horizontal");

        if(axis != 0){
            rigid2D.velocity = new Vector2(axis * speed, rigid2D.velocity.y);
            temp = transform.localScale;
            temp.x = axis;
            transform.localScale = temp;
            anim.SetBool("Runner", true);

        }else{
            rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
            anim.SetBool("Runner", false);
        }
    }

    private void JumpControll(){

        //Linecastで足元に地面があるか判定する。

        isGrounded = Physics2D.Linecast(transform.position + transform.up * 1, transform.position - transform.up * 0.01f, groundLayer);

        if((isGrounded == true) && ((JampRecastTimer + 0.05f < Time.time))){
            if(Input.GetKeyDown(KeyCode.Space)){

                isGrounded = false;
                JampRecastTrigger = true;
                anim.SetBool("Runner", false);
                anim.SetBool("Dash", false);
                anim.SetTrigger("Jump");
                rigid2D.AddForce(transform.up*jump);
                JampRecastTimer = Time.time;

            }

            if(isGrounded == JampRecastTrigger){
                JampRecastTrigger = false;
                JampRecastTimer = Time.time;
            }

        }

        //上下への移動速度を習得
        float velY = rigid2D.velocity.y;

        //移動速度0.1より大きければ上昇
        bool isJumping = velY > 0.1f ? true:false;

        //移動速度-0.1より小さければ下降
        bool isFalling = velY < -0.1f ? true:false;

        //結果をアニメータービューの変数へ反映
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isFalling", isFalling);
        anim.SetBool("isGround", isGrounded);
    }

    private void DashControll(){

        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Z)){
                DashRecastTimer = Time.time;
                anim.SetBool("Dash", true);
                anim.SetBool("Runner", false);
            }
            if(Input.GetKey(KeyCode.Z)){

                speed = 6f;
                if(DashRecastTimer + 0.3f < Time.time){
                    speed = 3f;
                    anim.SetBool("Dash", false);
                    RunControll();
                }
            }else{
                speed = 3f;
                anim.SetBool("Dash", false);
            }

        }

    }

    private void CameraControll(){
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y , mainCamera.transform.position.z);

    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.tag == "tagGorl"){
            gorlBool = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "tagEnemy"){

            if(kill == false || name =="x"){
                if(isGrounded == true){
                    rigid2D.AddForce(transform.up * 150f);
                    rigid2D.AddForce(transform.right * -150f);
                }else{
                    rigid2D.AddForce(transform.up * 50f);
                    rigid2D.AddForce(transform.right * -30f);
                }
                hitBool = true;
                isFlashFrame = Time.frameCount;
                isFrame = Time.frameCount;
                anim.SetBool("Runner", false);
                anim.SetBool("Dash", false);
                anim.SetBool("isJumping", false);
                anim.SetBool("isFalling", false);
                anim.SetBool("Stay", true);

            }

        }

    }

    public string getName(){
        return name;
    }

    private void bulletController(){
        if(isBullet + 20 < Time.frameCount){
            if(Input.GetKeyDown(KeyCode.X)){
                isBullet = Time.frameCount;
                Instantiate(bullet, transform.position + new Vector3(0f, 0.5f, 0f), transform.rotation);
                    if((isGrounded == true) && ((JampRecastTimer + 0.05f < Time.time))){
                        anim.SetTrigger("stayShot");
                    }else{
                        anim.SetTrigger("jumpShot");
                }

            }

        }

    }

    public void butController(){
        if(Input.GetKeyDown(KeyCode.X)){
            anim.SetTrigger("stayShot");
            butPos = Instantiate(but) as GameObject;
            Rigidbody2D butRig2d;
            butRig2d = butPos.GetComponent<Rigidbody2D>();
            butPos.transform.position = gameObject.transform.position;
            if(axis != 0){
                butRig2d.velocity = new Vector2(axis, rigid2D.velocity.y);
                butTemp = transform.localScale;
                butTemp.x = axis;
                butPos.transform.localScale = butTemp;
            }else{
                butRig2d.velocity = new Vector2(0, rigid2D.velocity.y);
                butTemp = transform.localScale;
                butPos.transform.localScale = butTemp;
            }
            if(gameObject.transform.localScale.x == -1f){
                butPos.transform.position = new Vector3(gameObject.transform.position.x - 0.7f,gameObject.transform.position.y + 0.1f,gameObject.transform.position.z);
            }else if(gameObject.transform.localScale.x == 1f){
                butPos.transform.position = new Vector3(gameObject.transform.position.x + 0.7f,gameObject.transform.position.y + 0.1f,gameObject.transform.position.z);
            }

        }

    }

    public void skillGauge (int a){
        if(gauge.getState() == false){
            if(name == "x"){
                gauge.LifeDown(a + 50);
            }else if(name == "z"){
                gauge.LifeDown(a + 20);
            }

        }

        if(gauge.getState()){
            kill = true;
            if(name == "z"){
                isKillTime = (int)Time.time;
                gauge.skill();
            }

        }

    }

    public bool isKill(){
        return kill;
    }

    public bool isDestroy(){
        return killAll;
    }

    public void endDestroy(){
        killAll = false;
    }

    public void isFlash(){
        if(isFlashFrame + 5 < Time.frameCount){
            if(hitFlash){
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                hitFlash = false;
            }else{
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                hitFlash = true;

            }isFlashFrame = Time.frameCount;

        }

    }

    public void getState(bool n){
        onStop = n;
    }

    public void killRay(){
        int layer = 1 << 8;
        Ray ray = Camera.main.ScreenPointToRay(transform.position);
        Vector2 ray_position = (Vector2)ray.origin;
        RaycastHit2D[] hit;

        hit = Physics2D.CircleCastAll(ray.origin,12f, Vector2.zero);
        foreach(RaycastHit2D i in hit){
            if(i.collider.gameObject.tag == "tagEnemy"){
                i.collider.gameObject.GetComponent<EnemyController>().playSE();
                i.collider.gameObject.GetComponent<EnemyController>().dokan();

            }

        }

    }

}
