using UnityEngine;

public class AIAniController : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
}
