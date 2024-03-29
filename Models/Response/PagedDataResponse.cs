namespace ZooManagement.Models.Response;

public class PagedDataResponse
{
    public required List<AnimalResponse> Result {get; set;}

    public required int CurrentPage {get; set; }

    public required int ItemsPerPage{get; set;}
    
    public required int TotalPages {get; set;}

}
