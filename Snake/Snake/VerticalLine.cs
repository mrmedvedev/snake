﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine :Figure
    {
       
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int x = yUp; x <= yDown; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);

            }

        }
        
    }
}