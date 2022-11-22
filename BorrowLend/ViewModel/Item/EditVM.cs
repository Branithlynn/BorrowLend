using System.ComponentModel.DataAnnotations;

namespace BorrowLend.ViewModel.ItemVM
{
    public class EditVM
    {
        public int ID { get; set; }
        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Name { get; set; }
        [Display(Name = "Borrower: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Borrower { get; set; }
        [Display(Name = "Lender: ")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Lender { get; set; }
    }
}
