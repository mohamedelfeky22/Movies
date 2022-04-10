namespace Movies.DataTransferObjects
{
    public class MovieBaseDto
    {
        [MaxLength(200)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Story { get; set; }
        public byte CategoryId { get; set; }
    }
}
