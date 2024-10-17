namespace Jasons_Personal_Blog.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        //navigation Property
        public ICollection<BlogPost> BlogPosts { get; set; }

    }
}
