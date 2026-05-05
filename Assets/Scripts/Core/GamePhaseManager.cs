using System;
using UnityEngine;

// Manages the current game phase and notifies listeners when it changes
public class GamePhaseManager : MonoBehaviour
{
    public static GamePhaseManager Instance { get; private set; }

    [SerializeField] private GamePhase currentPhase = GamePhase.Ingredients;

    public GamePhase CurrentPhase => currentPhase;

    public event Action<GamePhase> PhaseChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void SetPhase(GamePhase newPhase)
    {
        if (currentPhase == newPhase) return;

        currentPhase = newPhase;
        PhaseChanged?.Invoke(currentPhase);

        Debug.Log($"Game phase changed to: {currentPhase}");
    }
}