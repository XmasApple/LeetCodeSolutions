using System.Linq;

namespace LeetCode.Problems
{
    public class P74SearchA2DMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target) => matrix.SelectMany(t => t).Any(t1 => t1 == target);

        public bool SearchMatrixBinary(int[][] matrix, int target)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var potentialRow = -1;

            for (var i = 0; i < m; i++)
                if (target >= matrix[i][0])
                    potentialRow = i;

            if (potentialRow == -1)
                return false;

            for (var j = 0; j < n; j++)
                if (matrix[potentialRow][j] == target)
                    return true;

            return false; 
        }
    }
}