   M S B A M L   `   `   `  ����A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD  5          DashaD.PatentsPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:DashaD     5        N� Title$  PatentsPage��5      .��5	      � 
������� � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6!    �� Padding$ 10q�61   $
��Wrap=�6>   $��Патнеты��6R   $��28(�6a   $
��Bold"�6o   �� 5   
   -   5         ��Name$ Search��5   /   $��0��6   $��2��6   $	��200��6?   $��30��6K   $��Right=�6x   $��Center=�6�   $��10q�6�   6�   �� 5   
   -   5         ��Name$ 	AddPatent��5   .   $��5��6   $��2��6   $��Добавить��6A   $
��Bold"�6T   $��16(�6f   $��35��6t   $	��185��6�   $��Right=�6�   $��Center=�6�   $��10q�6�   6�   �� 5   
   -   5        $ 
BackPatent��5   .   $��0��6   $��5��6!   $��
Назад��6B   $
��Bold"�6R   $��16(�6d   $��35��6r   $	��180��6~   $
��Left=�6�   $��Center=�6�   $��10q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ PatentsView��5   U   $��1��6   $��0��6    $��3��60   $��4��6D      AutoGenerateColumns$
 True��6j   $��15q�6�   $��Stretch=�6�   $��Stretch=�6�   6�   5      5      