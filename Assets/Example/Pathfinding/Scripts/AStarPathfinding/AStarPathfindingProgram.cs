// ****************************************************
//     文件：PathfindingProgram.cs
//     作者：积极向上小木木
//     邮箱：positivemumu@126.com
//     日期：2021/3/13 23:45:29
//     功能：寻路算法控制类
// *****************************************************

using System.Collections.Generic;
using TraditionalPathfinding;
using UnityEngine;

namespace AStarPathfinding
{
    public class AStarPathfindingProgram : MonoBehaviour
    {
        public GameObject MapTiled;
        private int[,] numberMap;
        private GameObject[,] map;
        void Start()
        {
            //1.起点
            //2.终点
            //3.障碍
            //4.道具（必走）
            
            //构建数字地图
            //通过代码生成，这里手动生成。
            //这里的11和6对应地图的宽度和高度
            numberMap = new int[11,6]
            {
                {0,0,0,0,0,0},
                {0,0,0,1,0,0},
                {0,3,4,0,3,0},
                {0,3,0,0,3,0},
                {0,3,3,3,3,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0},
                {0,2,0,0,0,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0}
            };
            
            int mapWidth = 11;
            int mapHeight = 6;
            
            map = new GameObject[mapWidth,mapHeight];
            Transform mapBG=GameObject.Find("Map").transform;
            Color[] colors = new Color[5]
            {
                Color.white,
                Color.green,
                Color.red,
                Color.blue, 
                Color.gray
            };
            
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j <mapHeight ; j++)
                {
                    GameObject temp=Instantiate(MapTiled, mapBG);
                    temp.transform.localPosition = new Vector3(i, j, 0);
                    temp.GetComponent<SpriteRenderer>().color = colors[numberMap[i, j]];
                    map[i, j] = temp;
                }
            }
            
            
            
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j <mapHeight; j++)
                {
                    GameObject temp=Instantiate(MapTiled, mapBG);
                    temp.transform.localPosition = new Vector3(i, j, 0);
                    temp.GetComponent<SpriteRenderer>().color = colors[numberMap[i, j]];
                    map[i, j] = temp;
                }
            }
            

            AStarTest();

        }

        public void AStarTest()
        {
            List<AStarNode> passNodes = new List<AStarNode>();
            AStarNode starNode = new MyAStarNode(1, 3,1);
            AStarNode endNode = new MyAStarNode(8, 1,2);
            AStarSystem aStarSystem = new AStarSystem(numberMap,3);
            bool result=aStarSystem.FindPath(starNode, endNode, ref passNodes);

            if (result)
            {
                for (int i = 0; i < passNodes.Count; i++)
                {
                    if (!passNodes[i].EqualOther(starNode) && !passNodes[i].EqualOther(endNode))
                    {
                        map[passNodes[i].Point.X, passNodes[i].Point.Y].GetComponent<SpriteRenderer>().color = Color.yellow;
                    }
                }
                Debug.Log("寻路成功！");
            }
            else
            {
                Debug.Log("寻路失败！");
            }
            
        }
    }
}

