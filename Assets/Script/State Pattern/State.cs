using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STATE
{
    abstract class MobState
    {
        public abstract void Move();
        public abstract void Attack();
    }

    class NormalState : MobState
    {
        public override void Move()
        {
            Debug.Log("움직일 수 있는 상태입니다.");
        }

        public override void Attack()
        {
            Debug.Log("공격할 수 있는 상태입니다.");
        }
    }

    class BlindState : MobState
    {
        public override void Move()
        {
            Debug.Log("움직일 수 없는 상태입니다.");
        }

        public override void Attack()
        {
            Debug.Log("공격할 수 없는 상태입니다.");
        }
    }
    
    class InjuredState : MobState
    {
        public override void Move()
        {
            Debug.Log("움직일 수 있는 상태입니다.");
        }

        public override void Attack()
        {
            Debug.Log("공격할 수 없는 상태입니다.");
        }
    }

    class Player
    {
        private MobState state;

        public Player(MobState state)
        {
            this.state = state;
        }

        public void Attacked(string stateattacked)
        {
            switch (stateattacked)
            {
                case "Enemy Blind":
                    Debug.Log("적에게 섬광 상태 공격을 당함");
                    this.state = new BlindState();
                    break;
                case "Enemy Attacked":
                    Debug.Log("적에게 심각한 공격을 받음");
                    this.state = new InjuredState();
                    break;
            }
        }

        public void Move()
        {
            state.Move();
        }

        public void Attack()
        {
            state.Attack();
        }
    }
}
