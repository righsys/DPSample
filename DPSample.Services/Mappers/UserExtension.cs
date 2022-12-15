using DPSample.Domain.DbViews;
using DPSample.Domain.Entities;
using DPSample.Services.DTOs;

namespace DPSample.Services.Mappers
{
    public static class UserExtension
    {
        public static UserSummaryDto ConvertToUserSummaryDto(this UserSummaryDbView user)
        {
            return new UserSummaryDto()
            {
                UserId = user.UserId,
                Username = user.Username,
                FullName = (string.IsNullOrEmpty(user.LastName)) ? user.FirstName : $"{user.FirstName} {user.LastName}",
                RoleName = user.RoleEnName,
            };
        }
        public static List<UserSummaryDto> ConvertToUserSummaryDtos(this IQueryable<UserSummaryDbView> users) 
        {
            var list = new List<UserSummaryDto>();
            foreach (var user in users)
            {
                list.Add(ConvertToUserSummaryDto(user));
            }
            return list;
        }

        public static UserDetailDto ConvertToUserDetailDto(this UserDetailDbView user) 
        {
            return new UserDetailDto() 
            {
                Email=user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName,
                IsActive=user.IsActive,
                IsLoggedIn=user.IsLoggedIn,
                NationalCode = user.NationalCode,
                UserId = user.UserId,
                Username = user.Username
            };
        }

        public static UserDetailDto ConvertToUserDetailDto(this User user) 
        {
            return new UserDetailDto() 
            {
                  Email = user.Email,
                  FirstName = user.FirstName,
                  LastName = user.LastName, 
                  IsActive = user.IsActive,
                  IsLoggedIn = user.IsLoggedIn,
                  NationalCode = user.NationalCode,
                  UserId = user.UserId,
                  Username=user.Username,
            };
        }
        public static List<UserDetailDto> ConvertToUserDetailDto(this IQueryable<User> users) 
        {
            var list = new List<UserDetailDto>();
            foreach (var user in users)
            {
                list.Add(ConvertToUserDetailDto(user));
            }
            return list;
        }
    }
}