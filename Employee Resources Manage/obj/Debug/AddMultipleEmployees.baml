   M S B A M L   `   `   `  ����T  PEmployee Resources Manage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Employee_Resources_ManageEmployee_Resources_Manage  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      S.clr-namespace:Employee_Resources_Manage.Domain Employee_Resources_Manage.Domain  5	      4    .Employee_Resources_Manage.AddMultipleEmployees   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Employee_Resources_Manage     5      9system&clr-namespace:System;assembly=mscorlib     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ;domain.clr-namespace:Employee_Resources_Manage.Domain  5	      .��5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5        $��dialogError��5           
Identifier$  dialogError��63      DialogContent 5   
   �� 5      $��16q�6   .+�5      �� $	��0 8q�6   $��Center=�6)   $
��Wrap=�5      $
��Bold"�6(   $��14(�6:   ��5   F   �� 5   :   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      ��    MaterialDesignFlatButton#��[  6    �� IsCancel . $��8 8 0 0q�5   )   $2��,materialDesign:DialogHost.CloseDialogCommand��5   )   ��5      ��5      	False��64   .��5   3   CANCEL5      5      5      .��5   
   �  � ColumnDefinitions 5      �� 5       �� 5!      �� 5"       � RowDefinitions 5$      �� 5%      �� 5&      $	��100 �6    .+�5(      �� $��0��6   $��Thông tin chung��6'     MaterialDesignGroupBox#���  6@   $��8,10,5,5q�6q   $��1q�6�   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Accent=�6�   $��5q�6�   $
��Bold"�6�   .��5)      �� $
��Auto=�6   $
��Auto=�6B     MaterialDesignBody#���  6g   .��5*      �� .+�5+      ]� $
��5 10q�6$   .+�5,      �� **. Mã nhân viên6;   �� 5-      $��Right=�6(   $��Right=�6?   (MaNV)(Auto)6i   5.      ]� 5/      $
��5 10q�6$   .+�50      �� 01. Họ tên65   �� 51      $��Right=�6(   $��Right=�6?   
(HoTen)(*)6g   52      ]� 53      $
��5 10q�6$   .+�54      �� 02. Ngày vào làm6;   �� 55      $��Right=�6(   $��Right=�6?   (NgayVaoLam)(*)6l   56      ]� 57      $
��5 10q�6$   .+�58      �� 03. Mã phòng ban6;   �� 59      $��Right=�6(   $��Right=�6?   (MaPB)6c   5:      ]� 5;      $
��5 10q�6$   .+�5<      �� 04. Lương căn bản6<   �� 5=      $��Right=�6(   $��Right=�6?   (LuongCB)(*)6i   5>      ]� 5?      $
��5 10q�6$   .+�5@      �� 05. Hình ảnh67   �� 5A      $��Right=�6(   $��Right=�6?   	(HinhAnh)6f   5B      ]� 5C      $
��5 10q�6$   .+�5D      �� 06. Mã tình trạng6<   �� 5E      $��Right=�6(   $��Right=�6?   (MaTT)6c   5F      5G      5H      5I      �� 5J      $��1��6   $��Thông tin chi tiết��6'   #���  6C   $��8,10,5,5q�6t   $��1q�6�   $ Accent=�6�   $��5q�6�   $
��Bold"�6�   .��5K      �� $
��Auto=�6   $
��Auto=�6B   #���  6g   .��5L      �� .+�5M      ]� $
��5 10q�6$   .+�5N      �� 07. Mã giới tính6;   �� 5O      $��Right=�6(   $��Right=�6?   	(MaGT)(*)6f   5P      ]� 5Q      $
��5 10q�6$   .+�5R      �� 08. Chứng minh nhân dân6B   �� 5S      $��Right=�6(   $��Right=�6?   	(CMND)(*)6f   5T      ]� 5U      $
��5 10q�6$   .+�5V      �� 09. Ngày sinh68   �� 5W      $��Right=�6(   $��Right=�6?   (NgaySinh)(*)6j   5X      ]� 5Y      $
��5 10q�6$   .+�5Z      �� 10. Nơi sinh67   �� 5[      $��Right=�6(   $��Right=�6?   	(NoiSinh)6f   5\      ]� 5]      $
��5 10q�6$   .+�5^      �� 11. Điện thoại69   �� 5_      $��Right=�6(   $��Right=�6?   (DienThoai)6h   5`      ]� 5a      $
��5 10q�6$   .+�5b      �� 12. Số nhà65   �� 5c      $��Right=�6(   $��Right=�6?   	(SoNha)6d   5d      ]� 5e      $
��5 10q�6$   .+�5f      �� 13. Đường64   �� 5g      $��Right=�6(   $��Right=�6?   	(Duong)6d   5h      ]� 5i      $
��5 10q�6$   .+�5j      �� 14. Phường/xã68   �� 5k      $��Right=�6(   $��Right=�6?   
(PhuongXa)6g   5l      ]� 5m      $
��5 10q�6$   .+�5n      �� 15. Quận/huyện69   �� 5o      $��Right=�6(   $��Right=�6?   (QuanHuyen)6h   5p      ]� 5q      $
��5 10q�6$   .+�5r      �� 16.Tỉnh/thành phố6<   �� 5s      $��Right=�6(   $��Right=�6?   
(TinhTP)6e   5t      ]� 5u      $
��5 10q�6$   .+�5v      �� 17. Quốc gia67   �� 5w      $��Right=�6(   $��Right=�6?   	(QuocGia)6f   5x      ]� 5y      $
��5 10q�6$   .+�5z      �� 18. Mã dân tộc69   �� 5{      $��Right=�6(   $��Right=�6?   (MaDT)6c   5|      ]� 5}      $
��5 10q�6$   .+�5~      �� 19. Mã tôn giáo6:   �� 5      $��Right=�6(   $��Right=�6?   (MaTG)6c   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� 20. Số thẻ ATM69   �� 5�      $��Right=�6(   $��Right=�6?   
(SoTheATM)6g   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� 21. Địa chỉ Email6<   �� 5�      $��Right=�6(   $��Right=�6?   	(Email)6d   5�      5�      5�      5�      �� 5�      $��2��6   $��Thông tin hợp đồng��6'   #���  6C   $��8,10,5,5q�6t   $��1q�6�   $ Accent=�6�   $��5q�6�   $
��Bold"�6�   .��5�      �� $
��Auto=�6   $
��Auto=�6B   #���  6g   .��5�      �� .+�5�      ]� $
��5 10q�6$   .+�5�      �� **. Mã hợp đồng6:   �� 5�      $��Right=�6(   $��Right=�6?   (MaHD)(Auto)6i   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� 22. Mã loại hợp đồng6?   �� 5�      $��Right=�6(   $��Right=�6?   (MaLoaiHD)(*)6j   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� 23. Ngày ký hợp đồng6?   �� 5�      $��Right=�6(   $��Right=�6?   (NgayKyHD)(*)6j   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� 24. Ngày hết hạn6;   �� 5�      $��Right=�6(   $��Right=�6?   (NgayHetHan)6i   5�      ]� 5�      $
��5 10q�6$   .+�5�      �� %#25. Mã tình trạng hợp đồng6E   �� 5�      $��Right=�6(   $��Right=�6?   (MaTTHD)(*)6h   5�      5�      5�      5�      �� 5�      $
��50,0q�6   $��0��6'   $��1��67   $��2��6D   $��Center=�6X   $ 
Horizontal=�6s   .+�5�      �� -   5        $��tbFile��5�      $��Center=�6(   $
��Left=�6C   $	��250��6^   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ File import��6j   #���  6�   6�   �� 5�      -   5        $��btnFile��5�       * &MaterialDesignFloatingActionMiniButton#��[ 6(   $	��5 0q�6h   .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6.   	 � ToolTip$	 Load file Excel��6?   5�      �� 5�      -   5        $��btnAdd��5�   6   $��2��6   $��1��6)   #��[  6D   $	��120��6v   $��Center=�6�   $��Right=�6�   $��10q�6�   .��6�   Add6�   5�      �� 5�      -   5        $��btnTemplate��5�      $��2��6(   $��1��68   #��[  6E   $	��120��6w   $��Center=�6�   $��Right=�6�   $��0 0 20 0q�6�   .��6�   
Template6�   �� 5�      -   5        $��btnError��5�      $��2��6%   $��1��65   #��[  6B   $	��120��6t   $��Center=�6�   $��Right=�6�   $��	0 0 170 0q�6�   .��6�   Error6�   5�      5�      5�      