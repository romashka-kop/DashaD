   M S B A M L   `   `   `  ���� A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD      DashaD.AddBidWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DashaD       � Title$  Заявка��$	��500��$	��850��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� �� �� .+��� $��0��$��0��$
��Left=� �� Padding$ 10q�$
��Wrap=�$��Заявка��$��28(�$
��Bold"�$	��Top=��� $��1��$��3��.��Q� $��Заявка��$��20(�$
��Left=�$	��Top=�$
��Auto=�.@��� $��
Номер��$��15(��� -    ��Name$ 	BidNumber��$	��190��$��15(��� $��Дата��$��15(��� -   $ BidDate��$	��190��$��15(�Q� $��Формула��$��15(�.@��� -   $ 
BidFormula��$��15q�$
��Auto=�$	��275�� �� TextWrapping$
 Wrap=�$	��525��Q� $��Описание��$��15(�.@��� -   $ BidDescription��$��15q�$
��Auto=�$	��275��$
 Wrap=�$	��525��Q� $��Реферат��$��15(�.@��� -   $ 	BidReport��$��15q�$
��Auto=�$	��275��$
 Wrap=�$	��525��Q� $��Письмо��$��15(�.@��� -   $ 	BidLetter��$��15q�$
��Auto=�$	��275��$
 Wrap=�$	��525���� $��Номер-Дата��$��15(��� -   $ BidNumberDate��$	��190��$��15(�Q� $��Платежки��$��15(�.@��� -    ��Name$ AddPayments��$��+��$��25��$��25���� -	    ��Name$ AddPaymentsList��$	��200��$	��100��$
��Auto=�$y�	Collapsed=� �� DisplayMemberPath$
 File���� -
   	 ��Name$
	 File��$��Файл��$y�	Collapsed=�$��15(��� -   $ Payment��$'��!Добавить документ��$y�	Collapsed=�$	��150��$��15(��� -   $ 
AddPayment��$y�	Collapsed=�$��Добавить���� -   $ ClosePayment��$y�	Collapsed=�$��Закрыть��Q� $��Уведомления��$��15(�.@��� -   $ AddNotifications��$��+��$��25��$��25���� -   $ AddNotificationsList��$	��200��$	��100��$
��Auto=�$y�	Collapsed=�$
 Name���� -   $	 TextNotificationName��$��Название��$y�	Collapsed=�$��15(��� -   $ NotificationName��$y�	Collapsed=�$	��190��$��15(��� -   $	 TextNotificationAddressee��$��Адресат��$y�	Collapsed=�$��15(��� -   $ NotificationAddressee��$y�	Collapsed=�$	��190��$��15(��� -   $	 TextNotificationMessage��$��Сообщение��$y�	Collapsed=�$��15(��� -   $ NotificationMessage��$y�	Collapsed=�$	��190��$	��220��$��15(��� -   $ AddNotification��$y�	Collapsed=�$��Добавить���� -   $ CloseNotification��$y�	Collapsed=�$��Закрыть��Q� $��Авторы��$��15(�$
��Left=�$	��Top=�.@��� -   $ 
AddAuthors��$��+��$��25��$��25���� -   
 ��Name$
 AuthorsComboBox��$y�	Collapsed=�$ FullName�� �� SelectedValuePath$ IdAuthor���� -   $ AddedAuthorsList��$	��200��$	��100��$
��Auto=�$y�	Collapsed=�$ FullName���� -   $ 	AddAuthor��$y�	Collapsed=�$��Добавить���� -   $ AddBid��$��2��$��2��$��Добавить��$
��Bold"�$��16(�$��35��$	��180��$��Right=�$��Bottom=�$��10q�