using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExamination.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OnlineExamination.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Group Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int UserId { get; set; }
        public List<GroupViewModel> GroupList { get; set; }
        public List<StudentCheckBoxListViewModel> studentCheckBoxList { get; set; }
        public int TotalCount { get; set; }
        public bool Selected { get; set; }

        public GroupViewModel(Groups model)
        {
            Id = model.Id;
            Name = model.Name ?? "";
            Description = model.Description ?? "";
            UserId = model.UserId;
        }
        public Groups ConvertGroupsViewModel(GroupViewModel vm)
        {
            return new Groups
            {
                Id = vm.Id,
                Name = vm.Name ?? "",
                Description = vm.Description ?? "",
                UserId = vm.UserId
            };
          }
        }
    }
