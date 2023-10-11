using SplitwiseCLI.dtos;
using SplitwiseCLI.Mappers;
using SplitwiseCLI.Models;
using SplitwiseCLI.repositories;
using SplitwiseCLI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCLI.Controllers
{
    public class GroupController
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        public async Task<int> CreateGroup(CreateGroupRequest request)
        {
            Groups groups = GroupMapper.GroupsDtoToGroupModel(request);
            _groupService.CreateGroup(groups);
            return 1;
        }


    }
}
