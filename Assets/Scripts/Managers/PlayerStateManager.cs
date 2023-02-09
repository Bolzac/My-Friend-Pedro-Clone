using System;
using UnityEngine;

namespace Managers
{
    public class PlayerStateManager : MonoBehaviour
    {
        public static PlayerStateManager PlayerManager;
        
        private PlayerState _currentState;

        [SerializeField] private Animator animator;
        
        private static readonly int Ground = Animator.StringToHash("Ground");
        private static readonly int Descend = Animator.StringToHash("Descend");
        private static readonly int Ascend = Animator.StringToHash("Ascend");
        private static readonly int Wall = Animator.StringToHash("Wall");
        private static readonly int Slide = Animator.StringToHash("Slide");

        private void Start()
        {
            PlayerManager = this;
        }

        public void ChangeState(PlayerState newState)
        {
            _currentState = newState;
            switch (_currentState)
            {
                case PlayerState.Ground:
                    animator.SetBool(Ground,true);
                    animator.SetBool(Descend,false);
                    animator.SetBool(Slide,false);
                    break;
                case PlayerState.Wall:
                    animator.SetBool(Ascend,false);
                    animator.SetBool(Descend,false);
                    animator.SetBool(Wall,true);
                    break;
                case PlayerState.Slide:
                    animator.SetBool(Slide,true);
                    animator.SetBool(Wall,false);
                    break;
                case PlayerState.Descend:
                    animator.SetBool(Ascend,false);
                    animator.SetBool(Descend,true);
                    animator.SetBool(Slide,false);
                    break;
                case PlayerState.Ascend:
                    animator.SetBool(Ascend,true);
                    animator.SetBool(Ground,false);
                    animator.SetBool(Slide,false);
                    break;
                case PlayerState.Air:
                    animator.SetBool(Wall,false);
                    animator.SetBool(Slide,false);
                    break;
                case PlayerState.NoneAir:
                    animator.SetBool(Ascend,false);
                    animator.SetBool(Descend,false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }
        }
    }
}

public enum PlayerState
{
    Ground,
    Wall,
    Slide,
    Descend,
    Ascend,
    Air,
    NoneAir
}