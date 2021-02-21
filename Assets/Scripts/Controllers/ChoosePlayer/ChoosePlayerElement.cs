using Models;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Controllers.ChoosePlayer
{
    [RequireComponent(typeof(Button))]
    public class ChoosePlayerElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerName;
        [SerializeField] private Button deletePlayerButton;
        

        private Button _button;
        private Player _player;
        private UnityAction<Player> _selectAction;
        private UnityAction<Player> _deleteAction;

        public void InitField(Player player, UnityAction<Player> selectPlayerAction, UnityAction<Player> deletePlayerAction)
        {
            _player = player;
            playerName.text = _player.Name;
            _selectAction = selectPlayerAction;
            _deleteAction = deletePlayerAction;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnSelectClicked);
            
            deletePlayerButton.onClick.AddListener(OnDeleteClicked);
        }

        private void OnSelectClicked()
        {
            _selectAction.Invoke(_player);
        }

        private void OnDeleteClicked()
        {
            _deleteAction.Invoke(_player);
        }
    }
}
