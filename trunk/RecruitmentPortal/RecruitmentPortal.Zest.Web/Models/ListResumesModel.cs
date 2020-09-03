using System;
using System.ComponentModel.DataAnnotations;

namespace UIOperations.Models
{
    public class ListResumesModel
    {
        [Display(Name = "File Names")]
        public string FileName { get; set; }

        [Display(Name = "Already Processed")]
        public Boolean CheckProcessed { get; set; }
    }
}