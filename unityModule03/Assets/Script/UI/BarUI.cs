using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Module02.UI
{
    public class BarUI : MonoBehaviour
    {
        private List<SummonSlotUI> _summonSlots = new();
        private List<SquareUI> _squares = new ();

        private TextMeshProUGUI _hpValueText;
        private Slider _hpSlider;
        private TextMeshProUGUI _energyValueText;
        
        [SerializeField] private GameObject turretsParent;
        [SerializeField] private GameObject grid;
        [SerializeField] private GameObject hpSection;
        [SerializeField] private GameObject energySection;

        private void Awake()
        {
            _hpValueText = hpSection.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            _hpSlider = hpSection.transform.GetChild(2).GetComponent<Slider>();
            _energyValueText = energySection.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            var summonSlots = transform.GetChild(0);
            for (int i = 0; i < summonSlots.childCount; i++)
            {
                var slot = summonSlots.GetChild(i).gameObject;
                _summonSlots.Add(slot.GetComponent<SummonSlotUI>());
                slot.GetComponent<SummonSlotUI>().SetCanvas(transform.parent.gameObject);
                RegisterSlotEvents(slot);
            }
            for (int i = 0; i < grid.transform.childCount; i++)
            {
                var square = grid.transform.GetChild(i).gameObject;
                _squares.Add(square.GetComponent<SquareUI>());
                RegisterSquareEvents(square);
            }
        }

        private void Start()
        {
            GameManager.Instance.OnHPChanged += OnHPChanged;
            GameManager.Instance.OnEnergyChanged += OnEnergyChanged;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnHPChanged -= OnHPChanged;
            GameManager.Instance.OnEnergyChanged -= OnEnergyChanged;
        }

        private void RegisterSlotEvents(GameObject slot)
        {
            AddEntry(slot, EventTriggerType.BeginDrag, delegate { OnBeginDrag(slot); });
            AddEntry(slot, EventTriggerType.Drag, delegate { OnDrag(slot); });
            AddEntry(slot, EventTriggerType.EndDrag, delegate { OnEndDrag(slot); });
        }

        private void RegisterSquareEvents(GameObject square)
        {
            AddEntry(square, EventTriggerType.PointerEnter, delegate { OnEnterSquare(square); });
            AddEntry(square, EventTriggerType.PointerExit, delegate { OnExitSquare(square); });
        }

        private void AddEntry(GameObject go, EventTriggerType type, UnityAction<BaseEventData> action)
        {
            var trigger = go.GetComponent<EventTrigger>();
            if (!trigger)
            {
                Debug.LogError("No EventTrigger in " + gameObject);
                return;
            }
            
            var entry = new EventTrigger.Entry { eventID = type };
            entry.callback.AddListener(action);
            trigger.triggers.Add(entry);
        }

        private void OnEnterSquare(GameObject square)
        {
            MouseData.mouseHoveredSquare = square;
        }
        
        private void OnExitSquare(GameObject square)
        {
            MouseData.mouseHoveredSquare = null;
        }
        
        private void OnBeginDrag(GameObject slot)
        {
            MouseData.draggingItem = slot.GetComponent<SummonSlotUI>().CreateTurretImage();
        }
        
        private void OnDrag(GameObject slot)
        {
            if (MouseData.draggingItem == null)
            {
                return;
            }

            var imgPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            imgPosition.z = 80.0f;
            MouseData.draggingItem.GetComponent<RectTransform>().position = imgPosition;
        }

        private void OnEndDrag(GameObject slot)
        {
            Destroy(MouseData.draggingItem);

            if (MouseData.mouseHoveredSquare != null)
            {
                var turret = slot.GetComponent<SummonSlotUI>().CreateTurret();
                var square = MouseData.mouseHoveredSquare.GetComponent<SquareUI>();
                if (!square.OccupySquare(turret.GetComponent<Turret>().Cost))
                {
                    Destroy(turret);
                    return;
                }
                if (square.IsRightSide)
                {
                    turret.GetComponent<SpriteRenderer>().flipX = true;
                }
                turret.transform.position = square.GetPositionInWorld();
                turret.transform.SetParent(turretsParent.transform);
            }
        }

        private void OnHPChanged(float hp)
        {
            _hpValueText.text = hp.ToString("F0");
            _hpSlider.value = GameManager.Instance.PercentHP;
        }

        private void OnEnergyChanged(int energy)
        {
            _energyValueText.text = energy.ToString();
        }
    }
}
