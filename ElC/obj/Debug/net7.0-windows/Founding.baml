   M S B A M L   `   `   `  ����>  :ElC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ElCElC  5          ElC.Founding   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:ElC     5      .��5
      � ���#7B8FA1  � RowDefinitions  5   
   �� 5      $��0.12* �6   5      �� 5      5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      5      �� 5      5      .+�5      � $��0��6   $��0��6    .+�5      �� $��Center=�6   $��18(�6;   $��MV Boli)�6I   $��DemiBold"�6^   Customer Name6�   �� 5      -   5        $��CustomerName��5      $��0,30,0,0q�6/   $��Center=�6A   $	��170��6_   $��25��6k   6�   5!      � 5"      $��1��6   $��1��6    .+�5#      �� $��Center=�6   $��18(�6;   $��MV Boli)�6I   $��DemiBold"�6^   Customer Phone6�   �� 5$      -   5        $��CustomerPhone��5$      $��0,30,0,0q�60   $��Center=�6B   $	��170��6`   $��25��6l   6�   5&      5,      � 5.   
   $��1��6    5/      �� 50      $
��229* �6#   52      �� 53      $
��498* �6#   55      �� 56      $	��73* �6#   .+�58      � $��0��6     59      �� 5:      5<      �� 5=      5?      �� 5@      5B      �� 5C      5E      .+�5J      � $��0��6   $��0,30,0,0q�6$   .+�5K      �� $��0,0,0,0q�6    $��Center=�61   $��18(�6N   $��MV Boli)�6\   $��DemiBold"�6q   Total Price6�   �� 5L      -   5        $��
TotalPrice��5L   0   $��0,10,0,0q�6   $��Center=�6C   $	��170��6a   $��25��6m   6}   5N      � 5O      -   5        $��PartPay��5O      $��1��6&   $��0,20,0,0q�63   .+�5P      �� $��Center=�6    $��18(�6=   $��MV Boli)�6K   $��DemiBold"�6`   Payed Price6�   �� 5Q      -   5        $��
PayedMoney��5Q      $��Center=�62   $	��170��6P   $��25��6\   6l   5S      � 5T      $��2��6   $��0,20,0,0q�6%   .+�5U      �� $��Center=�6    $��18(�6=   $��MV Boli)�6K   $��DemiBold"�6`   
Reminder6�   �� 5V      -   5        $��Reminder��5V      $��Center=�60   $	��170��6N   $��25��6Z   6j   5X      � 5Z      $��3��6   $��0,20,0,0q�6$   .+�5]      �� -   5        $	��Pay��5]      $��18(�6(   $��DemiBold"�66   $��MV Boli)�6L   $	��100��6a   $��35��6m   
���   �.��6�   Save��5^      �� 5_       �� 
TargetType" ��6$   .�5`   "   ��  �� Property � �� �� Value
 �����6O    �� Triggers 5a   "   P� 5b   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5c   *   ��  �@�Cursor$
 Hand��6C   6R   �� 5d   *    � ��
 ��  �6Z   5h   '   5j      ��5l      �� 5m       �� 
TargetType" ��6.   .R�5n   "   �� 	 �� CornerRadius$	 9��6)   $	��100��6:   $��30��6F   #��z��6R   ._�5o   &   �� $��Center=�67   $��Center=�6R   6q   5p   #   5q      5s      5t      5u      � 5v      $��1��6   $��
0,15,15,13q�6#   $��2��67    5w      �� 5x      $
��195* �6'   �� 5y      $	��83* �6'   .+�5{      &   System.Windows.Controls.DataGrid  -   5        $��CartPaymentGrid��5{      
   CanUserAddRows$
 False��63      AutoGenerateColumns$ False��6L      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6h   ���#BDCDD6$��0q�5}         GridLinesVisibility$
 None=�5~      $��2��6      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ProductName��6-      
IsReadOnly$
 True��6b      Width$
 1.1* 6t   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *ProductName+6t     5�      $ ProductType��6-   $
 True��6b   $ 1* 6t    6B   �� *ProductType+6t     5�      $ ProductCategory��6-   $
 True��6j   $
 1.1* 6|    6F   �� *ProductCategory+6|     5�      $ Quantity��6-   $
 True��6c   $ 1* 6u    6?   �� *ProductQuantity+6u     5�      $ Price��6-   $
 True��6]   $ 1* 6o    6<   �� *ProductPrice+6o   5�      5�      5�      5�      5�      