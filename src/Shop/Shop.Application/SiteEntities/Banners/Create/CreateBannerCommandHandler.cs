using Common.Application;
using Common.Application._Utilities;
using Common.Application.FileUtil.Interfaces;
using Shop.Domain.SiteEntities.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Shop.Domain.SiteEntities;

namespace Shop.Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
    {
        private readonly IBannerRepository _repository;
        private readonly ILocalFileService _fileService;
        public CreateBannerCommandHandler(IBannerRepository repository, ILocalFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            var banner = new Banner(request.Link, imageName, request.Position);

            _repository.Add(banner);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
