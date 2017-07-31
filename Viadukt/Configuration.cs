namespace Unfrosted
{
    public class Configuration
    {
        public static Configuration Instance { get; set; }

        public int PoolPort { get; set; } = 42042;
        public int MetaPort { get; set; } = 42043;
        public int ServerArrayStartPort { get; set; } = 42044;
        public int ServerArraySize { get; set; } = 4;
    }
}
