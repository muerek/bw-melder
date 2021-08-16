using BwMelder.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BwMelder.Model
{
    public class CrewAccessKey
    {
        public int Id { get; set; } = 0;

        public string Key { get; set; } = SecretHelper.GenerateSecret();

        public Guid CrewId { get; set; }
    }
}
