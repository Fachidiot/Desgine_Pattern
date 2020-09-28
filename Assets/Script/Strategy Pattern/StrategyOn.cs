using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STRATEGY;

public class StrategyOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Strategy Pattern =====================");
        Mob AllRounder = new Knight(new MoveLand(), new Attack());
        AllRounder.Move();
        AllRounder.Attack();

        AllRounder = new Magician(new MoveSky(), new Attack());
        AllRounder.Move();
        AllRounder.Attack();

        AllRounder = new Healer(new MoveLand(), new NoAttack());
        AllRounder.Move();
        AllRounder.Attack();

        AllRounder = new Healer(new MoveLand(), new SpecialAttack());
        AllRounder.Move();
        AllRounder.Attack();
    }
}
