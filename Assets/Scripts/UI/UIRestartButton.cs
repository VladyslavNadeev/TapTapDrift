using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class UIRestartButton : MonoBehaviour
{
    private IStateMachine<IGameState> _stateMachine;

    [Inject]
    public void Construct(IStateMachine<IGameState> stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnRestartTapped()
    {
        Restart();
    }

    private void Restart()
    {
        _stateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
    }

}
