using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.SceneUtils
{
    public class SlowMoButton : MonoBehaviour
    {
        public float fullSpeed = 1;
        public float slowSpeed = 0.3f;

        public bool m_SlowMo;

       	void Start()
        {
			m_SlowMo = false;
        }

        void Update()
        {
            float slowMoButton = Input.GetAxisRaw("SlowMo");
            if(slowMoButton > 0.1f || slowMoButton < -0.1f)
            {
                m_SlowMo = true;
                Time.timeScale = slowSpeed;
            }
            if (slowMoButton == 0)
            {
                m_SlowMo = false;
                Time.timeScale = fullSpeed;
            }
        }
    }
}
