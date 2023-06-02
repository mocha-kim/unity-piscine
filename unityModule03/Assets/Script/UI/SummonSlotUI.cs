using UnityEngine;
using UnityEngine.UI;

namespace Module02.UI
{
    public class SummonSlotUI : MonoBehaviour
    {
        private float _fixValue = 1.0f / 77.0f;
        private GameObject _canvas;
        
        [SerializeField] private GameObject turretPrefab;

        public void SetCanvas(GameObject canvas)
        {
            _canvas = canvas;
        }
        
        public GameObject CreateTurret()
        {
            return GameObject.Instantiate(turretPrefab);
        }
        
        public GameObject CreateTurretImage()
        {
            GameObject turret = new GameObject();
            RectTransform rect = turret.AddComponent<RectTransform>();
            rect.localScale = new Vector3(_fixValue, _fixValue, _fixValue);
            rect.sizeDelta = new Vector2(90.0f, 60.0f);
            turret.transform.SetParent(_canvas.transform);

            Image image = turret.AddComponent<Image>();
            image.sprite = turretPrefab.GetComponent<SpriteRenderer>().sprite;
            image.raycastTarget = false;

            turret.name = "Dragging Item";
            return turret;
        }
    }
}