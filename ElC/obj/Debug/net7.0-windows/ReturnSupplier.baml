   M S B A M L   `   `   `  ����>  :ElC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ElCElC  5          ElC.ReturnSupplier   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:ElC     5      .��5	      �� ���#7B8FA1$��5q�6#     �� CornerRadius$  25��67   
�������._�5
   
   � .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��0.4* �6'   5      �� 5      5      .+�5      � $��0��6    � RowDefinitions 5      �� 5      5      �� 5      5       �� 5!      5#      �� 5$      5&      .+�5)      � $��0��6   .+�5*      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��Cooper Black)�6a   
���   �Bill Number6�   �� 5+      -   5        $��OrderID��5+   <   $	��170��6$   $��25��60   
���i��6�   5,      � 5-      $��1��6   .+�5.      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��Cooper Black)�6a   
���   �Product Name6�   �� 5/      -   5         ��Name$ productnametextbox��5/   "   $	��170��6?   $��25��6K    �� 
IsReadOnly$
 True��6W   ���#7B8FA1$��3q�6   6�   51      � 52      $��2��6   .+�53      �� $��0,10,0,0q�6$   $��Center=�66   $��18(�6S   $��Cooper Black)�6a   
���   �
Quantity6�   �� 54      -   5        $ producttoreturn��54   #   $	��170��6<   $��25��6H   ���#7B8FA1$��3q�6j   6�   56      � 57      $��3��6    58      �� 59      5;      �� 5<      5>      .+�5D      �� -   5         ��Name$ 	btnReturn��5D   !   $��Return��5E      $��0q�5F      $��0 0 0 0q�5G      
�������$��0��5I      $��20(�5J      $
��Bold"�5K      ��5O      �� 5P   "    �� 
TargetType" ��6(   .�5Q   &   ��  �� Property � �� �� Value �#7B8FA16U   	 �� Triggers	 5R   &   P� 5S   *   
 P� Property
 �@J�IsMouseOver P� Value$
 True��6I   . �5T   .   ��  � ��
 �  ��6Z   �� 5U   .    �@�Cursor$
 Hand��6G   6V   5W   +   5Y   #   ��5[      �� 5\   "    �� 
TargetType" ��62   .R�5]   &   �� $  9��6-   $	��100��6>   $��39��6J   #��z��6V   ._�5^   *   �� $��Center=�6;   $��Center=�6V   6u   5_   '   5`   #   5b      �� 5e      -   5        $ btnAdd��5e   !   $	��Add��5f      $��0q�5g      $��0 0 0 0q�5h      
�������$��1��5j      $��20(�5k      $
��Bold"�5l      ��5p      �� 5q   "   " ��6(   .�5r   &   ��  � �� �#7B8FA16U   	 5s   &   P� 5t   *   
 �@J�IsMouseOver$
 True��6I   . �5u   .   ��  � �� �#FFE15D6]   �� 5v   .    �@�Cursor$
 Hand��6G   6V   5x   +   5z   #   ��5|      �� 5}   "   " ��62   .R�5~   &   �� $  9��6-   $	��100��6>   $��40��6J   #��z��6V   ._�5   *   �� $��Center=�6;   $��Center=�6V   6u   5�   '   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      5�      �� 5�      5�      .+�5�      � $��0��6   .+�5�      &   System.Windows.Controls.DataGrid  -   5        $��Product��5�   7   $��	 10 8 8 8q�6#      CanUserAddRows$ False��6F      AutoGenerateColumns$ False��6^      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6z   ���#BDCDD6$��4q�5�   !   ���#BDCDD6   GridLinesVisibility$
 None=�5�   W      Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�   "   ,  &System.Windows.Controls.DataGridColumn   Header$ productname��65      
IsReadOnly$
 True��6j      Width$
 1.1* 6|   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *productname+6|     5�   "   $ suppliername��65   $
 True��6l   $ 1* 6~    6K   �� *suppliername+6~     5�   "   $ ProductQuantity��65   $
 True��6r   $
 1.3* 6�    6N   �� *ProductQuantity+6�     5�   "   $
 Date��65   $
 True��6\   $ 1.59* 6n    6C   �� *Date+6n   5�      5�      � 5�      $��1��6   .+�5�        -   5        $��ReturnedProduct��5�   7   $��	 10 8 8 8q�6#   $ False��6N   $ False��6f   $ * 6�   ���#BDCDD6$��4q�5�   !   ���#BDCDD6$
 None=�5�   !    5�        5�   "   $ productname��65   $
 True��6j   $
 1.1* 6|    6J   �� *productname+6|     5�   "   $ suppliername��65   $
 True��6l   $ 1* 6~    6K   �� *suppliername+6~     5�   "   $ ProductQuantity��65   $
 True��6r   $ 1.59* 6�    6N   �� *ProductQuantity+6�     5�   "   $
 Date��65   $
 True��6\   $
 1.3* 6n    6C   �� *Date+6n   5�      5�      5�      5�      5�      5�      5�      