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
        public static SqlCommandBuilder cbEdit;
        public static SqlCommandBuilder cbEditCT;
        public static SqlCommandBuilder cbLayoff;
        public static SqlDataAdapter daEdit;
        public static SqlDataAdapter daEditCT;
        public static SqlDataAdapter daLayoff;
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
                        join TinhTrangNhanVien ttnv on nv.MaTT=ttnv.MaTT";
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
            string query = "Select nv.MaNV, nv.HoTen From NhanVien nv";

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
            return null;
        }

        public static DataTable GetLastNhanVien()
        {
            DataTable tb = new DataTable();
            string query = "Select TOP 1 nv.MaNV From NhanVien nv Order by nv.MaNV DESC";

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
            return null;
        }

        public static void AddNhanVien(NhanVienDTO nv, ThongTinChiTietNhanVienDTO ttct)
        {
            string query = @"INSERT INTO NhanVien (MaNV, HoTen, NgayVaoLam, MaCV, MaPB, LuongCB, HinhAnh, MaTT) VALUES( '" + nv.MaNV + "', N'" + nv.HoTen + "', '" + nv.NgayVaoLam.ToString("yyyy-MM-dd") + "', '" + nv.MaCV + "', '" + nv.MaPB + "', '" + nv.LuongCanBan + "', N'" + nv.HinhAnh + "', " + nv.MaTT.ToString() + "); ";
            string query2 = @"INSERT INTO ThongTinChiTietNhanVien (MaNV, MaGT, CMND, NgaySinh, NoiSinh, DienThoai, SoNha, Duong, PhuongXa, QuanHuyen, TinhTP, QuocGia, MaDT, MaTG, SoTheATM, Email) VALUES( '" + nv.MaNV + "', '" + ttct.MaGT.ToString() + "', '" + ttct.CMND + "', '" + ttct.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + ttct.NoiSinh + "', '" + ttct.DienThoai + "', '" + ttct.SoNha + "', N'" + ttct.Duong + "', N'" + ttct.PhuongXa + "', '" + ttct.QuanHuyen.Trim() + "', '" + ttct.TinhTP.Trim() + "', '" + ttct.QuocGia.Trim() + "', '" + ttct.MaDT.Trim() + "', '" + ttct.MaTG.Trim() + "', '" + ttct.SoTheATM + "', N'" + ttct.Email + "' ); ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                dataProvider.ExecuteUpdateQuery(query2);
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        public static void AddNhanVienMulti(NhanVienDTO nv, ThongTinChiTietNhanVienDTO ttct)
        {
            string query = @"INSERT INTO NhanVien (MaNV, HoTen, NgayVaoLam, MaCV, MaPB, LuongCB, HinhAnh, MaTT) VALUES( '" + nv.MaNV + "', N'" + nv.HoTen + "', '" + nv.NgayVaoLam.ToString("yyyy-MM-dd") + "', " + nv.MaCV + ", " + nv.MaPB + ", '" + nv.LuongCanBan + "', N'" + nv.HinhAnh + "', " + nv.MaTT.ToString() + "); ";
            string query2 = @"INSERT INTO ThongTinChiTietNhanVien (MaNV, MaGT, CMND, NgaySinh, NoiSinh, DienThoai, SoNha, Duong, PhuongXa, QuanHuyen, TinhTP, QuocGia, MaDT, MaTG, SoTheATM, Email) VALUES( '" + nv.MaNV + "', '" + ttct.MaGT.ToString() + "', '" + ttct.CMND + "', '" + ttct.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + ttct.NoiSinh + "', '" + ttct.DienThoai + "', '" + ttct.SoNha + "', N'" + ttct.Duong + "', N'" + ttct.PhuongXa + "', " + ttct.QuanHuyen.Trim() + ", " + ttct.TinhTP.Trim() + ", " + ttct.QuocGia.Trim() + ", " + ttct.MaDT.Trim() + ", " + ttct.MaTG.Trim() + ", '" + ttct.SoTheATM + "', N'" + ttct.Email + "' ); ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                dataProvider.ExecuteUpdateQuery(query2);
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        public static void LayoffNhanVien(DataTable dt)
        {
            string query = @"UPDATE NhanVien SET MaTT=5 ";
            bool IsExists = false;
            foreach(DataRow row in dt.Rows)
            {
                if (IsExists == false)
                {
                    query += " WHERE MaNV IN ('" + row[0].ToString() + "' ";
                    IsExists = true;
                }
                else {
                    query += " , '" + row[0].ToString() + "' ";
                }
            }
            query += ") ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                DAO.HopDongDAO.LayoffNhanVien(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        public static void UnLayoffNhanVien(DataTable dt)
        {
            string query = @"UPDATE NhanVien SET MaTT=1 ";
            bool IsExists = false;
            foreach (DataRow row in dt.Rows)
            {
                if (IsExists == false)
                {
                    query += " WHERE MaNV IN ('" + row[0].ToString() + "' ";
                    IsExists = true;
                }
                else
                {
                    query += " , '" + row[0].ToString() + "' ";
                }
            }
            query += ") ";
            DataProvider dataProvider = new DataProvider();
            try
            {
                dataProvider.ExecuteUpdateQuery(query);
                DAO.HopDongDAO.UnLayoffNhanVien(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }

        public static DataTable GetNhanVienByElementForChoose(string mabp, string mapb, string malhd, string matt)
        {
            DataTable tb = new DataTable();
            string query = @"Select nv.MaNV, nv.HoTen From NhanVien nv join HopDong hd on nv.MaNV = hd.MaNV join LoaiHopDong lhd on hd.MaLoaiHD = lhd.MaLoaiHD join PhongBan pb on nv.MaPB = pb.MaPB join BoPhan bp on pb.MaBP = bp.MaBP";
            query += " where bp.MaBP LIKE '%" + mabp + "%' and nv.MaPB LIKE '%" + mapb + "%' and lhd.MaLoaiHD LIKE '%" + malhd + "%' and nv.MaTT LIKE '%" + matt + "%' ";
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
            return null;
        }

        public static DataSet GetNhanVienByElementForEdit(DataTable tbTemp)
        {
            DataSet ds = new DataSet();
            bool isnull = true;
            string query = @"Select * From NhanVien nv ";
            query += "where nv.MaNV IN (";
            //query = @"Select * From NhanVien nv join ThongTinChiTietNhanVien tt on nv.MaNV = tt.MaNV ";
            //query += "where nv.MaNV IN (";
            for (int i = 0; i < tbTemp.Rows.Count; i++)
            {
                if (isnull == true)
                {
                    query += "'" + tbTemp.Rows[i][0].ToString().Trim() + "'";
                    isnull = false;
                }
                else query += ", '" + tbTemp.Rows[i][0].ToString().Trim() + "'";
            }
            query += ")";
            string cnnString = "Data Source=.;Initial Catalog=QLNhanVien;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(cnnString);
            try
            {
                cnn.Open();
                daEdit = new SqlDataAdapter();
                daEdit.SelectCommand = new SqlCommand(query, cnn);
                cbEdit = new SqlCommandBuilder(daEdit);
                daEdit.Fill(ds,"NhanVien");
                cnn.Close();
                cnn.Open();

                daEditCT = new SqlDataAdapter();
                query = @"Select * From ThongTinChiTietNhanVien tt ";
                query += " where tt.MaNV IN (";
                isnull = true;
                for (int i = 0; i < tbTemp.Rows.Count; i++)
                {
                    if (isnull == true)
                    {
                        query += "'" + tbTemp.Rows[i][0].ToString().Trim() + "'";
                        isnull = false;
                    }
                    else query += ", '" + tbTemp.Rows[i][0].ToString().Trim() + "'";
                }
                query += ")";
                daEditCT.SelectCommand = new SqlCommand(query, cnn);
                cbEditCT = new SqlCommandBuilder(daEditCT);
                daEditCT.Fill(ds, "ThongTinChiTietNhanVien");
                cnn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return null;
        }

        public static bool UpdateNhanVienByElementForEdit(DataTable tbTemp1 ,DataTable tbTemp2)
        {
            try {
                daEdit.Update(tbTemp1);
                daEditCT.Update(tbTemp2);
                return true;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            return false;
        }

        public static DataTable GetNhanVienByElementForLayoff(DataTable tbTemp)
        {
            DataTable tb = new DataTable();
            bool isnull = true;
            string query = @"Select * From NhanVien nv join ThongTinChiTietNhanVien tt on nv.MaNV = tt.MaNV join HopDong hd on nv.MaNV = hd.MaNV  ";
            query += " where nv.MaNV IN (";
            for (int i = 0; i < tbTemp.Rows.Count; i++)
            {
                if (isnull == true)
                {
                    query += "'" + tbTemp.Rows[i][0].ToString().Trim() + "'";
                    isnull = false;
                }
                else query += ", '" + tbTemp.Rows[i][0].ToString().Trim() + "'";
            }
            query += ") and hd.NgayKyHD >= ALL(Select hd2.NgayKyHD From HopDong hd2 Where hd2.MaNV=nv.MaNV) Order by nv.MaNV";
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataProvider.disconnect();

            }
            return null;
        }
        
        /// <summary>
        /// Lấy thông tin nhân viên theo một điều kiện XXX
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetNhanVienByWhere(string strWhere)
        {
            DataTable tb = new DataTable();
            string query = @"Select nv.MaNV,nv.HoTen,ctnv.NgaySinh,gt.TenGT,bp.TenBP,pb.TenPB,ctnv.DienThoai,ctnv.Email
                            From NhanVien nv join ThongTinChiTietNhanVien ctnv on nv.MaNV = ctnv.MaNV
                            join GioiTinh gt on gt.MaGT = ctnv.MaGT join PhongBan pb on pb.MaPB = nv.MaPB
                            join BoPhan bp on bp.MaBP = pb.MaBP " + strWhere;
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
            return null;
        }
        /// <summary>
        /// Lấy thông tin nhân viên được khen thưởng
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNhanVienDuocKhenThuong()
        {
            DataTable tb = new DataTable();
            string query = @"SELECT nv.MaNV,nv.HoTen,ctnv.NgaySinh,gt.TenGT,bp.TenBP,pb.TenPB,ctnv.DienThoai,ctnv.Email,ctkt.NoiDung,ctkt.HinhThuc,ctkt.NgayQD
                            FROM NhanVien nv join ThongTinChiTietNhanVien ctnv ON nv.MaNV = ctnv.MaNV
                            join GioiTinh gt ON gt.MaGT = ctnv.MaGT join PhongBan pb ON pb.MaPB = nv.MaPB
                            join BoPhan bp ON bp.MaBP = pb.MaBP join ChiTietKhenThuong ctkt ON ctkt.MaNV = nv.MaNV";
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
            return null;
        }
        /// <summary>
        /// lấy thông tin nhân viên bị kỷ luật
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNhanVienBiKyLuat()
        {
            DataTable tb = new DataTable();
            string query = @"SELECT nv.MaNV,nv.HoTen,ctnv.NgaySinh,gt.TenGT,bp.TenBP,pb.TenPB,ctnv.DienThoai,ctnv.Email,ctkl.NguyenNhan,ctkl.HinhThuc,ctkl.NgayKL
                            FROM NhanVien nv join ThongTinChiTietNhanVien ctnv ON nv.MaNV = ctnv.MaNV
                            join GioiTinh gt ON gt.MaGT = ctnv.MaGT join PhongBan pb ON pb.MaPB = nv.MaPB
                            join BoPhan bp ON bp.MaBP = pb.MaBP join ChiTietKiLuat ctkl ON ctkl.MaNV = nv.MaNV";
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
            return null;
        }
    }
}
