using NTwain.Data;

namespace TWAIN.Models
{
    public class TWCapabilities
    {
        public TWFix32 DPIX { get; set; }
        public TWFix32 DPIY { get; set; }
        public SupportedSize PageSize { get; set; }
        public bool UseAutoFeed { get; set; }
        public bool UseDuplex { get; set; }
    }
}
