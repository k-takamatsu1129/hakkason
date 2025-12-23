using System.Collections;
using UnityEngine;

public class FCSS : MonoBehaviour
{
        public float speed = 7f;

        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void Start()
        {
            StartCoroutine(destroyMe());
        }

        IEnumerator destroyMe()
        {
            yield return new WaitForSeconds(40f);
            Destroy(this.gameObject);
        }
    
}
