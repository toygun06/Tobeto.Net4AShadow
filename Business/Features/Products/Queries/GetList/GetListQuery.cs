using AutoMapper;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Products.Queries.GetList
{
    public class GetListQuery : IRequest<List<GetAllProductResponse>>
    {
        public int Page {  get; set; }
        public int PageSize { get; set; }

        public class GetListQueryHandler : IRequestHandler<GetListQuery, List<GetAllProductResponse>>
        {
            private readonly IProductRepository _productRepository;
            private IMapper _mapper;

            public async Task<List<GetAllProductResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
            {
                List<Product> products = await _productRepository.GetListAsync();

                List<GetAllProductResponse> response = _mapper.Map<List<GetAllProductResponse>>(products);

                return response;
            }
        }
    }
}
