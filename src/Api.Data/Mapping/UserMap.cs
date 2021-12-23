using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
  public class UserMap : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("User"); //Informa o nome da tabela

        builder.HasKey( u=> u.Id);  //Informa o ID

        builder.HasIndex ( u=> u.Email)
               .IsUnique();  //Informa que é campo único

        builder.Property ( u=> u.Email)
               .HasMaxLength(100);  //Informa o tamanho máximo
        
        builder.Property( u=> u.Name)
               .IsRequired()  //Informa que é necessário
               .HasMaxLength(60); 

    }
  }
}