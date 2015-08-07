using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{
    enum Direction 
    {         
        North, South, East, West, None       
    }; 

    static class DirectionMethods
    {
        public static Direction getReverse(Direction dc)
        {
            switch (dc)
            {
                case Direction.North:
                    return Direction.South;

                case Direction.East:
                    return Direction.West;

                case Direction.South:
                    return Direction.North;

                case Direction.West:
                    return Direction.East;
            }
            return Direction.None;
        }
    }

    class Room : MapSite
    {

        private int _vSize { get; set; }
        private int _hSize { get; set; }
        private int status;
        private Wall[] walls;
        private int number;

        public override void Enter()
        {
            status = 1;

        }

        public Room() : this(1, 1)
        {      

        }

        public Room(int hSize, int vSize)
        {
            status = 0;
            walls = new Wall[4];
            _vSize = vSize;
            _hSize = hSize;
        }

        public void setSide(Direction dc, Wall ms)
        {
            switch (dc)
            {
                case Direction.North:
                    if(ms.getSize() == _hSize)
                    walls[0] = ms;
                break;

                case Direction.East:
                    if(ms.getSize() == _vSize)
                    walls[1] = ms;
                break;

                case Direction.South:
                if (ms.getSize() == _hSize)
                    walls[2] = ms;
                break;

                case Direction.West:
                    if(ms.getSize() == _vSize)
                    walls[3] = ms;
                break;

                   
            }
        }

        public Wall getSide(Direction dc)
        {
            switch (dc)
            {
                case Direction.North:
                    return walls[0];

                case Direction.East:
                    return walls[1];

                case Direction.South:
                    return walls[2];

                case Direction.West:
                    return walls[3];
            }
            return null;

        }




    }
}
