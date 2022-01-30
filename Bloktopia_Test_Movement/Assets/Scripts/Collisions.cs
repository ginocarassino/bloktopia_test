using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] GameObject interactedNPC;
    [SerializeField] GameObject interactedNFT;

    private PlayerController pc;

    private void Start()
    {
        pc = (PlayerController)FindObjectOfType(typeof(PlayerController));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "npc")
        {
            interactedNPC.SetActive(true);
            pc.selectInteraction(other.gameObject);
        }

        if (other.tag == "nft")
        {
            interactedNFT.SetActive(true);
            pc.selectInteraction(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactedNPC.SetActive(false);
        interactedNFT.SetActive(false);
        pc.deselectInteraction(other.gameObject.name);
    }
}
