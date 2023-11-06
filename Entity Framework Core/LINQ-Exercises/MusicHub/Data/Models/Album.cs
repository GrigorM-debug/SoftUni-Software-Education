using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MusicHub.Data.Models
{
    [Table("Albums")]
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValiudationConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => this.Songs.Sum(s=>s.Price);

        public int? ProducerId { get; set; }
        
        [ForeignKey(nameof(ProducerId))]
        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
