namespace Application.Features.Mediator.Queries.SocialMediaQueries;

public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
{
    public int Id { get; set; }

    public GetSocialMediaByIdQuery(int ıd)
    {
        Id = ıd;
    }
}
