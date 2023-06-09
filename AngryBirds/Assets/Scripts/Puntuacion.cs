using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    
    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = puntos.ToString("0");
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        textMesh.text = puntos.ToString();
    }
}
