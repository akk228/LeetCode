using System;

namespace LeetCode.Topics.Backtracking.Medium.LetterTilePossibilities;

/// <summary>
/// 1079. Letter Tile Possibilities
/// </summary>
public interface ISolution
{
    /// <summary>
    /// You have n  tiles, where each tile has one letter tiles[i] printed on it.
    /// Return the number of possible non-empty sequences of letters you can make using the letters printed on those tiles.
    /// </summary>
    /// <param name="tiles">A string consisting of uppercase English letters.</param>
    /// <returns>The number of possible non-empty sequences of letters you can make using the letters printed on those tiles.</returns>
    int NumTilePossibilities(string tiles);
}
