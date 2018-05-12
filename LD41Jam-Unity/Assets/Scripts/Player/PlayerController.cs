using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInteractor Interactor;
    public int PlayerIndex;

    private Mover _mover;

    public Inventory Inventory { get; set; }

    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
        _mover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxisRaw($"Joy{PlayerIndex}Horizontal");
        var moveVertical = Input.GetAxisRaw($"Joy{PlayerIndex}Vertical");
        var movementDirection = new Vector2(moveHorizontal, moveVertical);
        if (Input.GetButtonDown($"Joy{PlayerIndex}Fire1")) Interactor.PushToActiveInteractable();
        if (Input.GetButtonDown($"Joy{PlayerIndex}Fire2")) Interactor.UseActiveInteractable();
        if (Input.GetButtonDown($"Joy{PlayerIndex}Fire3")) Interactor.PopFromActiveInteractable();

        _mover.Move(movementDirection);
    }
}