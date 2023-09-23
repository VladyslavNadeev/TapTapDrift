using System.Collections;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class UITapToStartButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Animator _textTapToPlayAnimator;
    [SerializeField] private float _goingDownTimeToScaleTapToStartText = 3f;
    
    private IStateMachine<IGameState> _stateMachine;

    [Inject]
    public void Construct(IStateMachine<IGameState> stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Init()
    {
        StartCoroutine(CountdownToTextScaling());
    }

    private IEnumerator CountdownToTextScaling()
    {
        float goingDownTimer = _goingDownTimeToScaleTapToStartText;

        do
        {
            yield return new WaitForEndOfFrame();
            goingDownTimer -= Time.deltaTime;
            
            if (goingDownTimer <= 0.1f)
            {
                _textTapToPlayAnimator.enabled = true;
            }
        } while (goingDownTimer > 0);
    }

    private void OnButtonTapToPlayTapped()
    {
        _stateMachine.Enter<GameLoopState>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonTapToPlayTapped();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
