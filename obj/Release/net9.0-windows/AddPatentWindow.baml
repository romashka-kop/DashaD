   M S B A M L   `   `   `  ���� A  =DashaD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DashaDDashaD      DashaD.AddPatentWindow   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DashaD       � Title$  Патент��$	��450��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� �� �� .+��� $��0��$��0��$
��Left=� �� Padding$ 10q�$
��Wrap=�$��Патент��$��28(�$
��Bold"�$	��Top=��� $��1��$��3��.���� .+�Q� -    Q�Name$ Patent��$��Патент��$��16(�$
��Left=�$	��Top=�.@��� $��Название��$��15(��� -    ��Name$ PatentNameX��$	��190��$��15(��� $��
Номер��$��15(��� -   $ PatentNumberX��$	��190��$��15(��� $/��)Приоритет изобретения��$��15(��� -   $ DatePriorityX��$	��190��$��15(��� $��15(�DBЗарегистрировано в Государственном�� ,*реестре изобретений РФ�� -   $ DateRegistrationX��$	��190��$��15(��� $?��9Срок действия патента истекает��$��15(��� -   $ 
DateFinalX��$	��190��$��15(�Q� -   $ Author��$��Авторы��$��16(�$
��Left=�$	��Top=�.@��� -    ��Name$ AddedAuthorsList��$��15(�$	��200��$	��100��$
��Auto=�$
��Auto=� �� DisplayMemberPath$ FullName��Q� -	   $	 Bid��$��Заявка��$��16(�$
��Left=�$	��Top=�.@��� $��
Номер��$��15(��� -
    ��Name$ AddBidNumber��$	��190��$��15(�Q� -   $ 	Agreement��$��Договора��$��16(�$
��Left=�$	��Top=�.@��� -   $ ListAgreements��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=�$ AgreementName���� -   	 ��Name$	 AddAgreements��$��+��$��25��$��25���� -   
 ��Name$
 TextType��$y�	Collapsed=�$��Тип��$��15(��� -   $ AgreementType��$y�	Collapsed=�$	��190��$��15(�.@��� $��Договор���� $��Акт���� -   $
 TextName��$y�	Collapsed=�$��Название��$��15(��� -   $ AgreementName��$y�	Collapsed=�$	��190��$��15(��� -   $
 
TextPeriod��$y�	Collapsed=�$��Период��$��15(��� -   $ AgreementPeriod��$y�	Collapsed=�$	��150��$��15(��� -   $ AgreementPeriod1��$y�	Collapsed=�$	��150��$��15(��� -   $
 
TextNumber��$y�	Collapsed=�$��
Номер��$��15(��� -   $ AgreementNumber��$y�	Collapsed=�$	��190��$��15(��� -   $
 TextData��$y�	Collapsed=�$��Дата��$��15(�Q� -   $ AgreementCreation��$y�	Collapsed=�$*��$Договор за создание��$��16(�$
��Left=�$	��Top=�.@��� $��
Номер��$��15(��� -   $ AgreementCreationNumber��$	��190��$��15(��� $��Дата��$��15(��� -   $ AgreementCreationDate��$	��190��$��15(��� $��Договор��$��15(��� -   $ AgreementCreationFile��$
��Auto=�$	��275�� �� TextWrapping$
 Wrap=�$	��525��$��15(�Q� -   $ ActUse��$y�	Collapsed=�$,��&Акт об использовании��$��16(�$
��Left=�$	��Top=�.@��� -   $
 	UseNumber��$��
Номер��$��15(��� -   $ ActUseNumber��$	��190��$��15(��� -   $
 UseDate��$��Дата��$��15(��� -    $ 
ActUseDate��$	��190��$��15(��� -!   $
 	UsePeriod��$��Период��$��15(��� -"   $ ActUsePeriod��$	��190��$��15(��� -#   $ ActUsePeriod1��$	��190��$��15(��� -$   $
 UseFile��$��Акт��$��15(��� -%   $ 
ActUseFile��$
��Auto=�$	��275��$
 Wrap=�$	��525��$��15(��� -&   $	 AddAgreement��$y�	Collapsed=�$��Добавить���� -'   $	 CloseAgreements��$y�	Collapsed=�$��Закрыть��Q� -(   $ ActComparingAnalysis��$9��3Акт о сопоставлении анализа��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -)   $  ComparingAnalysisPeriodAct��$	��150��$��15(��� -*   $! ComparingAnalysisPeriodAct1��$	��150��$��15(��� $��
Номер��$��15(��� -+   $  ComparingAnalysisActNumber��$	��190��$��15(��� $��Дата��$��15(��� -,   $ ComparingAnalysisDateAct��$	��190��$��15(�Q� --   $ ActImplementation��$��Акт внедрения��$��16(�$
��Left=�$	��Top=�.@��� $��
Номер��$��15(��� -.   $ ActImplementationNumber��$	��190��$��15(��� $��Дата��$��15(��� -/   $ ActImplementationDate��$	��190��$��15(�Q� -0   $ PaymentDuties��$*��$Платежки за пошлины��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -1   $ PaymentsDutiesPeriod��$	��150��$��15(��� -2   $ PaymentsDutiesPeriod1��$	��150��$��15(��� -3   $ PaymentsDutiesList��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=�$ DatePay���� -4   $	 
AddPayment��$��+��$��25��$��25���� -5   $
 TextDatePayment��$y�	Collapsed=�$��Дата��$��15(��� -6   $ PaymentsDutiesDate��$y�	Collapsed=�$	��190��$��15(��� -7   $	 AddPayments��$y�	Collapsed=�$��Добавить���� -8   $	 ClosePayment��$y�	Collapsed=�$��Закрыть��Q� -9   $ LetterAuthor��$&�� Письма с авторами��$��16(�$
��Left=�$	��Top=�.@��� $��Период��$��15(��� -:   $ LetterAuthorPeriod��$	��190��$��15(��� -;   $ LetterAuthorPeriod1��$	��190��$��15(��� $��Письма��$��15(��� -<   $ LettersAuthorsList��$
��Auto=�$
��Auto��$
��Auto��$
��Auto=�$ LetterNumber���� -=   $	 AddLettersAuthors��$��+��$��25��$��25���� ->   $
 
LetterDate��$��Дата��$��15(�$y�	Collapsed=��� -?   $ LetterAuthorDate��$	��190��$��15(�$y�	Collapsed=��� -@   $
 LetterNumber��$��
Номер��$��15(�$y�	Collapsed=��� -A   $ LetterAuthorNumber��$	��190��$��15(�$y�	Collapsed=��� -B   $
 
FileLetter��$��Письмо��$��15(�$y�	Collapsed=��� -C   $ FileLetterAuthor��$y�	Collapsed=�$
��Auto=�$	��275��$
 Wrap=�$	��525��$��15(��� -D   $	 AddLetterAuthors��$y�	Collapsed=�$��Добавить���� -E   $	 CloseLetterAuthors��$y�	Collapsed=�$��Закрыть���� -F   $	 	AddPatent��$��2��$��2��$��Добавить��$
��Bold"�$��16(�$��35��$	��180��$��Right=�$��Bottom=�$��10q�