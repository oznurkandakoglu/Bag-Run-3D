using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDatas
{
    public static int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("34ssdr", 1);
        }
        set
        {
            PlayerPrefs.SetInt("34ssdr", value);
        }
    }

    public static int countLevel
    {
        get
        {
            return PlayerPrefs.GetInt("asd", 1);
        }
        set
        {
            PlayerPrefs.SetInt("asd", value);
        }
    }

    public static int point
    {
        get
        {
            return PlayerPrefs.GetInt("klm", 0);
        }
        set
        {
            PlayerPrefs.SetInt("klm", value);
        }
    }

    //public static bool bilge
    //{
    //    get
    //    {
    //        int asd = PlayerPrefs.GetInt("bilge", 0);
    //        if (asd == 1)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    set
    //    {
    //        if (value == true)
    //        {
    //            PlayerPrefs.SetInt("bilge", 1);
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetInt("bilge", 0);
    //        }

    //    }
    //}
}
