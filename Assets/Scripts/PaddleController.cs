using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float minX = -7;
    [SerializeField] private float maxX = 7;
    

    private void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits - screenWidthInUnits / 2;
        mousePositionInUnits = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        transform.position = paddlePosition;
    }
}
