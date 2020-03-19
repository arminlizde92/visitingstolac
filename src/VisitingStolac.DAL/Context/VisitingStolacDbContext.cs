using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace VisitingStolac.DAL.Context
{
    /// <summary>
    /// application db context
    /// </summary>
    public class VisitingStolacDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">instnace of <see cref="DbContextOptions{VisitingStolacDbContext}"/></param>
        public VisitingStolacDbContext(DbContextOptions<VisitingStolacDbContext> options) 
            : base(options)
        {

        }

        /// <summary> access to Administrators in db </summary>
        public DbSet<Administrator> Administrators { get; set; }

        /// <summary> access to contacts in db </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary> access to medias in db </summary>
        public DbSet<Media> Medias { get; set; }

        /// <summary> access to media groups in db </summary>
        public DbSet<MediaGroup> MediaGroups { get; set; }

        /// <summary> access to Contributions in db </summary>
        public DbSet<Contribution> Contributions { get; set; }

        /// <summary> access to posts in db </summary>
        public DbSet<Post> Posts { get; set; }

        /// <summary> access to post contacts in db </summary>
        public DbSet<PostContact> PostContacts { get; set; }

        /// <summary> access to text contents in db </summary>
        public DbSet<TextContent> TextContents { get; set; }

        /// <summary> access to content translations contacts in db </summary>
        public DbSet<TextContentTranslation> TextContentTranslations { get; set; }

        /// <summary> access to FAQs in db </summary>
        public DbSet<FAQ> FAQs { get; set; }

        /// <summary> access to subscribers in db </summary>
        public DbSet<Subscriber> Subscribers { get; set; }

        /// <summary>
        /// overriding OnModelCreating
        /// </summary>
        /// <param name="builder">instance of <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            // samo explicitno gdje me zanima  
            // TODO Arrmin
            // Debugger.Launch();

            builder.Entity<Post>().HasOne(ct => ct.Text).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().HasOne(ct => ct.Title).WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FAQ>().HasOne(ct => ct.Question).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<FAQ>().HasOne(ct => ct.Answer).WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TextContent>()
                .HasMany(t => t.Translations)
                .WithOne(ct => ct.TextContent)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
