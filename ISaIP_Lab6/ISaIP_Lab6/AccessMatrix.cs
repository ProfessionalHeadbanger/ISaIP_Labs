using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISaIP_Lab6
{
    internal class AccessMatrix
    {
        private Dictionary<(string, string), AccessRights> matrix = new();

        public void SetAccess(User user, AccessObject accessObject, AccessRights rights)
        {
            matrix[(user.Id, accessObject.Name)] = rights;
        }

        public bool HasAccess(User user, AccessObject accessObject, AccessRights requiredRights)
        {
            if (user.Id == "admin")
            {
                return true;
            }
            return matrix.TryGetValue((user.Id, accessObject.Name), out AccessRights rights) && (rights & requiredRights) == requiredRights;
        }

        public AccessRights GetRights(User user, AccessObject accessObject)
        {
            return matrix.TryGetValue((user.Id, accessObject.Name), out AccessRights rights) ? rights : AccessRights.None;
        }
    }
}
