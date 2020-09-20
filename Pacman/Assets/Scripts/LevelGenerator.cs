using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour

{

    public GameObject[] tilePrefabs;


    //0 – Empty(do not instantiate anything)
    //1 - Outside corner(double lined corener piece in orginal game)
    //2 - Outside wall(double line in original game)
    //3 - Inside corner(single lined corener piece in orginal game)
    //4 - Inside wall(single line in orginal game)
    //5 - Standard pellet(see Visual Assets above)
    //6 - Power pellet(see Visual Assets above)
    //7 - A t junction piece for connecting with adjoining regions

    private int[,] Map =
    {

 {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
 {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
 {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
 {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
 {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
 {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
 {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
 {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
 {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
 {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
 {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
 {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
 {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
 };

   // 0 - 0 degrees
   // 1 - 90 degrees
   // 2 - 180 degrees
   // 3 - 270 degrees
   // 4 - -90 degrees
   

    private int[,] MapRotations =
{

  {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
  {2,0,0,0,0,0,0,0,0,0,0,0,0,2},
  {2,0,1,1,1,0,0,1,1,1,1,0,0,2},
  {2,0,2,0,0,0,0,2,0,0,2,0,0,2},
  {2,0,2,3,3,3,0,2,3,3,3,3,3,2},
  {2,0,0,0,0,0,0,0,0,0,0,0,0,0},
  {2,0,1,1,1,0,0,1,0,0,1,1,1,1},
  {2,0,2,4,4,3,0,2,0,0,2,4,4,0},
  {2,0,0,0,0,0,0,2,0,0,0,0,0,0},
  {2,1,1,1,1,0,0,2,2,4,4,0,0,0},
  {2,0,0,0,2,0,0,2,1,1,1,4,1,2},
  {2,0,0,0,2,0,0,2,0,0,0,0,0,0},
  {1,0,0,0,4,0,0,2,0,0,1,1,1,0},
  {4,4,4,4,4,4,0,2,3,0,2,0,0,0},
  {2,0,0,0,0,0,0,0,0,0,2,0,0,0},
 };

    public float Width = 1;
    public float Height = 1;
    void Start()
    {
        GameObject tileParent = new GameObject("TileParent");
       

        for (int row = 0; row < Map.GetLength(0); row++)
        {
            for (int col = 0; col < Map.GetLength(1); col++)
            {
                float degrees = 0;
                switch (MapRotations[row, col])
                {
                    default:
                    case 0:
                        break;
                    case 1:
                        degrees = 90f;
                        break;
                    case 2:
                        degrees = 180f;
                        break;
                    case 3:
                        degrees = 270f;
                        break;
                    case 4:
                        degrees = -90f;
                        break;

                }
             
                Instantiate(tilePrefabs[Map[row, col]], new Vector2(row * Width, col * Height),Quaternion.Euler(0,0,degrees),tileParent.transform);
            }
        }

       tileParent.transform.rotation = Quaternion.Euler(0, 0, -90f);

        GameObject tileParent2 = Instantiate(tileParent, new Vector2((Map.GetLength(0)* Width*2) - (Width *3f), 0), Quaternion.Euler(0, 180f,-90f));
        tileParent2.name = "TileParent2";

        GameObject tileParent3 = Instantiate(tileParent, new Vector2(0,-28), Quaternion.Euler(0, 180f, 90f));
        tileParent3.name = "TileParent3";

         GameObject tileParent4 = Instantiate(tileParent, new Vector2(27, -28), Quaternion.Euler(1, 360f,90f));
        tileParent4.name = "TileParent4";



    }

}

    

