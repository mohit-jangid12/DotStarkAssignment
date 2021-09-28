using System;
using System.ComponentModel.DataAnnotations;

namespace DotStarkTest.Data.Repository
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Delete { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}