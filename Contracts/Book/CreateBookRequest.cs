﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Book
{
  public class CreateBookRequest
  {
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public string CoverType { get; set; } = null!;
    [Required]
    public int NumberOfPages { get; set; }
    [Required]
    public DateTime FirstPublished { get; set; }

    public IFormFile? Image { get; set; }
    [Required]
    public int[] GenreIds { get; set; }
    [Required]
    public int[] AuthorIds { get; set; }
  }
}
