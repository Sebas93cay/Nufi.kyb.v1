namespace Nufi.kyb.v1.Models
{
	public class SATRequest
	{
        public string status { get; set; }
        public string message { get; set; }
        public int codigo_postal { get; set; }
        public SATData[] data { get; set; }
	}
}