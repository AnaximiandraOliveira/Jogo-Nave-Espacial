using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    
  public static Vector2 GetDimensionInWorldUnits()
  {

   float width, height;
   Camera cam = Camera.main;

    float ratio = cam.pixelWidth / (float)cam.pixelHeight;
    height = cam.orthographicSize * 2;
    width = height * ratio;

   return new Vector2 (width, height);   

  }
    
         //Script para capturar o tamanho da tela, scprit padrão
    
}
