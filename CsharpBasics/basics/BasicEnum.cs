using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Xunit.Abstractions;

namespace CsharpBasics.basics
{
    //enum is used to represet a type that consists of set of constants
    //enums are value types and are created on stack
    // If we want to restrict the method parameters to particular values we can use enum.
    //For eg: In the below example, we can only send the colors in the 'Color' enumeration as parameters.
    public enum Color
    {
        Red = 0xFF0000,
        Blue = 0x0000FF,
        Green = 0x00FF00,
        Black = 0x000000
    }

    public class BasicEnum
    {
        public static string TestColor(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return $"{Color.Red} color";
                case Color.Blue:
                    return $"{Color.Blue} color";
                case Color.Green:
                    return $"{Color.Green} color";
                default:
                    return null;
            }
        }
    }

}
