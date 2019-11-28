using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using AgenceTest.ModelBinders;

namespace AgenceTest.ViewModels
{
    public class PeriodoConsultores : IValidatableObject
    {
        [Display(Name = "Desde")]
        [Required(ErrorMessage = "Por favor seleccione la fecha de inicio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Text)] //Warn! This must be DataType Text for formatting and validation porpouse, see AppointmentsController.NotBeforeToday
        [ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        public DateTime FromDate { get; set; }

        [Display(Name = "Hasta")]
        [Required(ErrorMessage = "Por favor seleccione la fecha final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Text)] //Warn! This must be DataType Text for formatting and validation porpouse, see AppointmentsController.NotBeforeToday
        [ModelBinder(BinderType = typeof(DateTimeModelBinder))]
        public DateTime ToDate { get; set; }

        [Display(Name = "Consultores")]
        [Required(ErrorMessage = "Por favor seleccione los {0}")]
        public List<string> ConsultIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (FromDate > ToDate)
            {
                errors.Add(new ValidationResult("La fecha de inicio no puede ser posterior a la fecha final.", new string[] { "FromDate" }));
            }

            return errors;
        }
    }
}
