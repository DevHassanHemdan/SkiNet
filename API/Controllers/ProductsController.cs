using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly _IUnitOfWork _IUnitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(_IUnitOfWork IUnitOfWork, IMapper mapper)
        {
            _IUnitOfWork = IUnitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications();
            IReadOnlyList<Product> products = await _IUnitOfWork.ProductRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            Product product = await _IUnitOfWork.ProductRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDTO>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<Product>> GetProductBrands()
        {
            IReadOnlyList<ProductBrand> productBrands = await _IUnitOfWork.ProductBrandRepository.GetAllAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<Product>> GetProductTypes()
        {
            IReadOnlyList<ProductType> productTypes = await _IUnitOfWork.ProductTypeRepository.GetAllAsync();
            return Ok(productTypes);
        }
    }
}
