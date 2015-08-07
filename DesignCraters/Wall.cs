using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignCraters
{

    class Wall
    {

        private MapSite[] Bricks;


        public Wall(int size)
        {
            Bricks = new MapSite[size];
            for (int i = 0; i < size; i++)
            {
                Bricks[i] = new MapSite();
            }

        }

        public void setBrick(int offset, MapSite site)
        {
            if(offset < Bricks.Length) 
            Bricks[offset] = site;
        }


        public int getSize()
        {
            return Bricks.Length;
        }



    }
}
