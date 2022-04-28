using UnityEngine;

namespace Game.Player
{
    public class Callback
    {
        public string Key;
        public GameObject Object;

        public Callback(string key, GameObject obj)
        {
            Key = key;
            Object = obj;
        }
    }
}
