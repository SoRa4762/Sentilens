﻿using api.Application.Commands;
using api.Application.Responses;
using api.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers
{
    public class ArticleMappingProfile : Profile // Inherits AutoMapper's Profile
    {
        // This class is responsible for mapping between Article and ArticleResponse
        // You can use AutoMapper or any other mapping library to implement this
        // For example, using AutoMapper:
        // CreateMap<Article, ArticleResponse>();
        // CreateMap<CreateArticleCommand, Article>();
        // CreateMap<UpdateArticleCommand, Article>();

        public ArticleMappingProfile()
        {
            // Rule 1: Map between Article (Entity) and ArticleResponse (DTO)
            CreateMap<Article, ArticleResponse>().ReverseMap();
            // Rule 2: Map between Article (Entity) and CreateMovieCommand (Command Objects)
            CreateMap<Article, CreateArticleCommand>().ReverseMap();
        }
    }
}
