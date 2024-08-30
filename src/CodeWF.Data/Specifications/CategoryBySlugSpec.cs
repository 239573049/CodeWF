﻿using Ardalis.Specification;
using CodeWF.Data.Entities;

namespace CodeWF.Data.Specifications;

public sealed class CategoryBySlugSpec : SingleResultSpecification<Category>
{
    public CategoryBySlugSpec(string slug)
    {
        Query.Where(category => category.Slug == slug);
    }
}