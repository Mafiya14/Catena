using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TextAsset _jsonFile;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TextMeshProUGUI _speech;
    [SerializeField] private Button _continueButton;

    private Story _currentStory;

    private void Awake()
    {
        GameStateController.OnPreparationStateEntered += StartDialogue;

        _continueButton.onClick.AddListener(ContinueStory);
    }

    private void OnDestroy()
    {
        GameStateController.OnPreparationStateEntered -= StartDialogue;
    }

    public void StartDialogue()
    {
        _currentStory = new Story(_jsonFile.text);
        _speech.text = _currentStory.Continue();
        _dialoguePanel.SetActive(true);
    }

    private void ContinueStory()
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        if (_currentStory.canContinue)
        {
            _speech.text = _currentStory.Continue();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        _dialoguePanel.SetActive(false);
    }
}
