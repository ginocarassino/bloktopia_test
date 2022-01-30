using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainController : MonoBehaviour
{
    public bool isSpeaking;
    public bool isCollected;
    [SerializeField] Rigidbody player;

    [Header("Economy")]
    private int coins = 0;
    private int nfts = 0;

    [Header("UI")]
    [SerializeField] private TMP_Text t_coins;
    [SerializeField] private TMP_Text t_nfts;
    [SerializeField] private GameObject dialogoPanel;

    [SerializeField] private TMP_Text t_dialogue_one;
    [SerializeField] private TMP_Text t_dialogue_two;
    [SerializeField] private TMP_Text t_dialogue_nft;
    [SerializeField] private TMP_Text t_interact_nft;

    [Header("Sounds")]
    [SerializeField] private AudioSource coinCollect_sound;

    void Start()
    {
        t_coins.text = coins.ToString();
    }

    public void collect(GameObject interactable)
    {
        isSpeaking = false;
        dialogoPanel.SetActive(false);
        Time.timeScale = 1.0f;

        if (interactable.name == "interact_nft" && coins >= 3)
        {
            interactable.transform.Find("diamond").gameObject.SetActive(false);
            nfts++;

            t_nfts.text = nfts.ToString();
            coinCollect_sound.Play();

            interactable.SetActive(false);
            t_interact_nft.enabled = false;

            coins = 0;
            t_coins.text = coins.ToString();
        }
        else if (interactable.name == "interact_nft" && coins < 3)
        {

        }
        else
        {
            interactable.transform.Find("diamond").gameObject.SetActive(false);

            if (!isCollected)
            {
                coins++;
                t_coins.text = coins.ToString();
                coinCollect_sound.Play();
            }
        }

        isCollected = false;
    }

    public void Speak(GameObject interactable)
    {
        isSpeaking = true;
        dialogoPanel.SetActive(true);
        Time.timeScale = 0.0f;

        if (interactable.name == "interact_nft")
        {
            t_dialogue_one.enabled = false;
            t_dialogue_two.enabled = false;
            t_dialogue_nft.enabled = true;
        }
        else
        {
            if (interactable.transform.Find("diamond").gameObject.active)
            {
                t_dialogue_one.enabled = true;
                t_dialogue_two.enabled = false;
                t_dialogue_nft.enabled = false;
            }
            else
            {
                isCollected = true;
                t_dialogue_one.enabled = false;
                t_dialogue_two.enabled = true;
                t_dialogue_nft.enabled = false;
            }
        }
    }

}
