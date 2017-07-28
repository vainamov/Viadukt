namespace Unfrosted
{
    public class Configuration
    {
        public static Configuration Instance { get; set; }

        public int PoolPort { get; set; } = 42042;
        public int MetaPort { get; set; } = 42043;
    }
}
