   M S B A M L   `   `   `  ���� A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD      DashaD.AuthorsPage   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     &localclr-namespace:DashaD       N� Title$  AuthorsPage��.��� 
������� � RowDefinitions �� �� �� �� �� ��  � ColumnDefinitions �� �� �� .+��� $��0��$��0�� �� Padding$ 10q�$
��Wrap=�$��Авторы��$��28(�$
��Bold"��� -    ��Name$ Search��$��0��$��2��$	��200��$��30��$��Right=�$��Center=�$��10q��� -    ��Name$ 	AddAuthor��$��5��$��2��$��Добавить��$
��Bold"�$��16(�$��35��$	��185��$��Right=�$��Center=�$��10q��� -   $ 
BackAuthor��$��0��$��5��$��
Назад��$
��Bold"�$��16(�$��35��$	��180��$
��Left=�$��Center=�$��10q�&   System.Windows.Controls.DataGrid  -     Name$ AuthorsView��   AutoGenerateColumns$
 True��$��1��$��0��$��3��$��4��$��15q�$��Stretch=�$��Stretch=�