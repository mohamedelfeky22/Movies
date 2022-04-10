
namespace Movies.Models
{
    public class Category
    {
        // to make identity because type of (Id) is byt not Int 
        //int by default is identity in entity framework
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 

        public byte Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
