using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{

    [SerializeField] private int player = 1;

    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    private bool m_Shoot;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump" + GetPlayerNumber());
        }
        if (!m_Shoot)
        {
            m_Shoot = CrossPlatformInputManager.GetButtonDown("Fire" + GetPlayerNumber());
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.

        //bool crouch = Input.GetKey(KeyCode.LeftControl);
        // no vamos a usar crouch
        bool crouch = false;

        float h = CrossPlatformInputManager.GetAxis("Horizontal" + GetPlayerNumber());
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Character.Shoot(m_Shoot);
        m_Jump = false;
        m_Shoot = false;
    }

    private string GetPlayerNumber()
    {
        return player == 1 ? "" : ("" + player);
    }

}
