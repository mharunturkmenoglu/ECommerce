using System.Collections.Generic;
using ECommmerce.Entities.Concrete;

namespace ECommmerce.Service.Abstract
{
    public interface ILangauageService
    {
        void AddLanguage(Language language);
        Language GetLanguage(int id);
        List<Language> GetAllLanguage();
    }
}
