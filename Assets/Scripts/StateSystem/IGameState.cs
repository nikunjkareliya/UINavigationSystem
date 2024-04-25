using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.StateSytem
{
    public interface IGameState
    {
        public int State { get; }        

        public void EnterState();
        public void ExitState();
    }
}