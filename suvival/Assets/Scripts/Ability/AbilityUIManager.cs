using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUIManager : MonoBehaviour
{
    [SerializeField] Ability[] abilities;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(abilities[0].DoActive);
    }
}
