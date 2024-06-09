using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NebulousTrinket
{
    public class InGameUIView : MonoBehaviour
    {
        [SerializeField]
        private Button RestartButton;
        [SerializeField]
        private TextMeshProUGUI MatchesTextMesh;
        [SerializeField]
        private TextMeshProUGUI MovesTextMesh;

        public Action OnRestart;

        public void Initialize()
        {
            RestartButton.onClick.AddListener(OnClickResart);
        }

        public void Refresh(int matches, int turns)
        {
            MatchesTextMesh.text = $"Matches\n{matches}";
            MovesTextMesh.text = $"Turns\n{turns}";
        }

        private void OnClickResart() 
        {
            OnRestart?.Invoke();
        }
    }
}
