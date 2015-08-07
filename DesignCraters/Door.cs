using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{
    class Door : MapSite
    {

        private Room room1;
        private Room room2;
        //private int rOffset1;
        //private int rOffset2;
        private bool isOpen;


        public void setDoor(Room r1, Room r2, int offs1, int offs2, Direction dir)
        {
            room1 = r1;
            room2 = r2;
            Wall wall1 = room1.getSide(dir);
            Wall wall2 = room2.getSide(DirectionMethods.getReverse(dir));
            wall1.setBrick(offs1, this);
            wall1.setBrick(offs2, this);
        }


        public override void Enter()
        {

        }





    }
}
