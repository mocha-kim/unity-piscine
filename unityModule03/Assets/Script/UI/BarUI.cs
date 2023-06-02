using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Module02.UI
{
    public class BarUI : MonoBehaviour
    {
        [SerializeField] private GameObject grid;
        private List<SummonSlotUI> _summonSlots = new();
        private List<SquareUI> _squares = new ();

        private Vector3 _canvasOffset;
        private Vector3 _mouseOffset;

        private void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var slot = transform.GetChild(i).gameObject;
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
            _canvasOffset = gameObject.GetComponent<RectTransform>().position;
            _mouseOffset = Input.mousePosition;

            MouseData.draggingItem = slot.GetComponent<SummonSlotUI>().CreateTurretImage();
        }
        
        private void OnDrag(GameObject slot)
        {
            if (MouseData.draggingItem == null)
            {
                return;
            }
            
            MouseData.draggingItem.GetComponent<RectTransform>().position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnEndDrag(GameObject slot)
        {
            Destroy(MouseData.draggingItem);

            if (MouseData.mouseHoveredSquare != null)
            {
                var turret = slot.GetComponent<SummonSlotUI>().CreateTurret();
                turret.transform.position = MouseData.mouseHoveredSquare.GetComponent<SquareUI>().GetPositionInWorld();
                turret.transform.SetParent(MouseData.mouseHoveredSquare.transform);
            }
        }
    }
}
