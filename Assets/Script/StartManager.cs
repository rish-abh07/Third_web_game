using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb;

public class StartManager : MonoBehaviour
{
    public GameObject connected;
    public GameObject disconnected;
    public GameObject EnterButton;
    public TextMeshProUGUI addressTxt;
    public TextMeshProUGUI ownNFTtxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async void ConnectWalet()
    {
        string address = await SDKManager.instance.SDK.wallet.Connect(new WalletConnection()
        {
            provider = WalletProvider.MetaMask,
            chainId = 5 // Switch the wallet Goerli on connection
        });
        addressTxt.text = address;      
        connected.SetActive(true);  
        disconnected.SetActive(false);   
    }
    public async Task CheckBalance()
    {
        Contract contract = SDKManager.instance.SDK.GetContract("0x4bc87A6883A6d4cb8b2dc3d33c0073b11bcaddF6");
        string balance = await contract.ERC721.Balance();
        float balanceFloat = float.Parse(balance);  
        if(balanceFloat == 0)
        {
            ownNFTtxt.text = "Sorry you can't access the game  ";
            return;
        }
        ownNFTtxt.text = "Welcome to the Game";
        EnterButton.SetActive(true);
    }
    public void EnterGame()
    {
        SceneManager.LoadScene("Game");
    }
}
