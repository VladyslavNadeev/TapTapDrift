using System.ComponentModel;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.Game.States;
using JetBrains.Annotations;
using UnityEngine;

namespace DebuggerOptions
{
    public class SROptionsContainer
    {
        private readonly IStateMachine<IGameState> _stateMachine;

        public SROptionsContainer(IStateMachine<IGameState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        [Category("Debug"), UsedImplicitly]
        public void PrintMessageToConsole() => Debug.Log("SROptions work's perfect!");
    }
}