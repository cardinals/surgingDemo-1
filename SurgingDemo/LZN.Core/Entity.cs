using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroService.Core
{
    [Serializable]
    public abstract class Entity : Entity<int>, IEntity
    {
        string IEntity<string>.Id { get; set; }
    }

    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {

        protected Entity()
        {
            IsDelete = 1;
            CreateDate = DateTime.Now;
        }
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        [Key]
        [StringLength(36)]
        public virtual TPrimaryKey Id { get; set; }

        public virtual int IsDelete { set; get; }

        public virtual DateTime CreateDate { set; get; }

        //[ConcurrencyCheck()]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column(TypeName = "timestamp")]
        //public virtual DateTime Timestamp { set; get; }
        public virtual bool IsTransient()
        {
            if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
            {
                return true;
            }

            //Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if (typeof(TPrimaryKey) == typeof(int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof(TPrimaryKey) == typeof(long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }
    }
    }
