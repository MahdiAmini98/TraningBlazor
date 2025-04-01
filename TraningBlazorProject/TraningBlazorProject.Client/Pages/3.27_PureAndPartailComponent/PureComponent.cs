using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace TraningBlazorProject.Client.Pages._3._27_PureAndPartailComponent
{
    public class PureComponent : ComponentBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0,"div");
            builder.OpenElement(1,"h6");
            builder.AddContent(3,"mahdi jooon");
            
            builder.CloseElement();
            builder.CloseElement();

        }
    }
}
