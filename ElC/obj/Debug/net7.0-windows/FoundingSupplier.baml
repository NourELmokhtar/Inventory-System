   M S B A M L   `   `   `  ����>  :ElC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ElCElC  5          ElC.FoundingSupplier   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:ElC     5      .��5	      � ���#7B8FA1  � RowDefinitions  5
   
   �� 5      $��0.12* �6   5      �� 5      5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      5      �� 5      5      .+�5      � $��0��6   $��0��6    .+�5      �� $��Center=�6   $��18(�6;   $��MV Boli)�6I   $��DemiBold"�6^   Suuplier Name6�   �� 5      -   5        $��SupplierName��5      $��0,30,0,0q�6/   $��Center=�6A   $	��170��6_   $��25��6k   6�   5       � 5!      $��1��6   $��1��6    .+�5"      �� $��Center=�6   $��18(�6;   $��MV Boli)�6I   $��DemiBold"�6^   Suuplier Phone6�   �� 5#      -   5        $��SupplierPhone��5#      $��0,30,0,0q�60   $��Center=�6B   $	��170��6`   $��25��6l   6�   5%      5+      � 5-   
   $��1��6    5.      �� 5/      $
��229* �6#   51      �� 52      $
��498* �6#   54      �� 55      $	��73* �6#   .+�57      � $��0��6     58      �� 59      5;      �� 5<      5>      �� 5?      5A      �� 5B      5D      .+�5I      � $��0��6   $��0,30,0,0q�6$   .+�5J      �� $��0,0,0,0q�6    $��Center=�61   $��18(�6N   $��MV Boli)�6\   $��DemiBold"�6q   Total Price6�   �� 5K      -   5        $��
TotalPrice��5K   0   $��0,10,0,0q�6   $��Center=�6C   $	��170��6a   $��25��6m   6}   5M      � 5N      -   5        $��PartPay��5N      $��1��6&   $��0,20,0,0q�63   .+�5O      �� $��Center=�6    $��18(�6=   $��MV Boli)�6K   $��DemiBold"�6`   Payed Price6�   �� 5P      -   5        $��
PayedMoney��5P      $��Center=�62   $	��170��6P   $��25��6\   6l   5R      � 5S      $��2��6   $��0,20,0,0q�6%   .+�5T      �� $��Center=�6    $��18(�6=   $��MV Boli)�6K   $��DemiBold"�6`   
Reminder6�   �� 5U      -   5        $��Reminder��5U      $��Center=�60   $	��170��6N   $��25��6Z   6j   5W      � 5Y      $��3��6   $��0,20,0,0q�6$   .+�5\      �� -   5        $	��Pay��5\      $��18(�6(   $��DemiBold"�66   $��MV Boli)�6L   $	��100��6a   $��35��6m   
���   �.��6�   Save��5]      �� 5^       �� 
TargetType" ��6$   .�5_   "   ��  �� Property � �� �� Value
 �����6O    �� Triggers 5`   "   P� 5a   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5b   *   ��  �@�Cursor$
 Hand��6C   6R   �� 5c   *    � ��
 ��  �6Z   5g   '   5i      ��5k      �� 5l       �� 
TargetType" ��6.   .R�5m   "   �� 	 �� CornerRadius$	 9��6)   $	��100��6:   $��30��6F   #��z��6R   ._�5n   &   �� $��Center=�67   $��Center=�6R   6q   5o   #   5p      5r      5s      5t      � 5u      $��1��6   $��
0,15,15,13q�6#   $��2��67    5v      �� 5w      $
��195* �6'   �� 5x      $	��83* �6'   .+�5z      &   System.Windows.Controls.DataGrid  -   5        $��CartPaymentGrid��5z      
   CanUserAddRows$
 False��63      AutoGenerateColumns$ False��6L      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6h   ���#BDCDD6$��0q�5|         GridLinesVisibility$
 None=�5}      $��2��6      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ProductName��6-      
IsReadOnly$
 True��6b      Width$
 1.1* 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *ProductName+6t     5�      $ ProductType��6-   $
 True��6b   $ 1* 6t    6B   �� *ProductType+6t     5�      $ ProductCategory��6-   $
 True��6j   $
 1.1* 6|    6F   �� *ProductCategory+6|     5�      $ Quantity��6-   $
 True��6c   $ 1* 6u    6?   �� *ProductQuantity+6u     5�      $ Price��6-   $
 True��6]   $ 1* 6o    6<   �� *ProductPrice+6o   5�      5�      5�      5�      5�      