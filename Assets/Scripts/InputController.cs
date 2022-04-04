using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _isMovingUp;
    private bool _isMovingLeft;
    private bool _isMovingRight;
    private bool _isMovingDown;
    private bool _isSaving;

    [SerializeField] private string _moveRight;
    [SerializeField] private string _moveLeft;
    [SerializeField] private string _moveUp;
    [SerializeField] private string _moveDown;
    [SerializeField] private string _saving;


    public bool IsMovingUp => _isMovingUp;

    public bool IsMovingLeft => _isMovingLeft;

    public bool IsMovingRight => _isMovingRight;

    public bool IsMovingDown => _isMovingDown;

    public bool IsSaving => _isSaving;

    private static InputController _instance = null;

    public static InputController Instance => _instance;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.GetCurrentLevel() > 0)
        {
            _isSaving = Input.GetButtonDown(_saving);
        }
        _isMovingUp = Input.GetButton(_moveUp);
        _isMovingLeft = Input.GetButton(_moveLeft);
        _isMovingRight = Input.GetButton(_moveRight);
        _isMovingDown = Input.GetButton(_moveDown);
    }
}