using UnityEngine;
using Random = UnityEngine.Random;

namespace RAP.Gravity_lvl.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravitySwitcher : MonoBehaviour
    {
        public float gravityScale = 1.0f;
        private float _timer;
        private GameObject _clone;
    
        public static float globalGravity = -9.81f;
 
        Rigidbody m_rb;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        void OnEnable ()
        {
            m_rb = GetComponent<Rigidbody>();
            m_rb.useGravity = false;
        }
 
        void FixedUpdate ()
        {
            _timer += Time.fixedDeltaTime;
            if (_timer >= 5.0f)
            {
                Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                gameObject.GetComponent<Renderer>().material.color = color;
                if (gravityScale == 0)
                {
                    RandomMove();
                    if (_clone)
                    {
                        Destroy(_clone);
                    }
                    Split();
                }
                ChangeGravity();
                _timer = 0f;
            }
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
        }

        private void ChangeGravity()
        {
            gravityScale *= -1;
            if (!gameObject.CompareTag("Player")) return;
            var rotation = transform.rotation;
            rotation = Quaternion.Euler(rotation.eulerAngles.x,-rotation.eulerAngles.y,rotation.eulerAngles.z+180);
            transform.rotation = rotation;
        }

        private void RandomMove()
        {
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            m_rb.AddForce(direction, ForceMode.Impulse);
        }

        private void Split()
        {
            if (Random.Range(0, 2) == 0)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                _clone = Instantiate(gameObject, transform.position, transform.rotation);
                _clone.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
                _rigidbody.AddForce(transform.forward * -1, ForceMode.Impulse);
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Floating Cube")) return;
            if (!_clone) return;
            _clone.GetComponent<BoxCollider>().isTrigger = false;
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}