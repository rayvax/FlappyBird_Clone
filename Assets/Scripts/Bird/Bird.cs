using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMovement), typeof(Animator))]
public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private BirdMovement _movement;
    private Animator _animator;
    private int _score;

    private void Awake()
    {
        _movement = GetComponent<BirdMovement>();
        _animator = GetComponent<Animator>();
    }

    public void ResetBird()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _movement.ResetMovement();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }    

    public void Die()
    {
        _animator.SetTrigger("Dead");
        GameOver?.Invoke();
    }
}
