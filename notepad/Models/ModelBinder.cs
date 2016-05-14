using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using notepad.Models;

namespace notepad.Models
{
    public class ModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Note))
            {
                var note = new Note();
                note.Name=bindingContext.ValueProvider.GetValue("Name").AttemptedValue;
                note.Text=bindingContext.ValueProvider.GetValue("Text").AttemptedValue;
                return note;
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}