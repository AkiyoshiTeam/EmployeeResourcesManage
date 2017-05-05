using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections;
using System.Windows;
using System.Data;
using System.Linq.Dynamic;
using System.Data.SqlClient;
using System.Data.Common;

namespace DAO
{
    public class NhanVienDAO
    {
        public static DataTable GetNhanVien(TreesSearchModel TreeSearchViewModel)
        {
            DataTable tb = new DataTable();
            string query = "Select nv.MaNV, nv.HoTen";
            bool exists = true;
            int i = 0;
            for (int j = 0; j < TreeSearchViewModel.SearchObjects[i].SearchElements.Count; j++)
            {
                for (int n = 0; n < TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails.Count; n++)
                {
                    if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].IsCheckedDetail == true)
                    {
                        if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch.Trim() != "nv.HoTen" && TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch.Trim() != "nv.MaNV" && TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch.Trim() != "tt.MaNV")
                            query += ", " + TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch;
                    }
                }
            }
            query += @" From NhanVien nv join ThongTinChiTietNhanVien tt on nv.MaNV = tt.MaNV 
                        join QuocGia qg on tt.QuocGia = qg.MaQG join TinhTP ttp on tt.TinhTP = ttp.MaTinh
                        join DanToc dt on tt.MaDT = dt.MaDT join TonGiao tg on tt.MaTG=tg.MaTG
                        join QuanHuyen qh on tt.QuanHuyen = qh.MaQuan join GioiTinh gt on tt.MaGT=gt.MaGT
                        join ChucVu cv on nv.MaCV = cv.MaCV join PhongBan pb on nv.MaPB = pb.MaPB
                        join TinhTrangNhanVien ttnv on nv.MaTT=ttnv.MaTT join LoaiLuong ll on nv.MaLoaiLuong = ll.MaLoaiLuong";
            if (exists == true)
            {
                DataProvider dataProvider = new DataProvider();
                try
                {
                    dataProvider.connect();
                    tb = dataProvider.ExecuteQuery_DataTble(query);
                    return tb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
            return null;
        }


        public static DataTable GetDescriptionSelected(TreesSearchModel TreeSearchViewModel)
        {
            DataTable tb = new DataTable();
            bool exists = false;
            string query = @"select st.name[Table], sc.name[Column], sep.value[Description]
                            from sys.tables st inner join sys.columns sc on st.object_id = sc.object_id 
                            left join sys.extended_properties sep on st.object_id = sep.major_id and sc.column_id = sep.minor_id and sep.name = 'MS_Description'
                            where ";
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < TreeSearchViewModel.SearchObjects[i].SearchElements.Count; j++)
                {
                    bool resetElement = false;
                    for (int n = 0; n < TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails.Count; n++)
                    {
                        if (TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].IsCheckedDetail == true)
                        {
                            if (resetElement == false)
                            {
                                if (exists == false)
                                    query += " st.name = '" + TreeSearchViewModel.SearchObjects[i].SearchElements[j].Content + "' and (sc.name = '" + TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch + "' ";
                                else query += ") or st.name = '" + TreeSearchViewModel.SearchObjects[i].SearchElements[j].Content + "' and (sc.name = '" + TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch + "' ";
                                resetElement = true;
                                exists = true;
                            }
                            else query += " or sc.name = '" + TreeSearchViewModel.SearchObjects[i].SearchElements[j].SearchElementDetails[n].StrSearch + "' ";
                        }
                    }
                }
            }
            if (exists == true)
            {
                query += " ) ";
                DataProvider dataProvider = new DataProvider();
                try
                {
                    dataProvider.connect();
                    tb = dataProvider.ExecuteQuery_DataTble(query);
                    dataProvider.disconnect();
                    return tb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
            return null;
        }

        public static DataTable GetNhanVienForChoose()
        {
            DataTable tb = new DataTable();
            string query = "Select nv.MaNV, nv.HoTen";
            bool exists = true;
            query += @" From NhanVien nv ";
            if (exists == true)
            {
                DataProvider dataProvider = new DataProvider();
                try
                {
                    dataProvider.connect();
                    tb = dataProvider.ExecuteQuery_DataTble(query);
                    return tb;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
                finally
                {
                    dataProvider.disconnect();
                }
            }
            return null;
        }
    }
}

