using System;
using Services.SaveService.Interface;
using UnityEngine;

namespace Services.SaveService.Implementations
{
    public class PlayerPrefsSaveService: ISaveService
    {
        public bool TrySave(string _key, string _data)
        {
            try
            {
                PlayerPrefs.SetString(_key, _data);
                PlayerPrefs.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetData(string _key)
        {
            try
            {
                return PlayerPrefs.GetString(_key);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}