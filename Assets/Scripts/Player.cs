using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _spriteRenderer;

    [SerializeField] float _jumpForce = 50f;
    [SerializeField] float _playerSpeed = 3f;
    


    [SerializeField] GameObject _raycastGroundLocation;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(_raycastGroundLocation.transform.position, Vector2.down, Color.green);

        var horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && GroundRaycasting())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }

        if(horizontal != 0)
            _spriteRenderer.flipX = horizontal > 0 ? false : true;

        _anim.SetFloat("Horizontal", Mathf.Abs(horizontal));
        _rb.velocity = new Vector2(horizontal * _playerSpeed, _rb.velocity.y);
    }


    public bool GroundRaycasting()
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastGroundLocation.transform.position, Vector2.down, 0.5f, 1 << 7);


        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            return true;
        }
        else
            return false;
    }
}
