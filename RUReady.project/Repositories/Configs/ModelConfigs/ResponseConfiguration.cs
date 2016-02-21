using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Configs.ModelConfigs
{ 
    public class ResponseConfiguration : DomainEntityTypeConfiguration<Response>
    {
        public ResponseConfiguration()
        {
            Property(response => response.Answer).IsRequired();
            Property(response => response.Content).IsRequired();
        }
    }
}
