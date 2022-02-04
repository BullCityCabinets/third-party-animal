﻿using _3PA.Core.Models;
using _3PA.Core.Models.Fl;
using _3PA.Core.Models.Nc;
using MediatR;
namespace _3PA.API.Services.Geographic.CountyNameById.Queries
{
	public class CountyNameByIdHandler : IRequestHandler<CountyNameByIdQuery, CountyNameByIdResponse>
  {
    IGeoData geoData { get; set; }
    public async Task<CountyNameByIdResponse> Handle(CountyNameByIdQuery request, CancellationToken cancellationToken)
    {
      switch (request.UsState)
      {
        case UsState.Fl:
          geoData = new FlGeoData();
          request.CountyId = request.CountyId.ToUpper();
          break;

        case UsState.Nc:
          geoData = new NcGeoData();
          break;

        default: throw new NotImplementedException("UsState not yet implemented");
      }
      var canParse = geoData.CountyIds!.TryGetValue(request.CountyId, out var properName);
      if (canParse)
      {
        var response = new CountyNameByIdResponse(request, properName!);
        return await Task.FromResult(response);
      }
      var failResponse = new CountyNameByIdResponse(request, "Invalid Code");
      return await Task.FromResult(failResponse);
    }
  }
}