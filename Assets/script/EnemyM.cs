using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyM : MonoBehaviour
{
    [Header ("Propiedades")]
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    private enum StateEnemy{None, Chase, Attack};
    [SerializeField] private StateEnemy stateEnemy; 
    
    public Transform Target;
    private Vector2 pTarget;
    public GameObject Attack;
    private Collider2D colAttack;
    [Header ("Variables")]
    [Range(1f,10f)] public float speedMove;
    [Range(1f,10f)] public float rAttack;
    public bool onAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        sp= GetComponent<SpriteRenderer>();
        pTarget= new Vector2(Target.position.x, Target.position.y);
        stateEnemy= StateEnemy.None;
        colAttack= Attack.GetComponent<Collider2D>();
        onAttack=false;
        offTAttack();
    }

    // Update is called once per frame
    void Update()
    {
        sp.flipX= (Target.position.x > transform.position.x)? true:false;
        switch(stateEnemy){
            case StateEnemy.None:
                break;
            case StateEnemy.Chase:
                EnemyChase();
                break;
            case StateEnemy.Attack:
                EnemyAttack();
                break;
            default:
                Debug.Log("Erron");
                break;
        }
    }
    private void EnemyChase(){
        anim.SetBool("Attack",false);
        transform.position= Vector2.MoveTowards(transform.position, Target.position, speedMove * Time.deltaTime);
        if(Vector2.Distance(
            new Vector2 (transform.position.x, transform.position.y),
            new Vector2 (Target.position.x, Target.position.y)) < rAttack){
            DirectionAttack();
            stateEnemy= StateEnemy.Attack;
        }
    }
    public void DirectionAttack(){
        onAttack=true;
        float dx= Vector2.Distance(
            new Vector2(transform.position.x, transform.position.z),
            new Vector2(Target.position.x, Target.position.z));
        float dy= Vector2.Distance(
            new Vector2(transform.position.y, transform.position.z),
            new Vector2(Target.position.y, Target.position.z));
        if(dx > dy){
            if(transform.position.x < Target.position.x){//atacar izq
                Attack.transform.localPosition= new Vector3 (1,0,0);
                return;
            }
            if(transform.position.x > Target.position.x){//atacar der
                Attack.transform.localPosition= new Vector3 (-1,0,0);
                return;
            }
        }else{
            if(transform.position.y < Target.position.y){//atacar arriba
                Attack.transform.localPosition= new Vector3 (0,1,0);
                return;
            }
            if(transform.position.y > Target.position.y){//atacar abajo
                Attack.transform.localPosition= new Vector3 (0,-1,0);
                return;
            }
        }
    }
    public void EnemyAttack(){
        if(onAttack){ //atacamos
            //sp.flipX=vFlip;
            anim.SetBool("Attack",true);
        }
    }
    private void EnemyAttackEnd(){
        onAttack=false;
        stateEnemy= StateEnemy.Chase;
        Attack.transform.localPosition= Vector3.zero;
    }
    public void ChangeStateNone(bool b){
        //Verdadero: Enemigo en cámara //Falso: Enemigo fuera de cámara
        if(b){
            stateEnemy= StateEnemy.Chase;
        }else{
            stateEnemy= StateEnemy.None;
        }
    }
    public void onTAttack(){
        colAttack.enabled= true;
    }
    public void offTAttack(){
        colAttack.enabled= false;
    }
    private void OnDrawGizmos() {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, rAttack);   
    }
}
