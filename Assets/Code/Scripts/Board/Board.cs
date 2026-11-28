using UnityEngine;

public class Board : MonoBehaviour
{
    private InputSystem_Actions controls;
    private Camera main_camera;

    [SerializeField] private Transform grid_origin;

    public Vector2 SnapToGrid(Vector2 world_pos) {
        Vector2 mouse_pos_world = world_pos - new Vector2(grid_origin.position.x, grid_origin.position.y);
        return new Vector2(Mathf.Round(mouse_pos_world.x), Mathf.Round(mouse_pos_world.y));
    }

    public Vector2 GetMouseHoverGrid() {
        return SnapToGrid(main_camera.ScreenToWorldPoint(controls.Player.Point.ReadValue<Vector2>()));
    }

    public bool IsPointInside(Vector2 point) {
        Vector2 grid_pos = SnapToGrid(point);
        return grid_pos.x >= 0 && grid_pos.x < 8 && grid_pos.y >= 0 && grid_pos.y < 8;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new InputSystem_Actions();
        controls.Player.Point.Enable();

        main_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
