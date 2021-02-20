using Models;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers.CreatePlayer
{
    public class CreatePlayerController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private Button cancelButton;
        [SerializeField] private Button createButton;
        [SerializeField] private PlayersTable playersTable;

        private UnityAction<Player> _createPlayerAction;
        private UnityAction _cancelAction;

        public void Initiate(UnityAction<Player> createPlayerAction, UnityAction cancelAction)
        {
            _createPlayerAction = createPlayerAction;
            _cancelAction = cancelAction;
        }

        private void Start()
        {
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
            createButton.onClick.AddListener(OnCreatePlayerButtonClicked);
        }
    
        private void OnCreatePlayerButtonClicked()
        {
            if (string.IsNullOrEmpty(nameInputField.text))
                return;

            var createdPlayer = playersTable.AddPlayer(nameInputField.text);

            if (createdPlayer == null)
            {
                //TODO show error message
                return;
            }

            _createPlayerAction.Invoke(createdPlayer);
        }

        private void OnCancelButtonClicked()
        {
            _cancelAction.Invoke();
        }
    }
}
