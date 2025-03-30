namespace TraningBlazorProject.Client.Pages._5._57_RecursiveMenu
{
    public class MenuItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public List<MenuItem> Children { get; set; } = new();
    }
}
