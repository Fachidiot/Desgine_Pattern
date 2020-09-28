using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DECORATOR
{
    abstract class Mob
    {
        public int i_Health = 100;
        public abstract void UnderAttack(int Damage);
    }

    class Player : Mob
    {
        public override void UnderAttack(int Damage)
        {
            i_Health -= Damage;
            Debug.Log("남은 체력 : " + i_Health + ", 받은 데미지 : " + Damage);
        }
    }

    abstract class MobDecorator : Mob
    {
        private Mob component;

        public void SetComponent(Mob component)
        {
            this.component = component;
        }

        public override void UnderAttack(int Damage)
        {
            if (component != null)
                component.UnderAttack(Damage);
        }
    }

    class DefensiveMatrix : MobDecorator
    {
        private int AddHealth = 100;
        private int Damage = 0;

        public override void UnderAttack(int damage)
        {
            CheckDefensiveMatrix(damage);
            base.UnderAttack(Damage);
        }

        public void CheckDefensiveMatrix(int damage)
        {
            int remainHealth = AddHealth - damage;

            if(remainHealth >= 0)
            {
                // 방어막이 데미지를 모두 흡수했을때
                AddHealth -= damage;
                Debug.Log("보호막으로 데미지 " + damage + "모두 흡수, 남은 보호막 : " + remainHealth);
                Damage = 0;
            }

            else
            {
                // 방어막이 모두 닳았을때
                if(AddHealth  == 0)
                {
                    // 기존의 방어막이 없었을때
                    Debug.Log("보호막으로 흡수 불가능, 남은 보호막 : 0");
                    Damage = damage;
                }

                else
                {
                    // 기존의 방어막이 있는데 다 소멸되었을때
                    Debug.Log("보호막으로 데미지 " + (damage - AddHealth) + "만 흡수 가능, 남은 보호막 : 0");
                    AddHealth = 0;
                }
            }
        }
    }
}
