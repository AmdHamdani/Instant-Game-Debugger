﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebugger
{

    private GameDebugBehaviour debuggerBehaviour;
    private int counter;

    public void Init() {
        debuggerBehaviour = GameObject.FindObjectOfType<GameDebugBehaviour>();
    }

    public void AddButton(string buttonName, System.Action OnClicked) {
        var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Button);
        go.name = counter + " - " + buttonName;
        go.GetComponent<Button>().onClick.AddListener(() => OnClicked());
    }

    public void AddText(string text, bool isUpdate = false) {
        var go = debuggerBehaviour.InstantiateInCanvas(DebugType.Text);
        var uiText = go.GetComponent<Text>();
        debuggerBehaviour.TextUpdates.Add(
            new TextUpdate { 
                TextValue = uiText,
                StrValue = text,
                IsUpdate = isUpdate
            }
        );
    }

    public void AddSeparator() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Separator);
    }

    public void AddConsole() {
        debuggerBehaviour.InstantiateInCanvas(DebugType.Console);
    }

}
