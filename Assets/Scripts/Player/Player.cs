using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{

    [SerializeField] int amountOfDiamonds = 0;
    DungeonDwelver _input;


    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _spriteRenderer;
    float _horizontal;


    [SerializeField] float _jumpForce = 50f;
    [SerializeField] float _playerSpeed = 3f;
    


    [SerializeField] GameObject _raycastGroundLocation;
    [SerializeField] SpriteRenderer _swordArcSlashSprite;

    public int health { get ; set ; }
    public int AmountOfDiamonds {
        get { return amountOfDiamonds; }
        set { amountOfDiamonds = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        _input = new DungeonDwelver();
        _input.Player.Enable();
        _rb = GetComponent<Rigidbody2D>();   
        _anim = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(_input.Player.Attack.WasPerformedThisFrame())
        {
            Attack();
        }
    }

    private void Movement()
    {
        Debug.DrawRay(_raycastGroundLocation.transform.position, Vector2.down, Color.green);

        _horizontal = _input.Player.Move.ReadValue<Vector2>().x;

        if (_input.Player.Jump.WasPerformedThisFrame() && GroundRaycasting())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }

        if (_horizontal != 0)
            _spriteRenderer.flipX = _horizontal > 0 ? false : true;
            

        _anim.SetFloat("Horizontal", Mathf.Abs(_horizontal));
        _anim.SetBool("IsJumping", !GroundRaycasting());
        _rb.velocity = new Vector2(_horizontal * _playerSpeed, _rb.velocity.y);
    }

    public bool GroundRaycasting()
    {
        RaycastHit2D hit = Physics2D.Raycast(_raycastGroundLocation.transform.position, Vector2.down, 0.5f, 1 << 7);

        if (hit.collider != null)
            return true;
        else
            return false;
    }


    public void Attack()
    {
        _swordArcSlashSprite.flipY = _spriteRenderer.flipX;

        Vector3 newPos = _swordArcSlashSprite.transform.localPosition;

        if (_swordArcSlashSprite.flipY)
        {
            newPos.x = -0.25f;
            _swordArcSlashSprite.transform.localPosition = newPos;
        }else
        {
            newPos.x = 0.25f;
            _swordArcSlashSprite.transform.localPosition = newPos;
        }

        _anim.SetTrigger("AttackTrigger");
    }

    public void Damage(int damageAmount)
    {
        Debug.Log("Hit Player" + damageAmount);
    }
}
