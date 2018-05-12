using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Instance { get; private set; }

    private readonly Dictionary<PlayerInteractor, InRangeListener> _playerToActive =
        new Dictionary<PlayerInteractor, InRangeListener>();

    private InteractionController()
    {
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else Instance = this;
    }

    public void NotifyActiveChanged(PlayerInteractor playerInteractor, InRangeListener active)
    {
        UpdatePlayerToActive(playerInteractor, active);
    }

    private void UpdatePlayerToActive(PlayerInteractor playerInteractor, InRangeListener active)
    {
        var playerIndex = playerInteractor.Player.PlayerIndex;

        if (!_playerToActive.ContainsKey(playerInteractor))
        {
            _playerToActive.Add(playerInteractor, active);

            if (active != null)
                active.NotifyInRange(playerIndex);

            return;
        }

        _playerToActive[playerInteractor]?.NotifyOutOfRange(playerIndex);
        _playerToActive[playerInteractor] = active;

        if (active == null) return;
        active.NotifyInRange(playerIndex);
    }
}