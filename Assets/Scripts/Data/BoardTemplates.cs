//-----------------------------------------------------------------------
// <copyright file="BoardTemplates.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

/// <summary>
/// Templates for how the bricks are displayed
/// </summary>
public static class BoardTemplates 
{
    /// <summary>
    /// Board Template One
    /// </summary>
    public static readonly bool[] BoardOne = new bool[] 
    {
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
    };

    /// <summary>
    /// Board Template Two
    /// </summary>
    public static readonly bool[] BoardTwo = new bool[] 
    {
        false, false, false, true, true, true, true, true, true, true, false, false, false,
        false, false, true, true, true, true, true, true, true, true, true, false, false,
        false, true, true, true, true, true, true, true, true, true, true, true, false,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, false, true, true, true, true, true, true,
        true, true, true, true, true, false, false, false, true, true, true, true, true,
        true, true, true, true, false, false, false, false, false, true, true, true, true,
        true, true, true, false, false, false, false, true, true, true, true, true, true,
        true, true, true, false, false, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true, true, true,
        false, true, true, true, true, true, true, true, true, true, true, true, false,
        false, false, true, true, true, true, true, true, true, true, true, false, false,
        false, false, false, true, true, true, true, true, true, true, false, false, false,
    };

    /// <summary>
    /// Board Template Three
    /// </summary>
    public static readonly bool[] BoardThree = new bool[] 
    {
        true, true, false, false, false, false, false, false, false, false, false, true, true,
        true, true, true, false, false, false, false, false, false, false, true, true, true,
        false, true, true, false, false, false, false, false, false, true, true, true, false,
        false, false, true, true, false, false, false, false, true, true, true, false, false,
        false, false, true, true, true, false, false, true, true, true, true, false, false,
        false, false, true, true, true, true, true, true, true, true, false, false, false,
        false, false, false, true, true, true, true, true, true, false, false, false, false,
        false, false, false, true, true, true, true, true, true, false, false, false, false,
        false, false, true, true, true, true, false, false, true, true, false, false, false,
        false, true, true, true, true, false, false, false, true, true, true, false, false,
        true, true, true, true, false, false, false, false, false, true, true, true, true,
        true, true, true, false, false, false, false, false, false, false, true, true, true,
        true, true, false, false, false, false, false, false, false, false, false, true, true,
    };

    /// <summary>
    /// Array of template boards
    /// </summary>
    public static readonly bool[][] Boards = new bool[][] { BoardOne, BoardTwo, BoardThree };
}
