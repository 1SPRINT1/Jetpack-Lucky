using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Rigidbody")]
    [HideInInspector][SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float _health;
    [Header("Jump-Force")] 
    [SerializeField] private float jumpForce = 1;
    public bool isFly = false;
    [Space(5)] 
    [Header("Jobs-for-UI")] 
    [SerializeField] private GameObject GameOverPanel;
    [Space(5)] 
    [Header("Fuel")] 
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fuel;
    private float _maxFuel = 100f;
    private float _wasteFuel = 6f;
    public GameObject GoodFuel;
    public GameObject BadFuel;
    [Space(5)]
    [Header("Acsesses-Scripts")]
    [SerializeField] private GameManager _gameManager;
    [Space(5)] 
    [Header("Effects")] 
    [SerializeField] private GameObject _effectItems;
    [SerializeField] private GameObject _effectRock;
    [Space(10)] 
    [Header("Upgrades")] 
    [SerializeField] private float jetPackForce;
    [SerializeField] private float Stamina;
    private void Start()
    {
        jetPackForce = PlayerPrefs.GetFloat("JetPack");
        Stamina = PlayerPrefs.GetFloat("Stamina");
        rb2d = GetComponent<Rigidbody2D>();
        _fuel = _maxFuel;
        _slider.value = _fuel;
        jumpForce += jetPackForce;
        _wasteFuel -= Stamina;
    }

    private void Update()
    {
        _slider.value = _fuel;
        _fuel -= _wasteFuel * Time.deltaTime; 
        if (isFly == true)
        {
            Jump();
        }
        if (_health <= 0 && _fuel <= 0)
        {
            GameOverPanel.SetActive(true);
            StartCoroutine(Start_Stop_Time()); 
        }

        if (transform.position.y <= -5.8f)
        {
            GameOverPanel.SetActive(true);    
            StartCoroutine(Start_Stop_Time()); 
        }

        if (_fuel > 15f)
        {
            GoodFuel.SetActive(true);
            BadFuel.SetActive(false);
        }
        else
        {
            GoodFuel.SetActive(false);
            BadFuel.SetActive(true);
        }

        if (_fuel >= 100)
        {
            _fuel = _maxFuel;
        }
    }

    private void Jump()
    {
        if (_fuel > 0)
        {
            rb2d.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
        }
    }

    public void StartJump()
    {
        isFly = true;
    }

    public void StopJump()
    {
        isFly = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
           GameOverPanel.SetActive(true);
           StartCoroutine(Start_Stop_Time());
           Destroy(other.gameObject);
           _fuel = 0f;
           Instantiate(_effectRock, transform.position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Crystal"))
        {
            _gameManager.coins++;
            if (_gameManager.isX2Score == true)
            {
                _gameManager.coins++;
                _gameManager._allCoins++;
            }
            Instantiate(_effectItems, transform.position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Fuel"))
        {
            _fuel += 20f;
            Instantiate(_effectItems,transform.position,Quaternion.identity);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    IEnumerator Start_Stop_Time()
    {
       yield return new WaitForSeconds(3f);
       Time.timeScale = 0f;
       Destroy(gameObject);
       _gameManager._allDeaths++;
       StopCoroutine(Start_Stop_Time());
    }
}
