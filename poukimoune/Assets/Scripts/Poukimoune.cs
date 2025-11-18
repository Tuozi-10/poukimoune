using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Poukimoune : MonoBehaviour
    {
         [SerializeField] private EntityData data;
         private EntityDataWrapper runtimeData;
         [SerializeField] private Image lifeBar;
         [SerializeField] private TMP_Text lifeText;

         private void Awake()
         {
             runtimeData = data.GetRuntimeData();
         }

         private void Update()
         {
             if (Input.GetKeyDown(KeyCode.A))
             {
                 runtimeData.LoseLife(10, lifeBar, lifeText);
             }
         }
         
         public void DetermineIAAction()
         {
            
         }
    }
}