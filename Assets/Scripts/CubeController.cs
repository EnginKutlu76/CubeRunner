using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CubeController : MonoBehaviour
{
    public float baslangicHizi = 5f;
    public float ivme = 2f;
    public float maksimumHiz = 20f;
    public float yatayInputHassasiyeti = 0f;

    Rigidbody rb;
    public GameObject panel;
    private Animator animator;
    private bool SondaMi = false;
    private bool IsWaiting = false;

    private float hiz;
    
    public LayerMask groundLayer;
    public GameObject groundCheck;
    private bool isGrounded;
    public float groundCheckRadius;
    public float JumpPower;
    private bool ortadaMi;

    public AudioSource Do, Re, Mi, Fa, Sol, La, Si;
    public AudioSource jump,dead;
    void Start()
    {
        Time.timeScale = 1;
        hiz = baslangicHizi;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
        CheckSurface();
      
        float yatayInput = Input.GetAxis("Horizontal");


        Vector3 hareket = new Vector3(hiz, 0f, 0F);
        transform.Translate(hareket * Time.deltaTime);


        hiz += ivme * Time.deltaTime;

       
        hiz = Mathf.Min(hiz, maksimumHiz);

        if (!IsWaiting)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!SondaMi)
                {
                    SondaMi = true;
                    StartCoroutine(Gecis("A"));
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (!SondaMi)
                {
                    SondaMi = true;
                    StartCoroutine(Gecis("D"));
                }
            }
        }
        Vector3 mevcutPozisyon = transform.position;
        if (mevcutPozisyon.z > 5f)
        {
            mevcutPozisyon.z = 5f;
        }
        else if (mevcutPozisyon.z < -5f)
        {
            mevcutPozisyon.z = -5f;
        }
        else if (mevcutPozisyon.z <-5f && mevcutPozisyon.z > 5f)
        {
            mevcutPozisyon.z = 0;
        }

        transform.position = mevcutPozisyon;
    }
   
    IEnumerator Gecis(string yon)
    {
        Vector3 hedefPozisyon;
        if (yon == "A")
        {
            hedefPozisyon = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);
        }
        else if (yon == "D")
        {
            hedefPozisyon = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
        }
        else
        {
            yield break;
        }
        float gecisSure = 0.2f;
        Vector3 baslangicPozisyon = transform.position;

        float zaman = 0f;

        while (zaman < gecisSure)
        {
            // Lerp fonksiyonu ile yumuþak bir geçiþ yap
            transform.position = Vector3.Lerp(baslangicPozisyon, hedefPozisyon, zaman / gecisSure);

            zaman += Time.deltaTime;

            yield return null; // Bir sonraki frame'e geç
        }
        StartCoroutine(BeklemeSuresi());

        // Geçiþ tamamlandýktan sonra SondaMi deðerini sýfýrla
        SondaMi = false;
    }

    IEnumerator BeklemeSuresi()
    {
        float beklemeSure = 0.2f;

        IsWaiting = true;
        yield return new WaitForSeconds(beklemeSure);
        IsWaiting = false;
    }
    void Jump()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(rb.velocity.x, JumpPower, rb.velocity.y);
                jump.Play();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }
    void CheckSurface()
    {
        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundCheckRadius, groundLayer);
        }
        else
        {
            Debug.LogError("groundCheck null. Doðru bir þekilde baþlatýlmamýþ olabilir.");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            dead.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Do"))
        {
            Do.Play();
        }
        if (other.CompareTag("Re"))
        {
            Re.Play();
        }
        if (other.CompareTag("Mi"))
        {
            Mi.Play();
        }
        if (other.CompareTag("Fa"))
        {
            Fa.Play();
        }
        if (other.CompareTag("Sol"))
        {
            Sol.Play();
        }
        if (other.CompareTag("La"))
        {
            La.Play();
        }
        if (other.CompareTag("Si"))
        {
            Si.Play();
        }

    }
}
