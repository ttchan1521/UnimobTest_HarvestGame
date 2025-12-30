using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEntity : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public Transform[] carryPoints;
    
    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void PlayAnimMove()
    {
        _animator.SetBool("IsMove", true);
        _animator.SetBool("IsEmpty", true);
    }

    public void PlayAnimCarryMove()
    {
        _animator.SetBool("IsEmpty", false);
        _animator.SetBool("IsCarryMove", true);
    }

    public void PlayAnimCarryIdle()
    {
        _animator.SetBool("IsCarryMove", false);
        _animator.SetBool("IsEmpty", false);
    }

    public void PlayAnimIdle()
    {
        _animator.SetBool("IsEmpty", true);
        _animator.SetBool("IsMove", false);
    }
}
