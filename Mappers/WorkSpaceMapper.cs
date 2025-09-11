using WorkSpace.DTOs.WorkSpaceDto;
using WorkSpace.Model;

namespace WorkSpace.Mappers
{
    public static class WorkSpaceMapper
    {
        public static WorkSpaces ToWorkSpaceFromCreateDTO(this WorkSpaceCreateDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            return new WorkSpaces
            {
                Title = dto.Title,
                Description = dto.Description,
                HostId = dto.HostId,
                AddressId = dto.AddressId,
                WorkspaceTypeId = dto.WorkspaceTypeId,
                PricePerHour = dto.PricePerHour,
                PricePerDay = dto.PricePerDay,
                PricePerMonth = dto.PricePerMonth,
                Capacity = dto.Capacity,
                Area = dto.Area,
                CreatedAt = DateTime.UtcNow,
                WorkspaceImages = dto.WorkspaceImages.Select(wdto => new WorkspaceImage
                {
                    ImageUrl = wdto.ImageUrl,
                    UploadedAt = DateTime.UtcNow, 
                }).ToList(),
                WorkspaceAmenities = dto.WorkspaceAmenities ?? new List<WorkspaceAmenity>()
            };
        }

        public static WorkSpaces ToWorkSpaceFromUpdateDTO(this WorkSpaceUpdateDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            return new WorkSpaces
            {
                Title = dto.Title,
                Description = dto.Description,
                HostId = dto.HostId,
                AddressId = dto.AddressId,
                WorkspaceTypeId = dto.WorkspaceTypeId,
                PricePerHour = dto.PricePerHour,
                PricePerDay = dto.PricePerDay,
                PricePerMonth = dto.PricePerMonth,
                Capacity = dto.Capacity,
                Area = dto.Area,
                CreatedAt = DateTime.UtcNow,
                WorkspaceImages = dto.WorkspaceImages.Select(wdto => new WorkspaceImage
                {
                    ImageUrl = wdto.ImageUrl,
                    UploadedAt = DateTime.UtcNow,
                }).ToList(),
                WorkspaceAmenities = dto.WorkspaceAmenities ?? new List<WorkspaceAmenity>()
            };
        }
    }
}
