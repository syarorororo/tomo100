using Kouya;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kouya
{

    public class ChairsGame_Chair : MonoBehaviour
    {
        Kouya.Chairsgame_base c_Base;
        ChairGame_Player player;
        public bool isSit = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
           
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("当たった相手:" + collision.gameObject.name);
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("椅子がとられました");
                isSit = true;
                c_Base.IsSitting(true);
                Debug.Log("椅子:" + isSit);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("椅子をプレイヤーがとりました");
                isSit= true;   
                player.IsSitting(true);
                Debug.Log("椅子:" + isSit);
            }
        }
    }
}
