using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class User
    {
        public int attack;
        public int health;
        public int defence;
        public byte location;
        public bool key;
        public bool sword;
        public bool armor;
        public User()
        {
            attack = 10;
            health = 30;
            defence = 5;
            location = 1;
            key = false;
            sword = false;
            armor = false;
        }
        public void Movement(byte loc)
        {
            location = loc;
        }
        public void EquipSword()
        {
            attack += 8;
            sword = true;
        }
        public void EquipArmor()
        {
            defence += 5;
            armor = true;
        }
        public void GetKey()
        {
            key = true;
        }
        public bool BattleWin(int u_att, int u_hel, int u_def, int m_att, int m_hel, int m_def, bool m_alive)
        {
            if (m_alive == false) return false;
            else
            {
                while ((u_hel > 0) && (m_hel > 0))
                {
                    m_hel -= (u_att - m_def);
                    Console.WriteLine("Вы нанесли врагу " + (u_att - m_def) + " урона! У него осталось " + m_hel + " Здоровья.");
                    if (m_hel < 0) goto Link;
                    u_hel -= (m_att - u_def);
                    Console.WriteLine("Враг нанес вам " + (m_att - u_def) + " урона! У вас осталось " + u_hel + " Здоровья.");
                }
                Link:
                if (u_hel > 0)
                {
                    m_alive = false;
                    return true;
                }
                else return false;
            }
        }
    }
}
