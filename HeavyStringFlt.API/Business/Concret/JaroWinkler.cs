namespace HeavyStringFlt.API.Business.Concret
{
    public static class JaroWinkler
    {
        public static double GetSimilarity(string s1, string s2)
        {
            if (s1 == s2)
                return 1.0;

            int len1 = s1.Length;
            int len2 = s2.Length;

            if (len1 == 0 || len2 == 0)
                return 0.0;

            int matchDistance = Math.Max(len1, len2) / 2 - 1;

            bool[] s1Matches = new bool[len1];
            bool[] s2Matches = new bool[len2];

            int matches = 0;
            for (int i = 0; i < len1; i++)
            {
                int start = Math.Max(0, i - matchDistance);
                int end = Math.Min(i + matchDistance + 1, len2);

                for (int j = start; j < end; j++)
                {
                    if (s2Matches[j]) continue;
                    if (s1[i] != s2[j]) continue;
                    s1Matches[i] = true;
                    s2Matches[j] = true;
                    matches++;
                    break;
                }
            }

            if (matches == 0) return 0.0;

            double transpositions = 0;
            int k = 0;

            for (int i = 0; i < len1; i++)
            {
                if (!s1Matches[i]) continue;
                while (!s2Matches[k]) k++;
                if (s1[i] != s2[k]) transpositions++;
                k++;
            }

            transpositions /= 2.0;

            double jaro = ((double)matches / len1 + (double)matches / len2 + (matches - transpositions) / matches) / 3.0;


            int prefix = 0;
            for (int i = 0; i < Math.Min(4, Math.Min(len1, len2)); i++)
            {
                if (s1[i] == s2[i]) prefix++;
                else break;
            }

            return jaro + prefix * 0.1 * (1 - jaro);
        }
    }

}
