using UnityEngine;

public enum PieceType {
    PAWN,
    ROOK,
    KNIGHT,
    BISHOP,
    QUEEN,
    KING
};

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceType type = PieceType.PAWN;
    [SerializeField] private bool is_selected = false;

    [Header("White sprites")]  
    [SerializeField] private Sprite sprite_pawn_1;
    [SerializeField] private Sprite sprite_rook_1;
    [SerializeField] private Sprite sprite_knight_1;
    [SerializeField] private Sprite sprite_bishop_1;
    [SerializeField] private Sprite sprite_queen_1;
    [SerializeField] private Sprite sprite_king_1;

    public void SetPositionInGrid(Vector2 grid_pos) {
        transform.localPosition = grid_pos;
    }

    public Vector2 GetPositionInGrid() {
        return new Vector2(transform.localPosition.x, transform.localPosition.y);
    }

    public void SetPieceType(PieceType piece_type) {
        SpriteRenderer sprite_renderer = GetComponent<SpriteRenderer>();

        switch (piece_type) {
            case PieceType.PAWN:
                sprite_renderer.sprite = sprite_pawn_1;
                break;
            case PieceType.ROOK:
                sprite_renderer.sprite = sprite_rook_1;
                break;
            case PieceType.KNIGHT:
                sprite_renderer.sprite = sprite_knight_1;
                break;
            case PieceType.BISHOP:
                sprite_renderer.sprite = sprite_bishop_1;
                break;
            case PieceType.QUEEN:
                sprite_renderer.sprite = sprite_queen_1;
                break;
            case PieceType.KING:
                sprite_renderer.sprite = sprite_king_1;
                break;
            default:
                break;
        }

        type = piece_type;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPieceType(type);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Piece : MonoBehaviour
{
    [SerializeField] private PieceManager manager;

    private InputSystem_Actions controls;

    private Camera main_camera;
    private BoxCollider2D box_collider;

    [SerializeField] private bool is_selected = false;

    void Awake() {
        controls = new InputSystem_Actions();
        controls.Enable();
        controls.Player.Select.performed += OnClick;

        box_collider = GetComponent<BoxCollider2D>();
        main_camera = Camera.main;
    }

    public void SetBoardPosition(Vector2 board_pos) {
        gameObject.transform.localPosition = new Vector3(Mathf.Round(board_pos.x), Mathf.Round(board_pos.y), 0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Vector2 mouse_pos = controls.Player.Point.ReadValue<Vector2>();
        bool mouse_inside = box_collider.OverlapPoint(main_camera.ScreenToWorldPoint(mouse_pos));

        if (mouse_inside) {
            manager.SetSelectedPiece(this);
        }
    }
}

*/