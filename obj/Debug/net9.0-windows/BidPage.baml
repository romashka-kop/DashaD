   M S B A M L   `   `   `  ����A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD  5          DashaD.BidPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:DashaD     5        N� Title$  BidPage��5      .��5
      � 
������� � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!    �� Padding$ 10q�61   $
��Wrap=�6>   $��Заявки��6R   $��28(�6`   $
��Bold"�6n   �� 5   
   -   5         ��Name$ Search��5   ;   $��0��6   $��10q�6   $��2��6+   $	��200��6K   $��30��6W   $��Right=�6c   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ AddBid��5   :   $��5��6   $��10q�6   $��2��6*   $��Добавить��6J   $
��Bold"�6]   $��16(�6o   $��35��6}   $	��185��6�   $��Right=�6�   $��Center=�6�   6�   �� 5   
   -   5        $ 	RemoveBid��5   :   $��5��6   $��10q�6   $��1��6*   $��Удалить��6M   $
��Bold"�6_   $��16(�6q   $��35��6   $	��185��6�   $��Right=�6�   $��Center=�6�   6�   �� 5   
   -   5        $ BackBid��5   .   $��0��6   $��5��6!   $��
Назад��6?   $
��Bold"�6O   $��16(�6a   $��35��6o   $	��180��6{   $
��Left=�6�   $��Center=�6�   $��10q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ BidView��5         AutoGenerateColumns$
 True��6$   $��1��6?   $��0��6L   $��3��6\   $��4��6p   $��15q�6�   $��Stretch=�6�   $��Stretch=�6�   6�   5      5       