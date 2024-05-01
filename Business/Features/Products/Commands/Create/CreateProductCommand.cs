using AutoMapper;
using Business.Abstracts;
using Core.Application.Pipelines.Logging;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Business.Features.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<CreateProductResponse>, ILoggableRequest
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
        {
            private readonly IProductRepository _productRepository;
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            public CreateProductCommandHandler(IProductRepository productRepository, ICategoryService categoryService, IMapper mapper)
            {
                _productRepository = productRepository;
                _categoryService = categoryService;
                _mapper = mapper;
                
            }
            public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                IValidator<CreateProductCommand> validator = new CreateProductCommandValidator();

                ValidationResult result = validator.Validate(request);

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors.Select(i=>i.ErrorMessage).ToList());
                }

                if (request.UnitPrice < 0)
                    throw new BusinessException("Ürün fiyatı 0'dan küçük olamaz.");
                Product? productWithSameName = await _productRepository.GetAsync(p => p.Name == request.Name);
                if (productWithSameName is not null)
                    throw new System.Exception("Aynı isimde 2. ürün eklenemez.");

                //Kategori verilerine ulaş.
                /*
                Category? category = _categoryService.GetById(request.CategoryId);
                if (category is null)
                    throw new BusinessException("Böyle bir kategori bulunamadı.");
                */
                Product product = _mapper.Map<Product>(request);

                await _productRepository.AddAsync(product);

                CreateProductResponse response = _mapper.Map<CreateProductResponse>(product);
                return response;
            }
        }
    }
}
