   M S B A M L   `   `   `  ����>  :ElC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ElCElC  5          
ElC.Return   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:ElC     5      .��5	      �� ���#7B8FA1$��5q�6#     �� CornerRadius$  25��67   
�������._�5   
   � .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.4* �6'   5      �� 5      5      .+�5      � $��0��6    � RowDefinitions 5      �� 5      5      �� 5      5!      �� 5"      5$      �� 5%      5'      .+�5*      � $��0��6   .+�5+      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��MV Boli)�6a   $��DemiBold"�6v   Bill Number6�   �� 5,      -   5        $��OrderID��5,   ;   $	��170��6#   $��25��6/   6y   5-      � 5.      $��1��6   .+�5/      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��MV Boli)�6a   $��DemiBold"�6v   Product Name6�   �� 50      -   5        $��ProductNameBill��50   "   $	��170��6:   $��25��6F    �� 
IsReadOnly$
 True��6R   6f   52      � 53      $��2��6   .+�54      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��MV Boli)�6a   $��DemiBold"�6v   
Quantity6�   �� 55      -   5        $��QuantityBill��55   "   $	��170��67   $��25��6C   6S   57      � 58      $��3��6    59      �� 5:      5<      �� 5=      5?      .+�5F      �� -   5         ��Name$ btnAdd��5F   !   $	��Add��5G      $��0q�5H      $��0 0 0 0q�5I      
�������$��1��5K      $��20(�5L      $
��Bold"�5M      ��5Q      �� 5R   "    �� 
TargetType" ��6(   .�5S   &   ��  �� Property � �� �� Value �#7B8FA16U    �� Triggers 5T   &   P� 5U   *   	 P� Property	 �@J�IsMouseOver
 P� Value$

 True��6I   . �5V   .   ��  � �� �#FFE15D6]   �� 5W   .    �@�Cursor$
 Hand��6G   6V   5Y   +   5[   #   ��5]      �� 5^   "    �� 
TargetType" ��62   .R�5_   &   �� $  9��6-   $	��100��6>   $��40��6J   #��z��6V   ._�5`   *   �� $��Center=�6;   $��Center=�6V   6u   5a   '   5b   #   5d      �� 5e      -   5        $ ReturnProduct��5e   !   $��Return��5f      $��0q�5g      $��0 0 0 0q�5h      
�������$��0��5j      $��20(�5k      $
��Bold"�5l      ��5p      �� 5q   "   " ��6(   .�5r   &   ��  � �� �#7B8FA16U    5s   &   P� 5t   *   	 �@J�IsMouseOver$

 True��6I   . �5u   .   ��  � ��
 �  ��6Y   �� 5v   .    �@�Cursor$
 Hand��6G   6V   5x   +   5z   #   ��5|      �� 5}   "   " ��62   .R�5~   &   �� $  9��6-   $	��100��6>   $��40��6J   #��z��6V   ._�5   *   �� $��Center=�6;   $��Center=�6V   6u   5�   '   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      5�      �� 5�      5�      .+�5�      � $��0��6   .+�5�      &   System.Windows.Controls.DataGrid  -   5        $��Product��5�   6   $�� 0 8 8 8q�6#      CanUserAddRows$ False��6E      AutoGenerateColumns$ False��6]      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6y   ���#BDCDD6$��0q�5�         GridLinesVisibility$
 None=�5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ ProductName��65      
IsReadOnly$
 True��6j      Width$
 1.1* 6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *ProductName+6|     5�   "   $ CustomerName��65   $
 True��6l   $ 1* 6~    6K   �� *CustomerName+6~     5�   "   $ BuyDate��65   $
 True��6b   $ 1.59* 6t    6F   �� *	BuyDate+6t     5�   "   $ ProductQuantity��65   $
 True��6r   $ 1.59* 6�    6N   �� *ProductQuantity+6�   5�      5�      � 5�      $��1��6   .+�5�        -   5        $��ReturnedProduct��5�   6   $�� 0 8 8 8q�6#   $ False��6M   $ False��6e   $ * 6�   ���#BDCDD6$��0q�5�      $
 None=�5�       5�        5�   "   $ ProductName��65   $
 True��6j   $
 1.1* 6|    6J   �� *ProductName+6|     5�   "   $ CustomerName��65   $
 True��6l   $ 1* 6~    6K   �� *CustomerName+6~     5�   "   $ BuyDate��65   $
 True��6b   $ 1.59* 6t    6F   �� *	BuyDate+6t     5�   "   $ ProductQuantity��65   $
 True��6r   $
 1.3* 6�    6N   �� *ProductQuantity+6�   5�      5�      5�      5�      5�      5�      5�      