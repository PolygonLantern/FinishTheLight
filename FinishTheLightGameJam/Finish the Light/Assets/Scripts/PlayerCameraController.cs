using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float smoothing;
    [SerializeField] private int rotationLimitation;

    private GameObject _player;
    private Vector2 _smoothVelocity;
    private Vector2 _currentLookingPosition;
    private void Start()
    {
        _player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));
        
        _smoothVelocity.x = Mathf.Lerp(_smoothVelocity.x, inputValues.x,1f / smoothing);
        _smoothVelocity.y = Mathf.Lerp(_smoothVelocity.y, inputValues.y,1f / smoothing);

        _currentLookingPosition += _smoothVelocity;

        _currentLookingPosition.y = Mathf.Clamp(_currentLookingPosition.y, -rotationLimitation, rotationLimitation);
        transform.localRotation = Quaternion.AngleAxis(-_currentLookingPosition.y, Vector3.right);
        _player.transform.localRotation = Quaternion.AngleAxis(_currentLookingPosition.x, _player.transform.up);
    }


}
