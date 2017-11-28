using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Model;
namespace DomainModel
{
    public interface IDataAccessProvider
    {
        void AddImage(Image image);
        void GetImage(long id);
        List<Image> GetImages();
    }
}
