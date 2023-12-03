using UnityEngine;

namespace RAP.Scripts
{
    public class Move : MonoBehaviour
    {
        
        
        private float speed = 2.0f;

        private Camera _camera;
        //public GameObject character;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update ()
        {
            Movement();
        }

        private void Movement()
        {
            /*KeyCode key = GetLastPressedKey();
            switch (key)
            {
                case KeyCode.W:
                    transform.position += Vector3.forward * (speed * Time.deltaTime);
                    break;
                case KeyCode.A:
                    transform.position += Vector3.left * (speed * Time.deltaTime);
                    break;
                case KeyCode.S:
                    transform.position += Vector3.back * (speed * Time.deltaTime);
                    break;
                case KeyCode.D:
                    transform.position += Vector3.right * (speed * Time.deltaTime);
                    break;
            }*/
            Vector3 cameraForward = _camera.transform.forward;
            cameraForward.y = 0; // обнуляем компоненту Y, чтобы двигаться только вперёд и назад
            cameraForward.Normalize(); // нормализуем вектор, чтобы его длина была равна 1

            // Получаем вектор движения от клавиш WASD (или стрелок)
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 movement = cameraForward * verticalInput + _camera.transform.right * horizontalInput;
            transform.Translate(movement * (speed * Time.deltaTime), Space.World);
        }

        private KeyCode GetLastPressedKey()
        {
            foreach(KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    return keyCode;
                }
            }
            return KeyCode.None;
        }
    }
    
}
