﻿using System;
using ProniaNew.Models;
using ProniaNew.ViewModels.ProductVMs;

namespace ProniaNew.Services.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetAll(bool takeAll);
    public Task<Product> GetById(int? id, bool takeAll = false);
    Task Create(CreateProductVM productVM);
    Task Update(int? id, UpdateProductVM productVM);
    Task Delete(int? id);
    Task SoftDelete(int? id);
    IQueryable<Product> GetTable { get; }
    Task DeleteImage(int? id);
}

