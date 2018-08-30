using UnityEngine;

public class SunScript : MonoBehaviour
{
   [SerializeField]
   private float m_Speed;

   [SerializeField]
   private float m_MaxHeight;

   private float m_OrigX;
   private float m_OrigY;

   private float m_Width;

   private bool m_Done;



   [SerializeField]
   private LineRenderer m_Ray;



   private void Awake()
   {
      m_OrigX = transform.position.x;
      m_OrigY = transform.position.y;
      m_Width = m_MaxHeight / (m_OrigX * m_OrigX);
   }
   


   private void Update()
   {
      if (!m_Done)
         transform.position = UpdatePos(transform.position.x + m_Speed * Time.deltaTime);
      if (transform.position.x > -m_OrigX)
         m_Done = true;
   }

   private Vector2 UpdatePos(float x)
   {
      float newY = - m_Width * x * x + m_MaxHeight + m_OrigY;

      return new Vector2(x, newY);
   }
}
