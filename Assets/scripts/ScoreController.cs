﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;

    private int score = 0;
    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUI();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        ScoreText.text = "SCORE:" + score;
    }
}