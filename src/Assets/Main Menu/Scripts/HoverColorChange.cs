#region

using TMPro;
using UnityEngine;

#endregion

namespace RAP.Main_Menu
{
    public class HoverColorChange : MonoBehaviour
    {
        public Color hoverColor = Color.blue;
        private Color _originalColor;
        private TextMeshProUGUI _textMeshPro;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
            _textMeshPro = transform.GetComponentInChildren<TextMeshProUGUI>();
            _originalColor = _textMeshPro.color;
        }

        public void OnPointerEnter()
        {
            _audioSource.Play();
            _textMeshPro.color = hoverColor;
        }

        public void OnPointerExit()
        {
            _textMeshPro.color = _originalColor;
        }
    }
}