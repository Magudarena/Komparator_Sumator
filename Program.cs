using System;

class AikenComparatorAndAdder
{
    static readonly string[] Mapping = {
        "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001"
    };

    static int Decode(string aiken)
    {
        for (int i = 0; i < Mapping.Length; i++)
        {
            if (Mapping[i] == aiken)
                return i;
        }
        return -1;
    }


    static string Encode(int decimalValue)
    {
        return Mapping[decimalValue];
    }



    static string Compare(string aikenA, string aikenB)
    {
        int decimalA = Decode(aikenA);
        int decimalB = Decode(aikenB);

        if (decimalA == -1 || decimalB == -1)
            return "To nie Aiken";

        if (decimalA < decimalB)
            return "100   A <  B"; 
        else if (decimalA == decimalB)
            return "010   A == B"; 
        else
            return "001   A > B"; 


    }

    static string Sumator(string aikenA, string aikenB)
    {
        int decimalA = Decode(aikenA);
        int decimalB = Decode(aikenB);

        int sum = decimalA + decimalB;

        if (sum >= 10)
            return $"overflow (suma: {sum})";

        string sumAiken = Encode(sum);
        return $"kod Aikena: {sumAiken} (suma: {sum})";
    }


    static void Main(string[] args)
    {
        Console.WriteLine("A Aiken\tA Cyfra\tB Aiken\tB Cyfra\tKomparator\tSumator");

        foreach (var aikenA in Mapping)
        {
            foreach (var aikenB in Mapping)
            {
                int decimalA = Decode(aikenA);
                int decimalB = Decode(aikenB);

                string result = Compare(aikenA, aikenB);
                string sumResult = Sumator(aikenA, aikenB);

                Console.WriteLine($"{aikenA}\t{decimalA}\t{aikenB}\t{decimalB}\t{result}\t{sumResult}");
            }
        }
    }
}
