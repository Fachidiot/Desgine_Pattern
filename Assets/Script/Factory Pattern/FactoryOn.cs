using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FACTORY;

public class FactoryOn : MonoBehaviour
{
    void Start()
    {
        Debug.Log("===================== Factory Pattern =====================");

        FactoryModule[] factories = new FactoryModule[2];

        factories[0] = new NotebookModule();
        factories[1] = new TabletModule();

        List<product> AllProducts = new List<product>();
        AllProducts.Add(factories[0].MakeProduct("gram", 1));
        AllProducts.Add(factories[1].MakeProduct("Samsung s7", 1));

        AllProducts[0].Show();
        product notebook = AllProducts[0];
        AllProducts[1].Work(ref notebook);
    }
}
