﻿using Microsoft.AspNetCore.Mvc;

namespace Catalog.Products.Features.DeleteProduct;

 
public record DeleteProductResponse(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/product/{id:guid}", async ([FromRoute]Guid Id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteProductCommand(Id));

            var reponse = result.Adapt<DeleteProductResponse>();
            
            return Results.Ok(reponse);
        })         .WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete product");;
    }
}