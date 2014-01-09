using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midwhay.Dsl
{
    public class Sentence
    {
        public ActionType Action { get; set; }
        public IEnumerable<RoleObject> Roles { get; set; }

        public Sentence(ActionType action, IEnumerable<RoleObject> roles)
        {
            Action = action;
            Roles = roles;
        }
    }
}
