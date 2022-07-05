using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentB : MonoBehaviour
{


    private bool isMoving = false;

    private Vector3 targetP;


    [SerializeField] float speed = 0.5f;

    private Animator animator;
    private bool lookRight = true;

    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(1))
        {
           
            SetTargetPosition();
        }

        if (isMoving)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
            Move();
        }

    }

    private void SetTargetPosition()
    {
        targetP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetP.z = transform.position.z;

        isMoving = true;

        animator.Play("run");
        GetComponent<AudioSource>().PlayOneShot(clip);
        if (targetP.x > transform.position.x && lookRight) Flip();
        if (targetP.x < transform.position.x && !lookRight) Flip();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetP, speed * Time.deltaTime);
        if (transform.position == targetP)
        {
            isMoving = false;
            animator.Play("Idel");
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<MovmentB>().PlayAnimation();
    }

    public void PlayAnimation()
    {
        animator.Play("Idel");
    }
}
