using SplitwiseCLI.dtos;
using SplitwiseCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Mappers
{
    public static class GroupMapper
    {

        public static Groups GroupsDtoToGroupModel(CreateGroupRequest request)
        {
            Groups groups = new Groups();
            groups.Name = request.Name;
            return groups;

        }
    }
}
