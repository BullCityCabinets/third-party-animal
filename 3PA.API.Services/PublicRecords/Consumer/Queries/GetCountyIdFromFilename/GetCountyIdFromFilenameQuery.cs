using _3PA.Core.Models;
using MediatR;
namespace _3PA.API.Services.PublicRecords.Consumer.Queries.GetCountyIdFromFileName;

public class GetCountyIdFromFileNameQuery : IRequest<GetCountyIdFromFilenameResponse>
{
  public GetCountyIdFromFileNameQuery(UsState usState, Category category, string fileName)
  {
    UsState = usState;
    Category = category;
    FileName = fileName;
  }
  public UsState UsState { get; set; }
  public Category Category { get; set; }
  public string FileName { get; set; }
}
