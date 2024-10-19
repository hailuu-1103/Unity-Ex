namespace Runtime
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public delegate void TileClicked(int row, int column);

    public class Tile : MonoBehaviour, IPointerDownHandler
    {
        public int      Row;
        public int      Column;
        public TMP_Text TxtIndex;
        public Image    ImgBg;

        public event TileClicked OnTileClicked;

        private void Awake() { this.TxtIndex.text = string.Empty; }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.ImgBg.color = Color.cyan;
            this.OnTileClicked?.Invoke(this.Row, this.Column);
        }
    }
}