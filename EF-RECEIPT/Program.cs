using EF_RECEIPT.Controller.IServices;
using EF_RECEIPT.Controller.Services;
using EF_RECEIPT.Model.Entities;
using EF_RECEIPT.Model.Helper;

void Main() 
{
   INguyenLieuServices nguyenLieuServices = new NguyenLieuServices();
   /* nguyenLieuServices.addIngredient(new NguyenLieu(inputType.Them));*/
   IPhieuThuServices phieuThuServices = new PhieuThuServices();    
    IChiTietPhieuServices chiTietPhieuServices = new ChiTietPhieuServices();
    /*phieuThuServices.addReceipt(new PhieuThu(inputType.Them));*/
    /*int phieuID = InputHelper.InputINT(Res.PhieuThuID, Res.Err);
    chiTietPhieuServices.addListReceiptDetail(phieuID);*/
    phieuThuServices.getReceiptsByDate();
}
Main();