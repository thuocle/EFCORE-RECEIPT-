using EF_RECEIPT.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_RECEIPT.Model.Helper
{
    public enum inputType
    {
        Them
    }
    public class InputHelper
    {
      #region CheckBeforeGetInput
        public static int InputINT(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            int ret;
            do
            {
                Console.WriteLine(msg);
                check = int.TryParse(Console.ReadLine(), out ret);
                check = check && ret >= min && ret <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string InputSTR(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length >= min && ret.Length <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static DateTime InputDT(string msg, string err, DateTime min, DateTime max)
        {
            bool check;
            DateTime ret;
            do
            {
                Console.WriteLine(msg);
                check = DateTime.TryParse(Console.ReadLine(), out ret);
                check = check && ret >= min && ret <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static double InputDB(string msg, string err, int min = 0)
        {
            bool check;
            double ret;
            do
            {
                Console.WriteLine(msg);
                check = double.TryParse(Console.ReadLine(), out ret);
                check = check && ret >= min;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        #endregion
        #region CheckBeforeCRUD
        public static bool CheckLoaiNguyenLieuRule(LoaiNguyenLieu loai)
        {
            return loai.TenLoai.Length <= 20 && loai.MoTa.Length <= int.MaxValue;
        }
        public static bool CheckNguyenLieuRule(NguyenLieu nl)
        {
            return nl.TenNguyenLieu.Length <= 20 && nl.DonViTinh.Length <= 10;
        } 
        #endregion
    }


}
