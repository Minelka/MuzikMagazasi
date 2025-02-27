namespace MuzikMagazasi.Models
{
    public class BaseViewModel
    {
        private static int _rowNumber;

        protected BaseViewModel(int rowNumber)
        {
            _rowNumber = rowNumber;
        }

        public int RowNumber
        {
            get
            {
                _rowNumber = _rowNumber + 1;
                return _rowNumber;
            }
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
