using Unity.VisualScripting;
using UnityEngine;

namespace DSA
{
    #region MyPractice
    
    [ExecuteInEditMode]
    public class ArraysDemo : MonoBehaviour
    {
        protected int[] _myIntArray = {-8, 16, 4, 1, 12, 6, -56, 128, -92, 0, 86};
        protected int _index = 0;
        
        private void OnEnable()
        {
            LoopCollections(_index,_myIntArray);
        }
        
        private void LoopCollections(int index,int[] array)
        {
            // For Loop
            
                /*
                for (var i = index; i < array.Length; i++)
                {
                    Debug.Log(i);
                    currentIndex += i;
                }
                Debug.Log("This message came from For loop");
                */

            // Do while loop
            
                /*
                do
                {
                    var currentIndex = index;
                    ++index;
                    Debug.Log(currentIndex);
                    
                } while (index <= array.Length);
                Debug.Log("This message came from DoWhile loop");
                */
                
            // Foreach loop

                /*
                foreach (var intArray in array)
                {
                    Debug.Log(intArray);
                }
                Debug.Log("This message came from Foreach loop");
                */
                
        }
        
    }
    
    #endregion
}