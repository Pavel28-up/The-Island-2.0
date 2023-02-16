using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPlayerParam : MonoBehaviour
{
    public enum Class
    {
        Captain = 0,
        Quartermaster = 1,
        Navigator = 2,
        Bosun =3,
        Soldier = 4,
        Carpenter = 5,
        Caulkman = 6,
        Cook = 7,
        Pirate = 8,
        Sailor = 9,
        Settler = 10,
        PowderMonkey = 11,
        Merchant  = 12
    }
    public Class classEnter = Class.Captain;

    /// <summary>
    /// Имя персонажа-пользователя.
    /// </summary>
    public string Name;
    public int Level;
    /// <summary>
    /// Здоровье.
    /// </summary>
    public int Helth;
    public int Power;
    public int Endurance;
    public int Mana;
    public int Intelect;
    public int Body;

    void Update()
    {
        ClassEndFeature();
    }

    public void ClassEndFeature()
    {
        Helth = 100;
        if (classEnter == Class.Captain)
        {
            Power = 2;
            Endurance = 4;
            Mana = 0;
            Intelect = 5;
            Body = 5;
        }
        else if (classEnter == Class.Quartermaster)
        {
            Power = 4;
            Endurance = 3;
            Mana = 0;
            Intelect = 4;
            Body = 7;
        }
        else if (classEnter == Class.Navigator)
        {
            Power = 2;
            Endurance = 1;
            Mana = 0;
            Intelect = 8;
            Body = 4;
        }
        else if (classEnter == Class.Bosun)
        {
            Power = 3;
            Endurance = 5;
            Mana = 0;
            Intelect = 4;
            Body = 3;
        }
        else if (classEnter == Class.Soldier)
        {
            Power = 4;
            Endurance = 5;
            Mana = 0;
            Intelect = 2;
            Body = 7;
        }
        else if (classEnter == Class.Carpenter)
        {
            Power = 5;
            Endurance = 0;
            Mana = 0;
            Intelect = 7;
            Body = 4;
        }
        else if (classEnter == Class.Cook)
        {
            Power = 2;
            Endurance = 5;
            Mana = 0;
            Intelect = 4;
            Body = 7;
        }
        else if (classEnter == Class.Pirate)
        {
            Power = 5;
            Endurance = 5;
            Mana = 0;
            Intelect = 1;
            Body = 6;
        }
        else if (classEnter == Class.Sailor)
        {
            Power = 5;
            Endurance = 4;
            Mana = 0;
            Intelect = 4;
            Body = 1;
        }
        else if (classEnter == Class.Settler)
        {
            Power = 3;
            Endurance = 2;
            Mana = 0;
            Intelect = 4;
            Body = 2;
        }
        else if (classEnter == Class.PowderMonkey)
        {
            Power = 1;
            Endurance = 8;
            Mana = 0;
            Intelect = 6;
            Body = 1;
        }
        else
        {
            Power = 1;
            Endurance = 1;
            Mana = 0;
            Intelect = 8;
            Body = 7;
        }
    }
}
