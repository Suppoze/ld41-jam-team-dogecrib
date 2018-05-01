using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentLevel = 1;

    private OrderController _orderController;

    private void Awake()
    {
        _orderController = GetComponent<OrderController>();
    }

    private void Start()
    {
        StartLevel(1);
    }

    public void StartLevel(int levelCount)
    {
        _orderController.PlacerOrders(levelCount);
    }

    public void EndLevel(bool win)
    {
        if (win) CurrentLevel++;
        else CurrentLevel = 1;

        StartLevel(CurrentLevel);
    }

}
