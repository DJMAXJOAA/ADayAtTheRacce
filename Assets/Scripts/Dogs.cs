using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab1
{
    public class Dogs : MonoBehaviour
    {
        [SerializeField]
        int id = 0;

        Rigidbody rigidbody;
        bool isRunning = false;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }
        
        public void SetID(int id)
        {
            this.id = id;
        }

        public void Run()
        {
            float duration = Random.Range(0.5f, 1.0f);
            Debug.Log("duration" + duration);
            
            isRunning = true;
            StartCoroutine(Running(duration));

        }

        public void Stop()
        {
            isRunning = false;
        }

        IEnumerator Running(float duration)
        {
            while (isRunning)
            {
                int velocity = Random.Range(100, 1000);
                Debug.Log("velocity" + velocity);
                rigidbody.AddForce(new Vector3(velocity, 0, 0));

                yield return new WaitForSeconds(duration);
            }
        }
    }

}