using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FACTORY
{
    public abstract class product
    {
        public string str_name;
        public int i_number;

        public abstract void Show();
        public abstract void Work(ref product _workwith);
    }

    public class Notebook : product
    {
        public Notebook(string name, int number)
        {
            this.str_name = name;
            this.i_number = number;
            Debug.Log(str_name + i_number + "생성 완료");
        }

        public override void Show()
        {
            Debug.Log("제품명 : " + str_name + "\n제품번호 : " + i_number);
        }

        public override void Work(ref product _workwith)
        {
            Debug.Log(str_name + " with " + _workwith.str_name + " is Working now");
        }
    }

    public class Tablet : product
    {
        public Tablet(string name, int number)
        {
            this.str_name = name;
            this.i_number = number;
            Debug.Log(str_name + i_number + "생성 완료");
        }

        public override void Show()
        {
            Debug.Log("제품명 : " + str_name + "\n제품번호 : " + i_number);
        }

        public override void Work(ref product _workwith)
        {
            Debug.Log(str_name + " with " + _workwith.str_name + " is Working now");
        }
    }

    public abstract class FactoryModule
    {
        public abstract product MakeProduct(string name, int num);
    }

    public class NotebookModule : FactoryModule
    {
        public override product MakeProduct(string name, int num)
        {
            return new Notebook(name, num);
        }
    }

    public class TabletModule : FactoryModule
    {
        public override product MakeProduct(string name, int num)
        {
            return new Tablet(name, num);
        }
    }
}