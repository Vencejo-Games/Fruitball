using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Shoot;

        [SerializeField] private int player = 1;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump" + getPlayerNumber());
            }
            if (!m_Shoot)
            {
                m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire" + getPlayerNumber());
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal" + getPlayerNumber());
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Character.Shoot(m_Shoot);
            m_Jump = false;
            m_Shoot = false;
        }

        private string getPlayerNumber()
        {
            return (player == 1 ? "" : player.ToString());
        }
    }
