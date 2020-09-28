using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STRATEGY
{
    abstract class Moveable
    {
        public abstract void Move();
    }

    class MoveLand : Moveable
    {
        public override void Move()
        {
            Debug.Log("Moveing through Land");
        }
    }
    
    class MoveSky : Moveable
    {
        public override void Move()
        {
            Debug.Log("Moveing through Sky");
        }
    }

    abstract class Attackable
    {
        public abstract void AttackEnemy();
    }

    class Attack : Attackable
    {
        public override void AttackEnemy()
        {
            Debug.Log("Attacking Enemy");
        }
    }

    class NoAttack : Attackable
    {
        public override void AttackEnemy()
        {
            Debug.Log("I can't Attack");
        }
    }

    class SpecialAttack : Attackable
    {
        public override void AttackEnemy()
        {
            Debug.Log("Special Attack");
        }
    }

    class Mob
    {
        private Moveable moveable;
        private Attackable attackable;

        public Mob(Moveable moveable, Attackable attackable)
        {
            this.moveable = moveable;
            this.attackable = attackable;
        }

        public void Attack()
        {
            attackable.AttackEnemy();
        }

        public void Move()
        {
            moveable.Move();
        }

        public Moveable MoveAble { set { this.moveable = value; } }
    }

    class Knight : Mob
    {
        public Knight (Moveable moveable, Attackable attackable) : base(moveable, attackable)
        {
        }
    }

    class Magician : Mob
    {
        public Magician(Moveable moveable, Attackable attackable) : base(moveable, attackable)
        {
        }
    }

    class Healer : Mob
    {
        public Healer (Moveable moveable, Attackable attackable) : base(moveable, attackable)
        {
        }
    }
}
