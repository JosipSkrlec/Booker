using UnityEngine;
using UnityEngine.EventSystems;

namespace JS.Booker.Miscellaneous
{
    /// <summary>
    /// 
    /// </summary>
    public class DraggableObject : MonoBehaviour
    {
        private bool isDragging = false;
        private Vector3 initialOffset;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    initialOffset = transform.position - mousePosition;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = mousePosition + initialOffset;
            }
        }
    }
}