﻿namespace Infrastructure.StateMachine.Game.States
{
    public interface IState : IExitable
    {
        void Enter();
    }
}