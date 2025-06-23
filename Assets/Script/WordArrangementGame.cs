using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class WordArrangementGame : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private string targetWord = "AnglerFish"; // The word to arrange
                                                               // [SerializeField] private float letterSpacing = 50f; // Spacing between letters in the assembled word

    [Header("References")]
    [SerializeField] private Transform buttonContainer; // Parent of letter buttons
    [SerializeField] private Transform wordContainer; // Where correct letters will be placed
    [SerializeField] private Color wrongColor = Color.red; // Color when wrong letter is clicked
    [SerializeField] private Color defaultColor = Color.white; // Default button color

    private List<Button> letterButtons = new List<Button>();
    private List<Vector2> buttonStartPositions = new List<Vector2>();
    private int currentLetterIndex = 0;
    private Button lastClickedButton;
    public GameObject next;

    private void OnEnable()
    {
        // Get all letter buttons
        letterButtons = buttonContainer.GetComponentsInChildren<Button>().ToList();

        // Store their starting positions (for resetting if wrong)
        foreach (Button button in letterButtons)
        {
            buttonStartPositions.Add(button.GetComponent<RectTransform>().anchoredPosition);
            button.onClick.AddListener(() => OnLetterButtonClick(button));
        }
        next.SetActive(false);
        // Shuffle button positions
        ShuffleButtonPositions();
    }

    // Shuffles the positions of letter buttons
    private void ShuffleButtonPositions()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < letterButtons.Count; i++)
        {
            int randomIndex = rand.Next(0, letterButtons.Count);
            Vector2 tempPos = buttonStartPositions[randomIndex];
            buttonStartPositions[randomIndex] = buttonStartPositions[i];
            buttonStartPositions[i] = tempPos;
        }

        // Apply shuffled positions
        for (int i = 0; i < letterButtons.Count; i++)
        {
            letterButtons[i].GetComponent<RectTransform>().anchoredPosition = buttonStartPositions[i];
        }
    }

    // Called when a letter button is clicked
    private void OnLetterButtonClick(Button clickedButton)
    {
        string clickedLetter = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        string expectedLetter = targetWord[currentLetterIndex].ToString();

        if (clickedLetter == expectedLetter)
        {
            if (lastClickedButton != null)
            {
                // Reset previous wrong button color
                lastClickedButton.image.color = defaultColor;
            }
            // Correct letter clicked
            lastClickedButton = null;
            currentLetterIndex++;

            // Move the button to the word container
            clickedButton.transform.SetParent(wordContainer);
            clickedButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                (currentLetterIndex - 1),
                0f
            );

            // Disable the button after correct placement
            clickedButton.interactable = false;

            // Check if the word is complete
            if (currentLetterIndex == targetWord.Length)
            {
                next.SetActive(true);
                Debug.Log("Word Completed!");
                // Optional: Trigger win condition (e.g., show success message)
            }
        }
        else
        {
            // Wrong letter clicked
            if (lastClickedButton != null)
            {
                // Reset previous wrong button color
                lastClickedButton.image.color = defaultColor;
            }

            // Highlight the wrong button in red
            clickedButton.image.color = wrongColor;
            lastClickedButton = clickedButton;

            Debug.Log("Wrong Letter! Try again.");
        }
    }

    // Resets the game (call this if needed)
    public void ResetGame()
    {
        currentLetterIndex = 0;
        lastClickedButton = null;

        // Reset button colors and positions
        for (int i = 0; i < letterButtons.Count; i++)
        {
            letterButtons[i].image.color = defaultColor;
            letterButtons[i].interactable = true;
            letterButtons[i].transform.SetParent(buttonContainer);
            letterButtons[i].GetComponent<RectTransform>().anchoredPosition = buttonStartPositions[i];
        }

        ShuffleButtonPositions();
    }
}