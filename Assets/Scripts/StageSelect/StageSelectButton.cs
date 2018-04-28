using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using CCG.Enums;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField]
    private StageID _stageID = StageID.None;

    [SerializeField]
    private Text _stageNumText;

	private void Awake()
	{
        _stageNumText.text = $"{(int)_stageID}";
	}
}
