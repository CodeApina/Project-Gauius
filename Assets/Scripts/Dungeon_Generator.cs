using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_Generator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
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
            for(int j = 0; j < size.y; j++)
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
                            random_room = available_rooms[Random.Range(0, available_rooms.Count)];
                        }
                        else 
                        { 
                            random_room = 1; 
                        }
                        
                    }
                    

                    var new_room = Instantiate(rooms[random_room].room, new Vector2(i * offset.x, -j * offset.y), Quaternion.identity, transform).GetComponent<Room_Behaviour>();
                    rooms[random_room].is_spawned = true;
                    new_room.UpdateRoom(board[i + j * size.x].status);

                    new_room.name += " " + i + "-" + j;
                }
                
            }
        }
    }

    void Maze_Generator()
    {
        board = new List<Cell>();

        for (int i = 1; i < size.x; i++) 
        { 
            for (int j = 1; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int  current_cell = start_position;

        Stack<int> path = new Stack<int>();

        int loop = 0;
        
        while (loop < max_size)
        {
            loop++;

            board[current_cell].visited = true;

            if (current_cell == board.Count - 1)
            {
                break;
            }

            List<int> neighbors = Check_Neighbors(current_cell);

            if (neighbors.Count == 0) 
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

                int new_cell = neighbors[Random.Range(0,neighbors.Count)];

                //south or east
                if (new_cell > current_cell)
                {
                    if(new_cell - 1 == current_cell)
                    {
                        board[current_cell].status[2] = true;
                        current_cell = new_cell;
                        board[current_cell].status[3] = true;
                    }
                    else
                    {
                        board[current_cell].status[1] = true;
                        current_cell = new_cell;
                        board[current_cell].status[0] = true;
                    }
                }
                // north or west
                else
                {
                    if(new_cell + 1 == current_cell)
                    {
                        board[current_cell].status[3] = true;
                        current_cell = new_cell;
                        board[current_cell].status[2] = true;
                    }
                    else
                    {
                        board[current_cell].status[0] = true;
                        current_cell = new_cell;
                        board[current_cell].status[1] = true;
                    }
                }
            }
        }
        Generate_Dungeon();
    }

    List<int> Check_Neighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        if (cell - size.x >= 0 && !board[cell - size.x].visited)
        {
            neighbors.Add(cell - size.x);
        }
        if (cell + size.x < board.Count && !board[cell + size.x].visited)
        {
            neighbors.Add(cell + size.x);
        }
        if ((cell + 1) % size.x != 0 && !board[cell + 1].visited)
        {
            neighbors.Add(cell + 1);
        }
        if (cell % size.x != 0 && !board[cell - 1].visited)
        {
            neighbors.Add(cell - 1);
        }
        return neighbors;
    }
}
