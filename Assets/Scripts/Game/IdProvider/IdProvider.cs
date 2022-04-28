using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

namespace Game
{
    public class IdProvider
    {
        private List<IElementId> _elements = new List<IElementId>();
        private int _id;

        public void AddElement(IElementId element)
        {
            _elements.Add(element);
        }

        public IElementId GetElement(int id)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].ID == id)
                {
                    return _elements[i];
                }
            }

            return null;
        }
        
        public int GetId()
        {
            return ++_id;
        }
    }
}
