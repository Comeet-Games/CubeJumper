using TMPro;
using UnityEngine;

public class ShopOpeningClosing : MonoBehaviour
{
    public GameObject homeUI;
    public GameObject shopUI;
    public GameManager gameManager;
    public TextMeshProUGUI coinsCounterText;

    public void OpenShop()
    {
        //homeUI.SetActive(true);
        //shopUI.SetActive(true);

        coinsCounterText.text = gameManager.coins.ToString();
    }

    public void CloseShop()
    {
        //homeUI.SetActive(true);
        //shopUI.SetActive(true);
        Invoke("DeactiveShopUI", 0.5f);
    }

    void DeactiveShopUI()
    {
        shopUI.SetActive(false);
    }
}
