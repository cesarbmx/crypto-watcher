﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CryptoWatcher.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoWatcher.Persistence.Mappings
{
    public class NotificationMap
    {
        public NotificationMap(EntityTypeBuilder<Notification> entityBuilder)
        {
            // Key
            entityBuilder.HasKey(t => t.NotificationId);

            // Properties
            entityBuilder.Property(t => t.NotificationId)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            entityBuilder.Property(t => t.UserId)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            entityBuilder.Property(t => t.PhoneNumber)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            entityBuilder.Property(t => t.Message)
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            entityBuilder.Property(t => t.WhatsappSentTime)
                .HasColumnType("datetime")
                .IsRequired();

            entityBuilder.Property(t => t.CreatedBy)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            entityBuilder.Property(t => t.CreationTime)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
