using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationReminder : MonoBehaviour
{
    public KeyPickup keyPickup; // referencia al script que detecta si se recogi� la llave
    public float delay = 30f;
    private bool messageShown = false;

    void Start()
    {
        StartCoroutine(ShowReminder());
    }

    IEnumerator ShowReminder()
    {
        yield return new WaitForSeconds(delay);

        if (!messageShown && keyPickup != null && !keyPickup.HasBeenCollected())
        {
            MessageUI.Instance.Show("Algo no est� bien... \nNo deber�a quedarme aqu� mucho tiempo. Debo encontrar esa llave r�pido.", 5f);
            messageShown = true;
        }
    }
}
