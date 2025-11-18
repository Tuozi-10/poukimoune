using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
        [SerializeField]  private EntityData m_data;
        private EntityDataWrapper runtimeData;
        
         private void Awake()
         {
             runtimeData = m_data.GetRuntimeData();
         }

         private void Update()
         {
             
         }
    }
}