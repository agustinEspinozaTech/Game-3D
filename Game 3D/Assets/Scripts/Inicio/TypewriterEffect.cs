using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    [TextArea(3, 10)]
    public string[] lines;
    public float typingSpeed = 0.04f;
    public GameObject menuPanel; // asignalo desde el Inspector

    private int index = 0;

    void Start()
    {
        textComponent.text = "";
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(2f); // pausa entre líneas
        index++;

        if (index < lines.Length)
        {
            textComponent.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = "";
            // Iniciar Fade In del menú
            StartCoroutine(FadeInMenu());
        }
    }

    IEnumerator FadeInMenu()
    {
        CanvasGroup canvasGroup = menuPanel.GetComponent<CanvasGroup>();
        menuPanel.SetActive(true);
        float duration = 1.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}