using EF_RECEIPT.Controller.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Controller.IServices
{
    public interface IChiTietPhieuServices
    {
        void addListReceiptDetail(int phieuID);
    }
}
