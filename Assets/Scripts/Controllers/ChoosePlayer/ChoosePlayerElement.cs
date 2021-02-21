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

        private Button _button;
        private Player _player;
        private UnityAction<Player> _onClickAction;

        public void InitField(Player player, UnityAction<Player> action)
        {
            _player = player;
            playerName.text = _player.Name;
            _onClickAction = action;
            _button = GetComponent<Button>();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            _onClickAction.Invoke(_player);
        }
    }
}
