﻿using BooksStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Configurate
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(b => b.Title)
                .HasMaxLength(Book.TitleMaxVAlue)
                .IsRequired();
            builder.Property(b => b.Description).IsRequired();
            builder.Property(b => b.Price).IsRequired();
        }
    }
}
