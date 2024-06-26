using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Vari�veis Globais
    [Header("Configura��es:")]

    [Header("Velocidade Im�ginaria do Player:")]
    [SerializeField] private int imaginarySpeed = 0;

    [Header("Refer�ncias:")]
    [SerializeField] private TextMeshProUGUI txtScore;

    private float _curMeters;

    public bool CanCount = true;

    public static ScoreManager Instance;
    #endregion

    #region Fun��es Unity
    private void Awake() => Instance = this;

    private void Start() => InvokeRepeating("CalculateDistance", 0, 1 / imaginarySpeed);

    private void Update()
    {
        if (!CanCount) return;
        
        CalculateDistance();
        UpdateScore();
    }
    #endregion

    #region Fun��es Pr�prias
    private void CalculateDistance()
    {
        var distance = imaginarySpeed * Time.deltaTime;
        _curMeters += distance;
    }

    private void UpdateScore()
    {
        txtScore.text = _curMeters.ToString("F2");
        txtScore.text += "m";
    }
    #endregion
}
