using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IFormTemplateRepository
    {
        Task<List<FormTemplate>> GetFormTemplates();
        Task<long> CreateFormTemplate(FormTemplate formTemplate);
        Task<FormTemplate> UpdateFormTemplate(FormTemplate formTemplate);
        Task<FormTemplate> DeleteFormTemplate(FormTemplate formTemplate);
    }
}
