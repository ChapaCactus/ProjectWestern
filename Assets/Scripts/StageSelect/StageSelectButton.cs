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
    private bool _isDebugMode = false;

    [SerializeField]
    private Text _debugStageNumText;

	private void Awake()
	{
        Assert.IsNotNull(_debugStageNumText);

        _debugStageNumText.enabled = _isDebugMode;
	}
}
