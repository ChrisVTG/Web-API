namespace Static;

public class DataFormatter
{
    public string GetPrettyPrintedNationalNumber(string rawNationalNumber)
    {
        // 11223345684 => 11.22.33-456.84

        if (string.IsNullOrWhiteSpace(rawNationalNumber))
            return "";

        if (rawNationalNumber.Length != 11)
            return "";

        if (rawNationalNumber.Any(x => !char.IsNumber(x)))
            return "";

        return
            $"{rawNationalNumber.Substring(0, 2)}.{rawNationalNumber.Substring(2, 2)}.{rawNationalNumber.Substring(4, 2)}-{rawNationalNumber.Substring(6, 3)}.{rawNationalNumber.Substring(9, 2)}";
    }
}