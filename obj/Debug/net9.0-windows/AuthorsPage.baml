   M S B A M L   `   `   `  ����A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD  5          DashaD.AuthorsPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:DashaD     5        N� Title$  AuthorsPage��5      .��5
      � 
������� � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!    �� Padding$ 10q�61   $
��Wrap=�6>   $��Авторы��6R   $��28(�6`   $
��Bold"�6n   �� 5   
   -   5         ��Name$ Search��5   /   $��0��6   $��2��6   $	��200��6?   $��30��6K   $��Right=�6W   $��Center=�6t   $��10q�6�   6�   �� 5   
   -   5         ��Name$ 	AddAuthor��5   .   $��5��6   $��2��6   $��Добавить��6A   $
��Bold"�6T   $��16(�6f   $��35��6t   $	��185��6�   $��Right=�6�   $��Center=�6�   $��10q�6�   6�   �� 5   
   -   5        $ 
BackAuthor��5   .   $��0��6   $��5��6!   $��
Назад��6B   $
��Bold"�6R   $��16(�6d   $��35��6r   $	��180��6~   $
��Left=�6�   $��Center=�6�   $��10q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AuthorsView��5         AutoGenerateColumns$
 True��6(   $��1��6C   $��0��6P   $��3��6`   $��4��6t   $��15q�6�   $��Stretch=�6�   $��Stretch=�6�   6�   5      5      