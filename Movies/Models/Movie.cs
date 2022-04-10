namespace Movies.Models
{
    public class Movie
    {
      
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string Story { get; set;}

        public byte[] Posters { get; set; }
        public byte CategoryId { get; set; }

        public Category Category { get; set; }




    }
}
