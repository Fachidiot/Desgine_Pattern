using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OBSERVER;

public class ObserverOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Observer Pattern =====================");

        Player player = new Player("플레이어", 100);
        player.Attach(new MainScreen());
        player.Attach(new StatusScreen());
        player.Attach(new EnemyScreen());

        player.Health = 50;
        player.Health = 10;
    }
}
