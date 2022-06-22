using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Tahaluf.PlusExam.Core.DTO;
using System.Collections.Generic;

namespace Tahaluf.PlusExam.Core.Data
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required, NotNull, MinLength(5), MaxLength(12)]
        public string Username { get; set; }

        [Required, NotNull, MinLength(8), MaxLength(15)]
        public string Password { get; set; }

        [Required, NotNull ,MaxLength(320)]
        public string Email { get; set; }

        [Required, NotNull, MinLength(6), MaxLength(60)]
        public string Fullname { get; set; }

        [MinLength(3), MaxLength(6)]
        public string Gender { get; set; }

        public DateTime Bod { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MinLength(2), MaxLength(5)]
        public string Status { get; set; }

        [MinLength(5), MaxLength(7)]
        public string Rolename { get; set; }

        [MaxLength(255)]
        public string ProfilePicture { get; set; }


        public ICollection<Result> Results { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<CreditCard> Creditcards { get; set; }
        public ICollection<PhoneNumber> Phonenumbers { get; set; }
        public ICollection<Score> Scores { get; set; }
        public ICollection<FillResult> FillResults { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }
    }
}
