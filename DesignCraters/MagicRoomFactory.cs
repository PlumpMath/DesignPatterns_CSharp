using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{
    //магическая фабрика
    class MagicRoomFactory : RoomFactory
    {

        public override Room makeRoom(int x, int y)
        {
            return new MagicRoom();
        }


        public override Door makeDoor()
        {
            return new MagicDoor();
        }

    }
}
