using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private float m_WinCondition;

   private List<FlowerController> m_Flowers;

   private int m_TotalFlowers;

   private void Start()
   {
      GameObject[] flowersGO = GameObject.FindGameObjectsWithTag("Plant");
      m_TotalFlowers = flowersGO.Length;
      m_Flowers = new List<FlowerController>();
      foreach (var flower in flowersGO)
      {
         m_Flowers.Add(flower.GetComponent<FlowerController>());
      }
   }

   private void Update()
   {
      for (int i = 0; i < m_Flowers.Count; i++)
      {
         if (m_Flowers[i].IsGrown)
         {
            m_Flowers.RemoveAt(i);
            break;
         }
      }

      CheckSunWinCondition();
   }

   private void OnEnable()
   {
      PraiseTheSun.SunAtPathEndEvent += CloudWin;
   }

   private void OnDisable()
   {
      PraiseTheSun.SunAtPathEndEvent -= CloudWin;
   }

   private void CheckSunWinCondition()
   {
      if (1.0 * m_Flowers.Count / m_TotalFlowers < m_WinCondition)
      {
         Debug.Log("hi");
      }
   }

   private void CloudWin()
   {
      Debug.Log("cloud wins");
   }
}
