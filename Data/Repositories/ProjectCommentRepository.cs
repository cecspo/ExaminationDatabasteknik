using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class ProjectCommentRepository (DataContext context) : BaseRepository<ProjectCommentEntity>(context), IProjectCommentRepository
{

}
