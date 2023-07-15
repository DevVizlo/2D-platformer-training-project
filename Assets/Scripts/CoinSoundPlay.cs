using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]  

public class CoinSoundPlay : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CoinDestroy>(out CoinDestroy player))
        {
            _audioSource.Play();
        }
    }

}
