namespace Enums;

[Flags]
public enum ColorEnum
{
    None = 0,
    Red = 1,
    // 2 because 1 * 2 = 2
    Green = 2,
    // 4 because 2 * 2 = 4
    Yellow = 4,
    // 8 because 4 * 2 = 8
    Black = 8,
}