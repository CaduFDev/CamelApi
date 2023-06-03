using CamelDev.CamelApi.Api.DTO;
using CamelDev.CamelApi.Api.HATEOAS.ResourceBuilders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;

namespace CamelDev.CamelApi.Api.HATEOAS.ResourceBuilders.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilder
    {
        public void BuildResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;
            if (dto == null)
            {
                throw new ArgumentNullException($"Era esperado um AlunoDTO, porém foi enviado um {resource.GetType().Name}");
            }
            
            UrlHelper urlHelper = new UrlHelper(request);

            string alunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id });
            dto.Links.Add(new RestLink
            {
                Rel = "self",
                Href = alunoDTORoute,

            });
            dto.Links.Add(new RestLink
            {
                Rel="edit",
                Href=alunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                Href=alunoDTORoute
            });
        }
    }
}