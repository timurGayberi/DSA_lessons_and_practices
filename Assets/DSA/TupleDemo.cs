using System;
using UnityEngine;

namespace DSA
{
    
    #region TuplePractice

    [ExecuteInEditMode]
    public class TupleDemo : MonoBehaviour
    {
        private void OnEnable()
        {
            TuplesInArrayDemo();
        }
        public void TuplesInArrayDemo()
        {
            (string name, bool isGood, float age)[] character = new (string, bool, float)[]
            {
                ("Gandalf", true, 2000f),
                ("Frodo",true,500f),
                ("Sauron",false,3000f)
                
                // Will come more ...
                
            };
            if (character == null) throw new ArgumentNullException(nameof(character));

            for (var i = 0; i < character.Length; i++)
            {
                if (character[i].isGood)
                {
                    Debug.Log($"Character name is {character[i].name} and their age is {character[i].age} and they are good");
                }
                else
                {
                    Debug.Log($"Character name is {character[i].name} and their age is {character[i].age} and they are bad");
                }
            }

            var drawer = GetComponent<GizmoDraw>();
            
            if (drawer != null)
            {
                // draw tuple in GizmoDraw.cs
            }
        }
    }

    #endregion
};