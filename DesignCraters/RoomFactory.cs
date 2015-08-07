using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{
    //фабрика комнат
    class RoomFactory
    {


        //создание virtual функции - она отличается от abstrcact, что имеет функционал
        public virtual Room makeRoom(int x, int y)
        {
            return new Room(x, y);
        }

        public virtual Door makeDoor()
        {
            return new Door();
        }

        public virtual Wall makeWall(int size)
        {
            return new Wall(size);
        }



    }
}
