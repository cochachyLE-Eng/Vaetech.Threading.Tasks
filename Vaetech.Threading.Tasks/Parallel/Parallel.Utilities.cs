namespace Vaetech.Threading.Tasks
{
    public partial class Parallel
    {
        public static int Count(int count, ref int lots)
        {
            bool n = count < lots;
            int m = System.Math.Abs(count - lots), cc = n ? 1 : (count / lots);
            lots = lots - (n ? m : 0);
            return cc;
        }
    }
}
