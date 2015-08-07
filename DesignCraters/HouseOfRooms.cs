using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{
    class HouseOfRooms
    {


        //создание комнаты в зависимости от типа
        public Room createRoom(RoomFactory rFactory, int x, int y)
        {

            //создается комната
            Room room = rFactory.makeRoom(x, y);

            room.setSide(Direction.North, rFactory.makeWall(x));
            room.setSide(Direction.South, rFactory.makeWall(x));
            room.setSide(Direction.East, rFactory.makeWall(y));
            room.setSide(Direction.West, rFactory.makeWall(y));

            return room;
        }


    }
}
