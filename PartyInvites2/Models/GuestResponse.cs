using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyInvites2.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage ="enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="enter email")]
        [RegularExpression(".+\\@.+\\..+", 
            ErrorMessage ="enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Enter phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage ="specify whether you'll attend")]
        public bool? WillAttend { get; set; }
    }
}