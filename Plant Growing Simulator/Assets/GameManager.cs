using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public delegate void EmptyDelegate();
   public static event EmptyDelegate GameOverEvent;



   [SerializeField]
   private Text m_WinnerText;

   [SerializeField]
   private Text m_OptionsText;

   [SerializeField]
   private float m_WinCondition;

   private List<FlowerController> m_Flowers;

   private int m_TotalFlowers;


   private bool m_GameOver;


   private void Awake()
   {
      m_GameOver = false;
   }

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
      if (!m_GameOver)
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
      else
      {
         if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
         else if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
      }
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
         EndGame("SUN");
      }
   }

   private void CloudWin()
   {
      EndGame("CLOUD");
   }

   private void EndGame(string winner)
   {
      m_OptionsText.gameObject.SetActive(true);
      m_WinnerText.gameObject.SetActive(true);
      m_WinnerText.text = winner + " WON THE GAME!";

      m_GameOver = true;

      if (GameOverEvent != null)
         GameOverEvent();
   }
}
