   M S B A M L   `   `   `  ���� A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD      DashaD.PatentWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DashaD       � Title$  Патент��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� �� �� �� .+��� $��0��$��0��$
��Left=� �� Padding$ 10q�$
��Wrap=�$��Патент��$��28(�$
��Bold"�$	��Top=��� $��1��$��4��.���� .+�Q� -    Q�Name$ Patent��$��Патент��$��16(�$
��Left=�$	��Top=�.@��� $��Название��$��15(��� -    ��Name$ PatentNameX��$	��190��$��15(��� $��
Номер��$��15(��� -   $ PatentNumberX��$	��190��$��15(��� $/��)Приоритет изобретения��$��15(��� -   $ DatePriorityX��$	��190��$��15(��� $��15(�DBЗарегистрировано в Государственном�� ,*реестре изобретений РФ�� -   $ DateRegistrationX��$	��190��$��15(��� $?��9Срок действия патента истекает��$��15(��� -   $ 
DateFinalX��$	��190��$��15(�Q� -   $ Author��$��Авторы��$��16(�$
��Left=�$	��Top=�.@��� -    ��Name$ AddedAuthorsList��$
��Auto=�$	��200��$	��100��$
��Auto=� �� DisplayMemberPath$ FullName��Q� -	   $	 Bid��$��Заявка��$��16(�$
��Left=�$	��Top=�.@��� $��
Номер��$��15(��� -
   $ AddBidNumber��$	��190��$��15(�Q� -   $ 	Agreement��$��Договора��$��16(�$
��Left=�$	��Top=�.@��� -   $ ListAgreements��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=�$ AgreementName���� -    ��Name$ AddAgreements��$��+��$��25��$��25���� -   $ TextType��$y�	Collapsed=�$��Тип��$��15(��� -   	 ��Name$	 AgreementType��$y�	Collapsed=�$	��190��$��15(�.@��� $��Акт���� -   $ TextName��$y�	Collapsed=�$��Название��$��15(��� -   
 ��Name$
 AgreementName��$y�	Collapsed=�$	��190��$��15(��� -   $ 
TextPeriod��$y�	Collapsed=�$��Период��$��15(��� -   $
 AgreementPeriod��$y�	Collapsed=�$	��150��$��15(��� -   $
 AgreementPeriod1��$y�	Collapsed=�$	��150��$��15(��� -   $ 
TextNumber��$y�	Collapsed=�$��
Номер��$��15(��� -   $
 AgreementNumber��$y�	Collapsed=�$	��190��$��15(��� -   $ TextData��$y�	Collapsed=�$��Дата��$��15(��� -   $
 AgreementDate��$y�	Collapsed=�$	��190��$��15(�Q� -   $ ActUse��$y�	Collapsed=�$,��&Акт об использовании��$��16(�$
��Left=�$	��Top=�.@��� -   $ 	UseNumber��$��
Номер��$��15(��� -   $
 ActUseNumber��$	��190��$��15(��� -   $ UseDate��$��Дата��$��15(��� -   $
 
ActUseDate��$	��190��$��15(��� -   $ 	UsePeriod��$��Период��$��15(��� -   $
 ActUsePeriod��$	��190��$��15(��� -    $
 ActUsePeriod1��$	��190��$��15(��� -!   $ UseFile��$��Акт��$��15(��� -"   $
 
ActUseFile��$
��Auto=�$	��275�� �� TextWrapping$
 Wrap=�$	��525��$��15(��� -#   $ AddAgreement��$y�	Collapsed=�$��Добавить���� -$   $ CloseAgreements��$y�	Collapsed=�$��Закрыть��Q� -%   $ ActComparingAnalysis��$9��3Акт о сопоставлении анализа��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -&   $  ComparingAnalysisPeriodAct��$	��150��$��15(��� -'   $! ComparingAnalysisPeriodAct1��$	��150��$��15(��� $��
Номер��$��15(��� -(   $  ComparingAnalysisActNumber��$	��190��$��15(��� $��Дата��$��15(��� -)   $ ComparingAnalysisDateAct��$	��190��$��15(�Q� -*   $ ActImplementation��$��Акт внедрения��$��16(�$
��Left=�$	��Top=�.@��� $��
Номер��$��15(��� -+   $ ActImplementationNumber��$	��190��$��15(��� $��Дата��$��15(��� -,   $ ActImplementationDate��$	��190��$��15(�Q� --   $ PaymentDuties��$*��$Платежки за пошлины��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -.   $
 PaymentsDutiesPeriod��$	��150��$��15(��� -/   $
 PaymentsDutiesPeriod1��$	��150��$��15(��� -0   $ PaymentsDutiesList��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=��� -1   $ 
AddPayment��$��+��$��25��$��25���� -2   $ TextDatePayment��$y�	Collapsed=�$��Дата��$��15(��� -3   $
 PaymentsDutiesDate��$y�	Collapsed=�$	��190��$��15(��� -4   $ AddPayments��$y�	Collapsed=�$��Добавить���� -5   $ ClosePayment��$y�	Collapsed=�$��Закрыть��Q� -6   $ LetterAuthor��$&�� Письма с авторами��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -7   $
 LetterAuthorPeriod��$	��190��$��15(��� -8   $
 LetterAuthorPeriod1��$	��190��$��15(��� $��Письма��$��15(��� -9   $ LettersAuthorsList��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=�$ LetterNumber���� -:   $ AddLettersAuthors��$��+��$��25��$��25���� -;   $ 
LetterDate��$��Дата��$��15(�$y�	Collapsed=��� -<   $
 LetterAuthorDate��$	��190��$��15(�$y�	Collapsed=��� -=   $ LetterNumber��$��
Номер��$��15(�$y�	Collapsed=��� ->   $
 LetterAuthorNumber��$	��190��$��15(�$y�	Collapsed=��� -?   $ 
FileLetter��$��Письмо��$��15(�$y�	Collapsed=��� -@   $
 FileLetterAuthor��$y�	Collapsed=�$
��Auto=�$	��275��$
 Wrap=�$	��525��$��15(��� -A   $ AddLetterAuthors��$y�	Collapsed=�$��Добавить���� -B   $ CloseLetterAuthors��$y�	Collapsed=�$��Закрыть��o� $��35��$��50��$��3��$��Right=�$��10q�.@�m� -C   $	��'''��$��35(�$��Black"�.@�m� -D   $%��Создать документ��$��18(��� -E   $ UpdatePatent��$��3��$��2��$��Обновить��$
��Bold"�$��16(�$��35��$	��180��$��Right=�$��Bottom=�$��10q�