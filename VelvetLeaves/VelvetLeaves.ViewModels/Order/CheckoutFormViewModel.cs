﻿

using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.ViewModels.Order
{
    public class CheckoutFormViewModel
    {
        [Required]
        public IList<CheckoutItemViewModel> Items { get; set; } = null!;

        [Required]
        public AddressFormViewModel Address { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;
    }
}
