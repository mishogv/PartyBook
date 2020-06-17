namespace PartyBook.Data.Common
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BaseModel<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }
    }
}
