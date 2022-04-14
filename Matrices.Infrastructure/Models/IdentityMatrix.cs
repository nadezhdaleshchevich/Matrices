namespace Matrices.Infrastructure.Models
{
    public class IdentityMatrix : DiagonalMatrix
    {
        public IdentityMatrix(int n) : base(n)
        {
            for (int i = 1; i <= n; i++)
            {
                base[i, i] = 1;
            }
        }

        public override double this[int m, int n]
        {
            set { }
        }
    }
}
