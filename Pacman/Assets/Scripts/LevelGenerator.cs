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
  {2,0,0,0,0,0,0,0,0,0,0,0,0,0},
  {2,0,1,1,1,0,0,1,1,1,1,0,0,2},
  {2,0,2,0,0,0,0,2,0,0,2,0,0,2},
  {2,0,2,3,3,3,0,2,3,3,3,3,3,2},
  {2,0,0,0,0,0,0,0,0,0,0,0,0,0},
  {2,0,1,1,1,0,0,1,0,0,1,1,1,1},
  {2,0,2,4,4,3,0,2,0,0,2,4,4,0},
  {2,0,0,0,0,0,0,2,0,0,0,0,0,0},
  {2,4,4,4,4,0,0,2,2,4,4,0,0,0},
  {2,0,0,0,2,0,0,2,1,1,1,4,1,1},
  {2,0,0,0,2,0,0,2,0,0,0,0,0,0},
  {1,0,0,0,4,0,0,2,0,0,0,1,1,0},
  {4,4,4,4,4,4,0,1,2,0,0,0,0,0},
  {2,0,0,0,0,0,0,0,0,0,0,0,0,0},
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

        //GameObject tileParent2 = Instantiate(tileParent, new Vector2((Map.GetLength(0)* Width*2) - (Width *2.5f), 0), Quaternion.Euler(0, 180f,-90f));
        //tileParent2.name = "TileParent2";



        //   for (int row = 0; row < Map.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < Map.GetLength(1); col++)
        //        {
        //            if (Map[row, col] == 0)
        //            {
        //                Instantiate(tilePrefabs[0], new Vector3(row, col, 0), Quaternion.identity);
        //            }
        //            else if (Map[row, col] == 1)
        //            {
        //                if (row == 9 && col ==0 )
        //                    Instantiate(tilePrefabs[1], new Vector3(row, col, 0), Quaternion.Euler(0, 0, -180));
        //                else if (row == 0)
        //                    Instantiate(tilePrefabs[1], new Vector3(row, col, 0), Quaternion.Euler(0, 0, 90));

        //                else
        //                    Instantiate(tilePrefabs[1], new Vector3(row, col, 0), Quaternion.identity);

        //            }
        //            else if (Map[row, col] == 2)

        //            {
        //               if ( row == 1 || row == 2 || row == 3 || row == 4 || row == 5 || row == 6 || row == 7 || row == 8 ||row ==10|| row == 11 || row == 12)
        //                    Instantiate(tilePrefabs[2], new Vector3(row, col, 0), Quaternion.identity);


        //               else
        //                Instantiate(tilePrefabs[2], new Vector3(row , col, 0), Quaternion.Euler(0,0,-90));
        //            }
        //            else if (Map[row, col] == 3)
        //            {
        //                Instantiate(tilePrefabs[3], new Vector3(row, col, 0), Quaternion.identity);
        //            }
        //            else if (Map[row, col] == 4)
        //            {
        //                if (row < 14)

        //                    Instantiate(tilePrefabs[4], new Vector3(row, col, 0), Quaternion.Euler(0, 0, -90));
        //                else

        //                Instantiate(tilePrefabs[4], new Vector3(row, col, 0), Quaternion.identity);
        //            }
        //            else if (Map[row, col] == 5)
        //            {
        //                Instantiate(tilePrefabs[5], new Vector3(row, col, 0), Quaternion.identity);
        //            }
        //            else if (Map[row, col] == 6)
        //            {
        //                Instantiate(tilePrefabs[6], new Vector3(row, col, 0), Quaternion.identity);
        //            }
        //            else if (Map[row, col] == 7)
        //            {
        //                if (row == 0 && col== 13)
        //                    Instantiate(tilePrefabs[7], new Vector3(row, col, 0), Quaternion.Euler(0, 0, 90));
        //                else

        //                Instantiate(tilePrefabs[7], new Vector3(row, col, 0), Quaternion.identity);
        //            }



        //        }
        //    }
    }

}

    

