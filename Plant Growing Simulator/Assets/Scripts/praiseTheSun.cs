using UnityEngine;

public class PraiseTheSun : MonoBehaviour
{
   public delegate void EmptyDelegate();
   public static event EmptyDelegate SunAtPathEndEvent;


   [SerializeField]
   private float m_Speed;

   [SerializeField]
   private float m_MaxHeight;

   [SerializeField]
   private float m_GrowthPower = 5;

   [SerializeField]
   private Camera m_Cam;

   private float m_OrigX;
   private float m_OrigY;

   private float m_Width;

   private bool m_IsBlocked;
   
   private bool m_Done;



   [SerializeField]
   private LineRenderer m_Ray;


   private Color m_DawnColor = new Color(14.0f / 255, 27.0f / 255, 48.0f / 255);
   private Color m_NoonColor = new Color(138.0f / 255, 174.0f / 255, 231.0f / 255);
   private Color m_DuskColor = new Color(14.0f / 255, 27.0f / 255, 48.0f / 255);



   private void Awake()
   {
      m_IsBlocked = false;

      m_OrigX = transform.position.x;
      m_OrigY = transform.position.y;
      m_Width = m_MaxHeight / (m_OrigX * m_OrigX);

      m_Cam.backgroundColor = m_DawnColor;
   }
   


   private void Update()
   {
      FloatAcrossSky();

      if (Input.GetAxis("Horizontal2") != 0)
      {
         m_Ray.transform.Rotate(0, 0, Input.GetAxis("Horizontal2"));
      }

      CheckForClouds();
      if (!m_IsBlocked)
         CheckForFlower();
   }

   private void FloatAcrossSky()
   {
      if (!m_Done)
         transform.position = UpdatePos(transform.position.x + m_Speed * Time.deltaTime);
      if (transform.position.x > -m_OrigX && !m_Done)
      {
         m_Done = true;
         if (SunAtPathEndEvent != null)
            SunAtPathEndEvent();
      }
   }

   private void ChangeSky(float x)
   {
      Color inBetween = Color.Lerp(m_DawnColor, m_NoonColor, (x - m_OrigX) / m_OrigX);

      m_Cam.backgroundColor = inBetween;
   }

   private Vector2 UpdatePos(float x)
   {
      float newY = - m_Width * x * x + m_MaxHeight + m_OrigY;
      ChangeSky(x);
      return new Vector2(x, newY);
   }

   private void CheckForClouds()
   {
      // Shoot two ray casts
      Vector2 originR = transform.position + m_Ray.transform.up * m_Ray.startWidth / 2;
      Vector2 originL = transform.position - m_Ray.transform.up * m_Ray.startWidth / 2;
      Vector2 dir = m_Ray.transform.right;

      RaycastHit hit;
      if (Physics.Raycast(originR, dir, out hit, m_Ray.GetPosition(1).x))
      {
         if (hit.collider.CompareTag("Cloud"))
         {
            m_Ray.SetPosition(1, new Vector3((transform.position - hit.collider.transform.position).magnitude, 0, 0));
            m_IsBlocked = true;
         }
      }
      else if (Physics.Raycast(originL, dir, out hit, m_Ray.GetPosition(1).x))
      {
         if (hit.collider.CompareTag("Cloud"))
         {
            m_Ray.SetPosition(1, new Vector3((transform.position - hit.collider.transform.position).magnitude, 0, 0));
            m_IsBlocked = true;
         }
      }
      else
      {
         m_Ray.SetPosition(1, new Vector3Int(50, 0, 0));
         m_IsBlocked = false;
      }
   }

   private void CheckForFlower()
   {
      Vector2 originR = transform.position + m_Ray.transform.up * m_Ray.startWidth / 2;
      Vector2 originL = transform.position - m_Ray.transform.up * m_Ray.startWidth / 2;
      Vector2 dir = m_Ray.transform.right;

      RaycastHit2D hitR = Physics2D.Raycast(originR, dir, m_Ray.GetPosition(1).x);
      RaycastHit2D hitL = Physics2D.Raycast(originL, dir, m_Ray.GetPosition(1).x);
      RaycastHit2D hitC = Physics2D.Raycast(transform.position, dir, m_Ray.GetPosition(1).x);

      if (hitR.collider != null)
      {
         if (hitR.collider.CompareTag("Plant"))
         {
            hitR.collider.GetComponent<FlowerController>().Grow(m_GrowthPower * 0.01f);
         }
      }
      else if (hitL.collider != null)
      {
         if (hitL.collider.CompareTag("Plant"))
         {
            hitL.collider.GetComponent<FlowerController>().Grow(m_GrowthPower * 0.01f);
         }
      }
      else if(hitC.collider != null)
      {
         if (hitC.collider.CompareTag("Plant"))
         {
            hitC.collider.GetComponent<FlowerController>().Grow(m_GrowthPower * 0.01f);
         }
      }
   }
}
