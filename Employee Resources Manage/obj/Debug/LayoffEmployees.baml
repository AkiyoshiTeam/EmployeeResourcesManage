   M S B A M L   `   `   `  ����T  PEmployee Resources Manage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Employee_Resources_ManageEmployee_Resources_Manage  5      E'clr-namespace:Employee_Resources_ManageEmployee_Resources_Manage  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      S.clr-namespace:Employee_Resources_Manage.Domain Employee_Resources_Manage.Domain  5
      /    )Employee_Resources_Manage.LayoffEmployees   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Employee_Resources_Manage     5      5c'clr-namespace:Employee_Resources_Manage     5      9system&clr-namespace:System;assembly=mscorlib     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      ;domain.clr-namespace:Employee_Resources_Manage.Domain  5
        � 	Resources  5      .   (Employee_Resources_Manage.ImageConverter   MyImageConverter-   'Employee_Resources_Manage.MaPBConverter  MaPBConverter-   'Employee_Resources_Manage.MaTTConverter  MaTTConverter-   'Employee_Resources_Manage.MaGTConverter  MaGTConverter-   'Employee_Resources_Manage.MaQHConverter  MaQHConverter.   (Employee_Resources_Manage.MaTTPConverter  MaTTPConverter-   'Employee_Resources_Manage.MaQGConverter  MaQGConverter-   'Employee_Resources_Manage.MaDTConverter  MaDTConverter-	   'Employee_Resources_Manage.MaTGConverter  MaTGConverter.
   (Employee_Resources_Manage.MaLHDConverter 	 MaLHDConverter/   )Employee_Resources_Manage.MaTTHDConverter 
 MaTTHDConverter��%?  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &	 �     &		 �     &	
 �       5   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6     5   
   6   	  5   
   6   
  5   
   6     5   
   6   5      .��5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5        $��dialogHostWarning��5          
Identifier$ dialogHostWarning��69   $��0��6X   $��0��6h   $��3��6u   $��2��6�   $��0q�6�      DialogContent 5   
   �� 5      $��16q�6   .+�5      �� $	��0 8q�6   $��Center=�6)   $
��Bold"�6_   $��14(�6q   ��6F   �� *	Content+6q   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      ��   MaterialDesignFlatButton#��[ 6    �� 	IsDefault . $��0 8 8 0q�5!   )   $2��,materialDesign:DialogHost.CloseDialogCommand��5"   )   {�5    :   �� *Acc+��5#      ��5$      True��63   .��5%   3   ACCEPT5'      �� 5(      #��[ 6    �� IsCancel . $��8 8 0 0q�5*   )   $2��,materialDesign:DialogHost.CloseDialogCommand��5+   )   ��5,      ��5-      	False��64   .��5.   3   CANCEL50      51      52      .��54   
   �  � RowDefinitions 55      �� 56      �� 57      $	��100 �6    .+�59      &   System.Windows.Controls.DataGrid  -   5        $��dataGridSelectedNV��59        MaterialDesignDataGrid#��[ 62   $��0��6z      CanUserAddRows .     AutoGenerateColumns .  	   
IsReadOnly	 . -  'MaterialDesignThemes.Wpf.DataGridAssist
   CellPadding$
 4 2 2 2q�5;         ColumnHeaderPadding$ 4 2 2 2q�6L     MaterialDesignBody#���  6�   ��59   b   ��    RowDetailsTemplate 5<      �� 5=      .R�5>      ]� .+�5?      ��  �� CornerRadius$ 2��6%   $��2q�66     SecondaryAccentBrush#���  6J   $	��Top=�6     IdealForegroundColorBrush#���  6�   $��Center=�6�   $��5q�6�   $	��134��6�   $	��174��6  ._�5@   "   �� $��UniformToFill=�6p   $��Center=�6�   $��Center=�6�   ��6(   �� *	HinhAnh+ �� 	Converter# [  5A   #   5B      � 5C      $��20q�6#    � ColumnDefinitions 5D   "   �� 5E   &   $
��Auto �67   �� 5F   &   $
��Auto �67   �� 5G   &   $
��Auto �67   �� 5H   &   $
��Auto �67   �� 5I   &   $
��Auto �67   �� 5J   &   $
��Auto �67   �� 5K   &   $
��Auto �67   �� 5L   &   $
��Auto �67   �� 5M   &   $
��Auto �67   �� 5N   &   $��* �67    5P   "   �� 5Q   &   �� 5R   &   �� 5S   &   �� 5T   &   �� 5U   &   �� 5V   &   .+�5Y   "   �� $��8 0 0 0q�6,   $��Mã Nhân Viên: ��6=   $
��Bold"�6S   �� 5Z   "   $��0 0 8 0q�6,   $��1��6S   ��6=   �� *MaNV+6S   �� 5[   "   $��8 0 0 0q�6,   $��Họ Tên: ��6=   $
��Bold"�6M   $��1��6_   �� 5\   "   $��0 0 8 0q�6,   $��1��6T   $��1��6d   ��6=   �� *HoTen+6d   �� 5]   "   $��8 0 0 0q�6,   $��Ngày Vào Làm: ��6=   $
��Bold"�6S   $��2��6e   �� 5^   "   $��0 0 8 0q�6,   $��1��6t   $��2��6�   ��6=   �� *
NgayVaoLam+ �� StringFormat$ 
dd/MM/yyyy��6�   �� 5_   "   $��8 0 0 0q�6,   $��Phòng Ban: ��6=   $
��Bold"�6P   $��3��6b   �� 5`   "   $��0 0 8 0q�6,   $��1��6}   $��3��6�   ��6=   �� *MaPB+# [ 6�   �� 5a   "   $��8 0 0 0q�6,   $��Lương căn bản: ��6=   $
��Bold"�6T   $��4��6f   �� 5b   "   $��0 0 8 0q�6,   $��1��6V   $��4��6f   ��6=   �� *	LuongCB+6f   �� 5c   "   $��8 0 0 0q�6,   $��Tình Trạng: ��6=   $
��Bold"�6Q   $��0��6c   $��5��6s   �� 5d   "   $��0 0 8 0q�6,   $��1��6}   $��5��6�   ��6=   �� *MaTT+# [ 6�   �� 5f   "   $��1��6/   $��6��6?   $��2��6P   �� 5h   "   $��8 0 0 0q�6,   $��Giới Tính: ��6=   $
��Bold"�6P   $��2��6b   $��0��6r   �� 5i   "   $��0 0 8 0q�6,   $��3��6}   $��0��6�   ��6=   �� *MaGT+# [ 6�   �� 5j   "   $��8 0 0 0q�6,   $��CMND: ��6=   $
��Bold"�6K   $��2��6]   $��1��6m   �� 5k   "   $��0 0 8 0q�6,   $��3��6S   $��1��6c   ��6=   �� *CMND+6c   �� 5l   "   $��8 0 0 0q�6,   $��Ngày Sinh: ��6=   $
��Bold"�6P   $��2��6b   $��2��6r   �� 5m   "   $��0 0 8 0q�6,   $��3��6s   $��2��6�   ��6=   �� *
NgaySinh+$ 
dd/MM/yyyy��6�   �� 5n   "   $��8 0 0 0q�6,   $��Nơi sinh: ��6=   $
��Bold"�6O   $��2��6a   $��3��6q   �� 5o   "   $��0 0 8 0q�6,   $��3��6V   $��3��6f   ��6=   �� *	NoiSinh+6f   �� 5p   "   $��8 0 0 0q�6,   $��Điện Thoại: ��6=   $
��Bold"�6Q   $��2��6c   $��4��6s   �� 5q   "   $��0 0 8 0q�6,   $��3��6X   $��4��6h   ��6=   �� *	DienThoai+6h   �� 5s   "   $��3��6/   $��6��6?   $��2��6P   �� 5u   "   $��8 0 0 0q�6,   $��Số Nhà: ��6=   $
��Bold"�6M   $��4��6_   �� 5v   "   $��0 0 8 0q�6,   $��5��6T   ��6=   �� *SoNha+6T   �� 5w   "   $��8 0 0 0q�6,   $��Đường: ��6=   $
��Bold"�6L   $��4��6^   $��1��6n   �� 5x   "   $��0 0 8 0q�6,   $��5��6T   $��1��6d   ��6=   �� *Duong+6d   �� 5y   "   $��8 0 0 0q�6,   $��Phường, Xã: ��6=   $
��Bold"�6Q   $��4��6c   $��2��6s   �� 5z   "   $��0 0 8 0q�6,   $��5��6W   $��2��6g   ��6=   �� *
PhuongXa+6g   �� 5{   "   $��8 0 0 0q�6,   $��Quận, Huyện: ��6=   $
��Bold"�6R   $��4��6d   $��3��6t   �� 5|   "   $��0 0 8 0q�6,   $��5��6�   $��3��6�   ��6=   �� *	QuanHuyen+# [ 6�   �� 5}   "   $��8 0 0 0q�6,   $��Tỉnh, Thành Phố: ��6=   $
��Bold"�6V   $��4��6h   $��4��6x   �� 5~   "   $��0 0 8 0q�6,   $��5��6�   $��4��6�   ��6=   �� *TinhTP+# [ 6�   �� 5   "   $��8 0 0 0q�6,   $��Quốc Gia: ��6=   $
��Bold"�6O   $��4��6a   $��5��6q   �� 5�   "   $��0 0 8 0q�6,   $��5��6�   $��5��6�   ��6=   �� *	QuocGia+# [ 6�   �� 5�   "   $��5��6/   $��6��6?   $��2��6P   �� 5�   "   $��8 0 0 0q�6,   $��Dân Tộc: ��6=   $
��Bold"�6N   $��6��6`   �� 5�   "   $��0 0 8 0q�6,   $��7��6}   ��6=   �� *MaDT+# [ 6}   �� 5�   "   $��8 0 0 0q�6,   $��Tôn Giáo: ��6=   $
��Bold"�6O   $��6��6a   $��1��6q   �� 5�   "   $��0 0 8 0q�6,   $��7��6}   $��1��6�   ��6=   �� *MaTG+# [ 6�   �� 5�   "   $��8 0 0 0q�6,   $��
Số ATM: ��6=   $
��Bold"�6M   $��6��6_   $��2��6o   �� 5�   "   $��0 0 8 0q�6,   $��7��6W   $��2��6g   ��6=   �� *
SoTheATM+6g   �� 5�   "   $��8 0 0 0q�6,   $��Địa Chỉ Email: ��6=   $
��Bold"�6T   $��6��6f   $��3��6v   �� 5�   "   $��0 0 8 0q�6,   $��7��6T   $��3��6d   ��6=   �� *Email+6d   �� 5�   "   $��7��6/   $��6��6?   $��2��6P   �� 5�   "   $��8 0 0 0q�6,   $��Mã Hợp Đồng: ��6=   $
��Bold"�6R   $��8��6d   �� 5�   "   $��0 0 8 0q�6,   $��9��6S   ��6=   �� *MaHD+6S   �� 5�   "   $��8 0 0 0q�6,   $��Loại Hợp Đồng: ��6=   $
��Bold"�6T   $��8��6f   $��1��6v   �� 5�   "   $��0 0 8 0q�6,   $��9��6�   $��1��6�   ��6=   �� *
MaLoaiHD+# [	 6�   �� 5�   "   $��8 0 0 0q�6,   $��Ngày Bắt Đầu HĐ: ��6=   $
��Bold"�6V   $��8��6h   $��2��6x   �� 5�   "   $��0 0 8 0q�6,   $��9��6r   $��2��6�   ��6=   �� *
NgayKyHD+$ 
dd/MM/yyyy��6�   �� 5�   "   $��8 0 0 0q�6,   $��Ngày Kết Thúc HĐ: ��6=   $
��Bold"�6W   $��8��6i   $��3��6y   �� 5�   "   $��0 0 8 0q�6,   $��9��6t   $��3��6�   ��6=   �� *
NgayHetHan+$ 
dd/MM/yyyy��6�   �� 5�   "   $��8 0 0 0q�6,   $��Tình Trạng HĐ: ��6=   $
��Bold"�6T   $��8��6f   $��4��6v   �� 5�   "   $��0 0 8 0q�6,   $��9��6�   $��4��6�   ��6=   �� *MaTTHD+# [
 6�   5�      5�      5�      5�      �� 5�      -   5        $��btnUnLayoff��5�   "   $��1��6   #��[ 65   $	��120��6g   $
��Left=�6�   $��Center=�6�   $��50,0,0,0q�6�   .��6�   UnLayoff ALL6�   �� 5�      -   5        $��	btnLayoff��5�   "   $��1��6   #��[ 63   $	��120��6e   $��Right=�6�   $��Center=�6�   $��	0,0,200,0q�6�   .��6�   
Layoff ALL6�   �� 5�      -   5        $��btnRefreshData��5�   "   $��1��6   #��[ 68   $	��120��6j   $��Right=�6�   $��Center=�6�   $��0,0,50,0q�6�   .��6�   	Refresh6�   5�      5�      5�      