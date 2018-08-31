using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
   [SerializeField]
   private Sprite[] m_Stages;

   [SerializeField]
   private ParticleSystem m_DoneGrowingPS;
  
   private int m_MaxGrowth;

   private float m_CurrentGrowth;
   private int m_CurrentStage;

   private bool m_IsGrowing;


   private SpriteRenderer m_SpriteRenderer;


   private void Awake()
   {
      m_SpriteRenderer = GetComponent<SpriteRenderer>();

      m_MaxGrowth = m_Stages.Length;
      m_CurrentGrowth = m_CurrentStage = 0;
      m_IsGrowing = false;
   }

   public void Grow(float amt)
   {
      if (m_CurrentStage == m_Stages.Length - 1)
         return;

      m_CurrentGrowth += amt;
      if (m_CurrentGrowth > m_CurrentStage + 1)
      {
         m_SpriteRenderer.sprite = m_Stages[++m_CurrentStage];
         if (m_CurrentStage == m_Stages.Length - 1)
            m_DoneGrowingPS.Play();
      }
   }

   public bool IsGrown
   {
      get { return m_CurrentStage == m_Stages.Length - 1; }
   }
}
