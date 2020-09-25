using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Singleton
{
    private static Singleton m_Instance;

    public static Singleton Instance()
    {
        if(m_Instance == null)
        {
            m_Instance = new Singleton();
        }

        // 다중 쓰레드일 경우
        if(m_Instance == null)
        {
            lock(m_Instance)
            {
                m_Instance = new Singleton();
            }
        }

        return m_Instance;
    }
}
