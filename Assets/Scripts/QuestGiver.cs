using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    // Human readable quest name
    public string QuestName = string.Empty;

    // Reference to UI Text Box
    public Text Captions = null;

    // Get canvas for hiding
    public Canvas TextCanvas = null;

    // List of strings to say
    public string[] CaptionText;

    // Collider of chest that sends player to next level
    public BoxCollider2D EndChestCol;

    public CoinManager CoinManagerScript;

    private void Start() {

    }

    private void Update() {

        // If all the coins are collected
        if (CoinManagerScript.CoinsCollected == CoinManagerScript.CoinCount) {

            // Enable the end chest
            EndChestCol.enabled = true;

            // Set quest as complete
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.COMPLETE);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);

        // Turn on quest text
        Captions.text = CaptionText[(int)Status]; //Update GUI text
        TextCanvas.GetComponent<CanvasGroup>().alpha = 1.0f;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        if (Status == Quest.QUESTSTATUS.UNASSIGNED)
        {
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.ASSIGNED);
            
        }

        if (Status == Quest.QUESTSTATUS.COMPLETE) { }

        TextCanvas.GetComponent<CanvasGroup>().alpha = 0.0f;
    }
}
