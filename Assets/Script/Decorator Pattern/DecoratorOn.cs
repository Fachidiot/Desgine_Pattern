using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DECORATOR;

public class DecoratorOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Decorator Pattern =====================");
        Player player = new Player();
        DefensiveMatrix defensiveMatrix = new DefensiveMatrix();

        defensiveMatrix.SetComponent(player);

        defensiveMatrix.UnderAttack(50);
        defensiveMatrix.UnderAttack(50);
        defensiveMatrix.UnderAttack(50);
    }
}
