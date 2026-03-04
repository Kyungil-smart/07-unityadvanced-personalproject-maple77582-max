using UnityEngine;
using UnityEngine.InputSystem;
public class AniController : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            anim.SetTrigger("HookPunch");
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            anim.SetTrigger("MiddleKick");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            anim.SetTrigger("LowKick");
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            anim.SetTrigger("HighDef");
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            anim.SetTrigger("MiddleDef");
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            anim.SetTrigger("LowDef");
        }
    }
    /*private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("HipHop");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("Spin");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("Ymca");
        }
    }*/
}
