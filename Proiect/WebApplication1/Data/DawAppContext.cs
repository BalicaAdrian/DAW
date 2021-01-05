//using DAWProject.Models;
//using DAWProject.Models.Relations.Many_to_Many;
//using DAWProject.Models.Relations.One_to_Many;
//using DAWProject.Models.Relations.One_to_One;

using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace DAWProject.Data
{
    public class DawAppContext : DbContext
    {
        public DawAppContext(DbContextOptions<DawAppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ModelRelation> ModelsRelations { get; set; }

     
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Subscription>()
                .HasMany(x => x.Users)
                .WithOne(y => y.Subscription);
  

            builder.Entity<User>()
                .HasOne(x => x.UserDetails)
                .WithOne(y => y.User)
                .HasForeignKey<UserDetails>
                (z => z.UserId);

            /*builder.Entity<ModelRelation>()
                .HasKey(mr =>
                new { mr.ChannelId, mr.SubscriptionId });

            builder.Entity<ModelRelation>()
                .HasOne<Channel>(x => x.Channel)
                .WithMany(y => y.ModelRelations)
                .HasForeignKey(z => z.ChannelId);

            builder.Entity<ModelRelation>()
                .HasOne<Subscription>(x => x.Subscription)
                .WithMany(y => y.ModelRelations)
                .HasForeignKey(z => z.SubscriptionId);
            */

            builder.Entity<Subscription>()
                .HasMany(x => x.ModelRelations)
                .WithOne(x => x.Subscription)
                .HasForeignKey(x => x.SubscriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Channel>()
                .HasMany(x => x.ModelRelations)
                .WithOne(x => x.Channel)
                .HasForeignKey(x => x.ChannelId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(builder);

        }
       
    }
}