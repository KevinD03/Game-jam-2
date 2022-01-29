using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public string m_name;
    public int m_attack;
    public int m_maxHP;

    int m_curHP;
    Slider m_hpSlider;

    public void Init() {
        m_curHP = m_maxHP;
        m_hpSlider = GetComponentInChildren<Slider>();
        if (m_hpSlider != null) {
            m_hpSlider.maxValue = m_maxHP;
            m_hpSlider.value = m_curHP;
        }
    }

    public bool Attack(Unit target) {
        Debug.Log(m_name + " attacks " + target.m_name);
        bool kill = target.TakeDamage(m_attack);
        return kill;
    }

    public bool TakeDamage(int damage) {
        m_curHP -= damage;
        
        if (m_curHP < 0)
            m_curHP = 0;

        if (m_hpSlider != null) {
            m_hpSlider.value = m_curHP;
        }

        return m_curHP == 0;
    }
}
