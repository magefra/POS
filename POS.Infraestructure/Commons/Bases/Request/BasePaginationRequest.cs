namespace POS.Infraestructure.Commons.Bases.Request
{
    public class BasePaginationRequest
    {
        //Número de pagina.
        public int NumPage { get; set; }

        //Registro por pagina
        public int NumRecordsPage { get; set; } = 10;

        //Número de registros por pagína
        private readonly int NumMaxRecordsPage = 50;

        public string Order { get; set; } = "asc";

        public string Sort { get; set; } = null;

        public int Records
        {
            get => NumRecordsPage;
            set => NumRecordsPage = value > NumMaxRecordsPage ? NumRecordsPage : value;
        }
    }
}
