using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText; // Referencia al texto del contador
    public TextMeshProUGUI winText; // Referencia al texto "YOU WIN"

    private int coinsCollected = 0;
    private int totalCoins = 12; // Número total de monedas

    void Start()
    {
        UpdateCounter(); // Actualiza el contador al inicio
        winText.gameObject.SetActive(false); // Asegura que el texto de victoria esté oculto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moneda"))
        {
            Destroy(other.gameObject); // Destruye la moneda
            coinsCollected++; // Aumenta el contador
            UpdateCounter(); // Actualiza el texto del contador

            if (coinsCollected >= totalCoins)
            {
                winText.gameObject.SetActive(true); // Muestra "YOU WIN"
            }
        }
    }

    void UpdateCounter()
    {
        coinCounterText.text = "Monedas: " + coinsCollected + "/" + totalCoins;
    }
}
