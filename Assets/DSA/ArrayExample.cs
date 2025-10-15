using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using UnityEngine;

namespace DSA
{
    [ExecuteInEditMode]
    public class ArrayExample : MonoBehaviour
    {
        class Person
        {
            public string   m_name;
            public int      m_iAge;
            public Color    m_hairColor;
            public bool     m_bIsSingle;
        }

        public bool[]       m_array1;
        public int[,]       m_array2;
        public float[,,]    m_array3;
        //public byte[,][]    m_array4;

        private void OnEnable()
        {
            Array_1D();
            Array_2D();
            Array_3D();
            //Final_Array();
        }

        void TheBasics()
        {
            // Data
            float fAbility = 1.0f;
            float fImprovement = -0.01f;

            // Algorithm
            fAbility = Mathf.Pow(fAbility + fImprovement, 365.0f);
            //Debug.Log("Ability after 1 year: " + fAbility.ToString("0.00"));

            // Tuples
            Person gandalf = new Person
            {
                m_name = "Gandalf",
                m_iAge = 3000,
                m_hairColor = Color.white
            };

            (Person person, int salary, bool isSingle) gandalfSalary = (gandalf, 2500, true);
            Debug.Log("Person: " + gandalfSalary.person.m_name + " has a salary of " + gandalfSalary.salary);
        }

        void Array_1D()
        {
            // 1D Array
            int iCount = 20; // Random.Range(10, 15);
            m_array1 = new bool[iCount];
            for (int i = 0; i < iCount; i++)
            {
                //m_array1[i] = Random.value < 0.5f;
                m_array1[i] = i % 2 == 0;
            }

            // Convert All
            Vector3[] vertices = new Vector3[1024];
            Color[] colors = System.Array.ConvertAll(vertices, v => Color.Lerp(Color.green, Color.blue, v.y));
            Person[] heroes = System.Array.ConvertAll(m_array1, b => new Person { m_bIsSingle = b });

            // Find & FindIndex, FindAll
            int iWhereIsGandalf = System.Array.FindIndex(heroes, h => h.m_name == "Gandalf");
            Person oldPerson = System.Array.Find(heroes, h => h.m_iAge > 600);
            Person[] redHeads = System.Array.FindAll(heroes, h => h.m_hairColor.r > 0.9f);

            //StartCoroutine(ArrayResizing());
            //StartCoroutine(ArrayShiftLeft());
            //StartCoroutine(ArrayRemoveElement());
        }

        void Array_2D()
        {
            m_array2 = new int[7, 4];
            for (int y = 0; y < m_array2.GetLength(1); ++y)
            {
                for (int x = 0; x < m_array2.GetLength(0); ++x)
                {
                    m_array2[x, y] = Random.Range(0, 100);
                }
            }
        }

        void Array_3D()
        {
            m_array3 = new float[3, 4, 5];
            for (int x = 0; x < m_array3.GetLength(0); ++x)
            {
                for (int y = 0; y < m_array3.GetLength(1); ++y)
                {
                    for (int z = 0; z < m_array3.GetLength(2); ++z)
                    {
                        m_array3[x, y, z] = Random.value;
                    }
                }
            }
        }

        /*void Final_Array()
        {
            m_array4 = new byte[4, 4][];
            for (int x = 0; x < m_array4.GetLength(0); ++x)
            {
                for (int y = 0; y < m_array4.GetLength(1); ++y)
                {
                    byte[] innerArray = new byte[Random.Range(1, 5)];
                    for (int i = 0; i < innerArray.Length; i++)
                    {
                        innerArray[i] = (byte)Random.Range(0, 255);
                    }

                    m_array4[x, y] = innerArray;
                }
            }
        }*/

        IEnumerator ArrayResizing()
        {
            while (m_array1.Length < 100)
            {
                bool bCoin = Random.value < 0.5f;

                /* The Manual Way
                 * --------------------------------------------
                // create a new array (+1)
                bool[] newArray = new bool[m_array1.Length + 1];
                for (int i = 0; i < m_array1.Length; ++i)
                {
                    // copy old values
                    newArray[i] = m_array1[i];
                }

                // append the new coin flip
                newArray[newArray.Length - 1] = bCoin;

                // replace our array
                m_array1 = newArray;*/



                /* The Copy Way
                //-----------------------------------------------
                // create a new array (+1)
                bool[] newArray = new bool[m_array1.Length + 1];
                System.Array.Copy(m_array1, newArray, m_array1.Length);

                // append the new coin flip
                newArray[newArray.Length - 1] = bCoin;

                // replace our array
                m_array1 = newArray;*/



                // The Resize Way
                //-----------------------------------------------
                // resize the array + 1
                System.Array.Resize(ref m_array1, m_array1.Length + 1);

                // append the new coin flip
                m_array1[m_array1.Length - 1] = bCoin;


                yield return new WaitForSeconds(1.0f);
            }
        }

        IEnumerator ArrayShiftLeft()
        {
            while (true)
            {
                // Left shift
                bool bTmp1 = m_array1[0];
                for (int i = 1; i < m_array1.Length; i++)
                {
                    m_array1[i - 1] = m_array1[i];
                }
                m_array1[m_array1.Length - 1] = bTmp1;

                yield return new WaitForSeconds(1.0f);
            }
        }

        IEnumerator ArrayRemoveElement()
        {
            while (m_array1.Length > 0)
            {
                int iMiddle = m_array1.Length / 2;
                for (int i = iMiddle + 1; i < m_array1.Length; i++)
                {
                    m_array1[i - 1] = m_array1[i];
                }

                System.Array.Resize(ref m_array1, m_array1.Length - 1);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}