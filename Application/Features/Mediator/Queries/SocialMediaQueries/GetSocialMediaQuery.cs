namespace Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}
