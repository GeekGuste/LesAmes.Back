using LesAmes.Application.Services.Souls.Hobbies;
using LesAmes.Application.Services.Souls.HobbyCategories;
using LesAmes.Application.Services.Souls.ImpactFamilies;
using LesAmes.Domain.Authentication;
using LesAmes.Dto.Souls.Hobbies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LesAmes.WebApi.Modules.Souls;

public static class HobbiesEndpoints
{
    public static RouteGroupBuilder RegisterHobbiesEndpoints(this RouteGroupBuilder app)
    {
        app.MapPost("/categories",
        [Authorize(Roles = $"{Roles.Admin},{Roles.SuperAdmin}")]
        async (CreateHobbyCategoryService createHobbyCategoryService, HobbyCategoryInput input) => createHobbyCategoryService.CreateHobbyCategoryAsync(input))
            .WithDisplayName("CreateHobbyCategory");

        app.MapPut("/categories/{id}",
        [Authorize(Roles = $"{Roles.Admin},{Roles.SuperAdmin}")]
        async ([FromRoute] string id, [FromBody] HobbyCategoryInput input, [FromServices] UpdateHobbyCategoryService updateHobbyCategoryService) => updateHobbyCategoryService.UpdateHobbyCategoryAsync(id, input))
            .WithDisplayName("UpdateHobbyCategory");

        app.MapPut("/categories/{id}/add-hobby",
        [Authorize(Roles = $"{Roles.Admin},{Roles.SuperAdmin}")]
        async ([FromRoute] string id, [FromBody] HobbyInput input, [FromServices] UpdateHobbyCategoryService updateHobbyCategoryService) => updateHobbyCategoryService.AddHobbyAsync(id, input))
            .WithDisplayName("AddHobby");

        app.MapDelete("/{id}",
        [Authorize(Roles = $"{Roles.Admin},{Roles.SuperAdmin}")]
        async ([FromRoute] string id, [FromBody] HobbyInput input, [FromServices] UpdateHobbyCategoryService updateHobbyCategoryService) => updateHobbyCategoryService.AddHobbyAsync(id, input))
            .WithDisplayName("AddHobby");

        app.MapGet("",
        [Authorize()]
        async (GetImpactFamiliesService getImpactFamiliesService) => getImpactFamiliesService.GetAllImpactFamiliesAsync())
            .WithDisplayName("GetImpactFamily");

        return app;
    }
}
