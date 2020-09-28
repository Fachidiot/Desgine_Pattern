using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using COMMAND;

public class CommandOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Command Pattern =====================");

        MapEditor mapEditor = new MapEditor();

        mapEditor.Create("마린1", 100, 200);
        mapEditor.Create("마린2", 200, 400);
        mapEditor.Create("마린3", 300, 600);
        mapEditor.Delete("마린2", 300, 600);

        mapEditor.Undo(3);
        mapEditor.Redo(3);
    }
}
