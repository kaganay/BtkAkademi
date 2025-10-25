using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = """Ad gereklidir.""")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = """Soyad gereklidir.""")]
        public string? LastName { get; set; }

        [Required, EmailAddress(ErrorMessage = """Geçerli bir e-posta adresi giriniz.""")]
        public string? Email { get; set; }

        [Range(18, 80, ErrorMessage = """Yaş 18 ile 80 arasında olmalıdır.""")]
        public int Age { get; set; }

        [Required(ErrorMessage = """Lütfen bir kurs seçiniz.""")]
        public string? Course { get; set; }

        public DateTime ApplyAt { get; set; } = DateTime.Now;
    }
}
