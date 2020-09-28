using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OBSERVER
{
    abstract class State
    {
        private string m_name;
        private int m_Hp;
        private List<Viewer> StateViewers = new List<Viewer>();

        public State(string name, int hp)
        {
            this.m_name = name;
            this.m_Hp = hp;
        }

        public void Attach(Viewer investor)
        {
            Debug.Log("새로운 Viewer 추가");
            StateViewers.Add(investor);
        }

        public void Detach(Viewer investor)
        {
            Debug.Log("기존 Viewer 삭제");
            StateViewers.Remove(investor);
        }

        // 다른 viewer들에게 상태 변화 알리기
        public void Notify()
        {
            foreach (Viewer viewer in StateViewers)
            {
                Debug.Log("상태 변화 알림");
                viewer.Update(this);
            }
        }

        public int Health { get { return m_Hp; } set { m_Hp = value; Notify(); } }
        public string Name { get { return m_name; } }
    }

    class Player : State
    {
        public Player(string name, int hp) : base(name, hp)
        {
        }
    }
    
    interface Viewer
    {
        void Update(State state);
    }

    class MainScreen : Viewer
    {
        private State m_state;

        public void Update(State state)
        {
            this.m_state = state;
            Debug.Log("메인화면 " + this.m_state.Name + "상태 변경 : 체력 " + this.m_state.Health);
        }

        public State State { get { return m_state; } set { m_state = value; } }
    }

    class StatusScreen : Viewer
    {
        private State m_state;

        public void Update(State state)
        {
            this.m_state = state;
            Debug.Log("상태창 " + this.m_state.Name + "상태 변경 : 체력 " + this.m_state.Health);
        }

        public State State { get { return m_state; } set { m_state = value; } }
    }

    class EnemyScreen : Viewer
    {
        private State m_state;

        public void Update(State state)
        {
            this.m_state = state;
            Debug.Log("상대창 " + this.m_state.Name + "상태 변경 : 체력 " + this.m_state.Health);
        }

        public State State { get { return m_state; } set { m_state = value; } }
    }
}
