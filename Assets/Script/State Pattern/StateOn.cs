using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using STATE;

public class StateOn : MonoBehaviour
{
    public const string BLIND = "Enemy Blind";
    public const string INJURED = "Enemy Attacked";

    void Start()
    {
        Debug.Log("===================== State Pattern =====================");
        Player player = new Player(new NormalState());

        player.Attack();
        player.Move();

        player.Attacked(BLIND);

        player.Attack();
        player.Move();

        player.Attacked(INJURED);

        player.Attack();
        player.Move();
    }
}
