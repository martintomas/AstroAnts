using System.Collections.Generic;

namespace AstroAnts.Graphs
{
    public class GraphDirections
    {
        private const byte maxDirections = 4;
        public static readonly GraphDirections RIGHT = new GraphDirections('R', 0);
        public static readonly GraphDirections UP = new GraphDirections('U', 1);
        public static readonly GraphDirections LEFT = new GraphDirections('L', 2);
        public static readonly GraphDirections DOWN = new GraphDirections('D', 3);

        private static readonly Dictionary<char, GraphDirections> DirectionsOrder =
            new Dictionary<char, GraphDirections>();

        private static readonly GraphDirections[] ReverseDirections = new GraphDirections[maxDirections];

        static GraphDirections()
        {
            DirectionsOrder.Add(RIGHT.CharCode, RIGHT);
            DirectionsOrder.Add(UP.CharCode, UP);
            DirectionsOrder.Add(LEFT.CharCode, LEFT);
            DirectionsOrder.Add(DOWN.CharCode, DOWN);

            ReverseDirections[RIGHT.DirectionOrder] = RIGHT;
            ReverseDirections[UP.DirectionOrder] = UP;
            ReverseDirections[LEFT.DirectionOrder] = LEFT;
            ReverseDirections[DOWN.DirectionOrder] = DOWN;
        }

        public GraphDirections(char charCode, byte directionOrder)
        {
            CharCode = charCode;
            DirectionOrder = directionOrder;
        }

        public static IEnumerable<GraphDirections> Values
        {
            get
            {
                yield return RIGHT;
                yield return UP;
                yield return LEFT;
                yield return DOWN;
            }
        }

        public char CharCode { get; }
        public byte DirectionOrder { get; }

        public static byte GetDirectionOrder(char charCode)
        {
            return DirectionsOrder[charCode].DirectionOrder;
        }

        public static GraphDirections GetDirection(char charCode)
        {
            return DirectionsOrder[charCode];
        }

        public static char GetDirectionCharCode(byte directionOrder)
        {
            return ReverseDirections[directionOrder].CharCode;
        }

        public static GraphDirections GetReverseDirection(byte directionOrder)
        {
            return ReverseDirections[directionOrder];
        }
    }
}