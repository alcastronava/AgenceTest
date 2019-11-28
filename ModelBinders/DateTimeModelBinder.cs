using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgenceTest.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = "01/"+valueProviderResult.FirstValue;

                //  valueAsString will have a string value of your date, e.g. '31/12/2017'
                //var dateTime = DateTime.ParseExact(valueAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime;
                if (DateTime.TryParseExact(valueAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    bindingContext.Result = ModelBindingResult.Success(dateTime);
                }

                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
