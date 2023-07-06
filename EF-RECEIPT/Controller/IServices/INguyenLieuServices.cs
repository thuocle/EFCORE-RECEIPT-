using EF_RECEIPT.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Controller.IServices
{
    public interface INguyenLieuServices 
    {
        void addIngredient(NguyenLieu nl);
    }
}
