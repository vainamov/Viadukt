using System.Collections.Generic;

namespace Unfrosted.Network
{
    public class PortController
    {
        public static PortController Instance { get; set; } = new PortController();

        public List<Server> Servers { get; set; } = new List<Server>();

        public int GetPortForTransfer() {
            return 52042;
        }
    }
}
