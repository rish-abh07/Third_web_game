using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Thirdweb;

public class ClaimManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public async Task ClaimNFT()
    {
        Contract contract = SDKManager.instance.SDK.GetContract("0x4bc87A6883A6d4cb8b2dc3d33c0073b11bcaddF6");
        await contract.ERC721.Claim(4);
    }
    public async void Claim()
    {
        await ClaimNFT();
    }
}
