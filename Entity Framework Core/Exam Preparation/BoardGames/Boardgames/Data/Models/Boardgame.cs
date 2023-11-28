﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Common;
using Boardgames.Data.Models.Enums;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        public Boardgame()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.BoardgameMaxNameLenght)]
        public string Name { get; set; } = null!;

        [Required]
        public double Rating { get; set; }

        [Required]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required] 
        public string Mechanics { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CreatorId))]
        public int CreatorId { get; set; }

        [Required] 
        public virtual Creator Creator { get; set; } = null!;

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
