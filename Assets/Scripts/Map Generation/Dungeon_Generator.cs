using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Generator : MonoBehaviour
{
    public enum Direction
    {
        North = 0,
        South,
        East,
        West
    }
    public class Cell
    {
        public int location_x, location_y;
        public bool visited = false;
        public bool[] doors = new bool[4];

        public Cell(int x, int y)
        {
            location_x = x;
            location_y = y;
        }
    }
    [System.Serializable]
    public class Rule
    {
        public GameObject room;
        public Vector2Int min_position;
        public Vector2Int max_position;
        public bool is_unique = false;
        public bool is_spawned = false;

        public bool mandatory;

        public int Propability_Of_Spawning(int x, int y)
        {
            if (x >= min_position.x && x <= max_position.x && y >= min_position.y && y <= max_position.y)
            {
                return mandatory ? 2 : 1;
            }
            return 0;
        }
    }

    public Vector2Int size;
    public int start_position = 0;
    public Rule[] rooms;
    public Vector2 offset;
    public int max_size = 1000;
    List<Cell> board;
    // Start is called before the first frame update
    void Start()
    {
        Maze_Generator();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generate_Dungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (Mathf.FloorToInt(i + j * size.x) > board.Count - 1)
                {
                    continue;
                }
                Cell current_cell = board[i + j * size.x];
                if (current_cell.visited)
                {
                    int random_room = -1;
                    List<int> available_rooms = new List<int>();

                    for (int k = 0; k < rooms.Length; k++)
                    {
                        if (rooms[k].is_unique && rooms[k].is_spawned)
                        {
                            continue;
                        }
                        int p = rooms[k].Propability_Of_Spawning(i, j);

                        if (p == 2)
                        {
                            random_room = k;
                            break;
                        }
                        else if (k == 1)
                        {
                            available_rooms.Add(k);
                        }
                    }
                    if (random_room == -1)
                    {
                        if (available_rooms.Count > 0)
                        {
                            random_room = available_rooms[UnityEngine.Random.Range(0, available_rooms.Count)];
                        }
                        else
                        {
                            random_room = 1;
                        }

                    }


                    var new_room = Instantiate(rooms[random_room].room, new Vector2(i * offset.x, -j * offset.y), Quaternion.identity, transform).GetComponent<Room_Behaviour>();
                    rooms[random_room].is_spawned = true;
                    new_room.UpdateRoom(board[i + j * size.x].doors);
                    new_room.name += " " + i + "-" + j;
                }

            }
        }
    }

    void Maze_Generator()
    {
        board = new List<Cell>();

        if (size.x * size.y == 0)
        {
            Debug.LogWarning("Board dimensions invalid, setting to default 10,10");
            size.x = 10;
            size.y = 10;
        }

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                board.Add(new Cell(x, y));
            }
        }

        int current_cell = start_position;

        Stack<int> path = new Stack<int>();

        for (int i = 0; i < max_size; i++)
        {

            board[current_cell].visited = true;

            if (current_cell == board.Count - 1)
            {
                break;
            }

            List<Direction> possible_directions = Check_Neighbors(current_cell);

            if (possible_directions.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    current_cell = path.Pop();
                }
            }
            else
            {
                path.Push(current_cell);

                //int new_cell = neighbors[UnityEngine.Random.Range(0,neighbors.Count)];
                Direction direction = possible_directions[UnityEngine.Random.Range(0, possible_directions.Count)];

                switch (direction)
                {
                    case Direction.North:
                        board[current_cell].doors[(int)Direction.North] = true;
                        current_cell -= size.x;
                        board[current_cell].doors[(int)Direction.South] = true;
                        break;
                    case Direction.South:
                        board[current_cell].doors[(int)Direction.South] = true;
                        current_cell += size.x;
                        board[current_cell].doors[(int)Direction.North] = true;
                        break;
                    case Direction.East:
                        board[current_cell].doors[(int)Direction.East] = true;
                        current_cell += 1;
                        board[current_cell].doors[(int)Direction.West] = true;
                        break;
                    case Direction.West:
                        board[current_cell].doors[(int)Direction.West] = true;
                        current_cell -= 1;
                        board[current_cell].doors[(int)Direction.East] = true;
                        break;
                }
                // south or east
                //if (new_cell > current_cell)
                //{
                //    if(new_cell - 1 == current_cell)
                //    {
                //        board[current_cell].doors[2] = true;
                //        current_cell = new_cell;
                //        board[current_cell].doors[3] = true;
                //    }
                //    else
                //    {
                //        board[current_cell].doors[1] = true;
                //        current_cell = new_cell;
                //        board[current_cell].doors[0] = true;
                //    }
                //}
                //// north or west
                //else
                //{
                //    if(new_cell + 1 == current_cell)
                //    {
                //        board[current_cell].doors[3] = true;
                //        current_cell = new_cell;
                //        board[current_cell].doors[2] = true;
                //    }
                //    else
                //    {
                //        board[current_cell].doors[0] = true;
                //        current_cell = new_cell;
                //        board[current_cell].doors[1] = true;
                //    }
                //}
            }
        }
        Generate_Dungeon();
    }

    List<Direction> Check_Neighbors(int cell)
    {
        List<Direction> possible_directions = new List<Direction>();

        if (cell - size.x >= 0 && !board[cell - size.x].visited)
        {
            //north
            possible_directions.Add(Direction.North);
        }
        if (cell + size.x < board.Count && !board[cell + size.x].visited)
        {
            //south
            possible_directions.Add(Direction.South);
        }
        if ((cell + 1) % size.x != 0 && !board[cell + 1].visited)
        {
            //east
            possible_directions.Add(Direction.East);
        }
        if (cell % size.x != 0 && !board[cell - 1].visited)
        {
            //west
            possible_directions.Add(Direction.West);
        }
        return possible_directions;
    }
}
