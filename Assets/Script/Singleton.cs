using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Singleton
{
    private static Singleton m_Instance;

    public Singleton()
    {
    }

    public static Singleton Instance()
    {
        if(m_Instance == null)
        {
            m_Instance = new Singleton();
            Debug.Log("첫 생성");
        }

        else
        {
            Debug.Log("이미 만들어져 있는 Instance가 존재하여 기존값을 리턴합니다.");
        }

        // 다중 쓰레드일 경우
        if(m_Instance == null)
        {
            lock(m_Instance)
            {
                m_Instance = new Singleton();
                Debug.Log("다중쓰레드 이용 감지. 잠금 활성화");
            }
        }

        return m_Instance;
    }
}
