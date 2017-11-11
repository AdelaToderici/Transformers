namespace Transformers.Services {
   public class Castles {
        public static int Solution(int[] A) {
            var countExtremes = 0;
            var lastDifferentNumber = A[0];


            for (int i = 1; i < A.Length - 1; i++)
            {
                if (A[i + 1] == A[i])
                    continue;

                if (A[i] > A[i + 1])
                {
                    if (A[i] > lastDifferentNumber)
                    {
                        countExtremes++;
                    }
                }

                if (A[i] < A[i + 1])
                {
                    if (A[i] < lastDifferentNumber)
                    {
                        countExtremes++;
                    }
                }

                lastDifferentNumber = A[i];
            }

            return countExtremes;
        }
    }
}
