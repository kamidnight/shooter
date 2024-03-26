using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxValue = 100;
    public Slider Healthbar;
    public Animator animator;
    public AudioSource AidKitSound;
    //Не забудь указать ссылки на эти UI элементы в сцене
    public GameObject PlayerUI;
    public GameObject GameOverUI;

    float _currentValue;

    void awake()
    {
        AidKitSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        _currentValue = MaxValue;
        UpdateHealthbar();
    }

    public void TakeDamage(float damage)
    {
        _currentValue -= damage;
        if (_currentValue <= 0)
        {
            _currentValue = 0;
            GameOver();
        }
        UpdateHealthbar();
    }
    public void AddHealth(float amount)
    {
        _currentValue += amount;
        if (_currentValue > MaxValue)
        {
            _currentValue = MaxValue;
        }
        //HealEffect.GetComponent<ParticleSystem>().Play();
        UpdateHealthbar();
        AidKitSound.Play();
    }

    void UpdateHealthbar()
    {
        Healthbar.value = _currentValue / MaxValue;
    }

    void GameOver()
    {
        //включить или отключить объекты и компоненты
        PlayerUI.SetActive(false);
        GameOverUI.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        animator.SetTrigger("death");
    }
}
