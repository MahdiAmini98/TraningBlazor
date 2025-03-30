using Microsoft.AspNetCore.Components.Forms;
namespace TraningBlazorProject.Client.Pages._5._49_Form.CustomCssValidation
{
  
    //کلاس های بوت استرپ است
    //"is-valid":"is-invalid"
   
    public class BootstrapFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();
            return isValid ? "is-valid" : "is-invalid";
        }
    }
}
