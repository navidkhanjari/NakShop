using Common.Application;
using Common.Application._Utilities;
using Common.Application.FileUtil.Interfaces;
using Shop.Domain.SiteEntities.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Shop.Domain.SiteEntities;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly ILocalFileService _fileService;
        private readonly ISliderRepository _repository;

        public CreateSliderCommandHandler(ILocalFileService fileService, ISliderRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Title, request.Link, imageName);

            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
