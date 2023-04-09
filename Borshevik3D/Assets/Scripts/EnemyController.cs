using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Borshevik.EnemyControl
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private int HitsToDeath = 3;

        private void OnTriggerEnter(Collider other)
        {
            HitsToDeath--;
            if(HitsToDeath < 1) Destroy(this.gameObject);
        }
    }
}
