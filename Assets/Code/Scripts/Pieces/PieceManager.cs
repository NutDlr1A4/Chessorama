using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PieceManager : MonoBehaviour
{
    [SerializeField] private Board board;
    [SerializeField] private Transform pieces;

    [Header("Selected Piece Info")]
    [SerializeField] private Piece selected_piece;
    [SerializeField] private Vector2 selected_piece_origin;

    private InputSystem_Actions controls;
    private Camera main_camera;

    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Enable();
        controls.Player.Select.performed += OnMousePress;
        controls.Player.Select.canceled += OnMouseRelease;

        main_camera = Camera.main;

        foreach (Transform piece in pieces.transform) {
            piece.localPosition = board.SnapToGrid(new Vector2(piece.position.x, piece.position.y));
        }
    }

    void Update()
    {
        if (selected_piece != null) {
            Vector3 world_pos = main_camera.ScreenToWorldPoint(controls.Player.Point.ReadValue<Vector2>());
            selected_piece.transform.position = new Vector3(world_pos.x, world_pos.y, 0);
        }
    }

    private void OnMousePress(InputAction.CallbackContext context) {
        Vector2 mouse_world_pos = main_camera.ScreenToWorldPoint(controls.Player.Point.ReadValue<Vector2>());

        foreach (Transform piece in pieces.transform) {
            if (piece.gameObject.GetComponent<BoxCollider2D>().OverlapPoint(mouse_world_pos)) {
                selected_piece = piece.gameObject.GetComponent<Piece>();
                selected_piece_origin = selected_piece.GetPositionInGrid();
                break;
            }
        }
    }

    private void OnMouseRelease(InputAction.CallbackContext context) {
        if (selected_piece != null) {
            if (board.IsPointInside(selected_piece.transform.position)) {
                selected_piece.SetPositionInGrid(board.GetMouseHoverGrid());
            }
            else {
                selected_piece.SetPositionInGrid(selected_piece_origin);
            }
        }

        selected_piece = null;
    }
}

/*
using UnityEngine;
using UnityEngine.InputSystem;

public class PieceManager : MonoBehaviour
{
    [SerializeField] private Piece selected_piece;

    private InputSystem_Actions controls;
    private Camera main_camera;

    public void SetSelectedPiece(Piece piece) {
        selected_piece = piece;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Enable();
        controls.Player.Select.canceled += OnMouseRelease;

        main_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected_piece != null) {
            Vector3 pos = main_camera.ScreenToWorldPoint(controls.Player.Point.ReadValue<Vector2>());
            selected_piece.gameObject.transform.position = new Vector2(pos.x, pos.y);
        }
    }

    private void OnMouseRelease(InputAction.CallbackContext context)
    {
        if (selected_piece != null)
        {
            Vector3 piece_pos = selected_piece.gameObject.transform.localPosition;
            selected_piece.SetBoardPosition(new Vector2(piece_pos.x, piece_pos.y));
            selected_piece = null;
        }
    }
}

*/