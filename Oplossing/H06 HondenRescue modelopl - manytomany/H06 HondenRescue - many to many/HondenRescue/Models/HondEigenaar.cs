namespace HondenRescue.Models
{
    public class HondEigenaar
    {

        public int HondEigenaarId { get; set; } 

        //Fk's
        public int HondId { get; set; } = default!;
        public int EigenaarId { get; set; } = default!;

        public Hond Hond { get; set; } = default!;

        public Eigenaar Eigenaar { get; set; } = default!;
    }
}
