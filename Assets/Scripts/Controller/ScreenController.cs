using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    private void Update()
    {
        transform.position = playerModel.currentPosition;
    }
}
