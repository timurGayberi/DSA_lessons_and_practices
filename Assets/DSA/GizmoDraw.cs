using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

#region GizmosVizualization
namespace DSA
{
    
    public class GizmoDraw : ArraysDemo
    {

        private const float     CellSize = 1.0f,
                                CellSpacing = CellSize + 0.25f;

        #region  Draw Cells
        
        private void OnDrawGizmos()
        {
            if (_myIntArray == null || _myIntArray.Length == 0) return;
            
            var totalStep = CellSize * CellSpacing;
            
            for (var i = _index; i < _myIntArray.Length; i++)
            {
                var offset = new Vector2(i * totalStep, 0);
                
                VisualizeArray(offset, i);
            }
        }
        private void VisualizeArray(Vector3 offset, int arrayIndex)
        {
            var position = transform.position + offset;

            //Draw1DArray(position, arrayIndex);
            //Draw2DArray()
            //Draw3DArray()
            
            //DrawTuple();
        }
        #endregion

        #region 1D Array Draw

            private void Draw1DArray(Vector3 position, int arrayIndex)
            {
                var filledSize = new Vector3(1, 1, 0); 
                
                // Normalize value
                var normalizedValue = _myIntArray[arrayIndex] / (float)_myIntArray.Length;

                // Text Label
                var style = new GUIStyle(EditorStyles.boldLabel)
                {
                    alignment = TextAnchor.MiddleCenter
                };

                // Index
                var labelText = $"{_myIntArray[arrayIndex]}"; 
                
                //Text
                style.normal.textColor = Color.white;
                Handles.Label(position + Vector3.back * 0.5f, labelText, style);

                // Fill
                Gizmos.color = Color.Lerp(Color.blue, Color.red, normalizedValue);
                Gizmos.DrawCube(position, filledSize);

                // Outline
                Gizmos.color = Color.black;
                Gizmos.DrawWireCube(position, filledSize);
            }
            #endregion

        #region TuplePractice
        
        public void DrawTuple()
        {
            //Draw a tuple example;
        }
        
        #endregion
    }
}
#endregion