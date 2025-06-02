using DashaD.Context;
using DashaD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;


namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AddPatentWindow.xaml
    /// </summary>
    public partial class AddPatentWindow : Window
    {
        private bool _isUpdating = false;
        public AddPatentWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ApplicationContext context = new();
            foreach (var el in context.Bids)
            {
                AddBidNumber.Items.Add(el.BidNumber);
            }
        }

        private void AddAgreement_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();

            if (AgreementType.SelectedIndex == 0)
            {
                context.AgreementCreation.Add(new Models.AgreementCreation
                {
                    AgreementNumber = long.Parse(AgreementCreationNumber.Text),
                    DateAgreement = DateOnly.ParseExact(AgreementCreationDate.Text, "dd.MM.yyyy"),
                    File = AgreementCreationFile.Text
                });
            }
            else
            {
                context.ActUses.Add(new Models.ActUse
                {
                    ActNumber = long.Parse(ActUseNumber.Text),
                    DateActUse = DateOnly.ParseExact(ActUseDate.Text, "dd.MM.yyyy"),
                    StartDate = DateOnly.ParseExact(ActUsePeriod.Text, "dd.MM.yyyy"),
                    EndDate = DateOnly.ParseExact(ActUsePeriod1.Text, "dd.MM.yyyy"),
                    File = ActUseFile.Text
                });
            }

            if (AgreementType.SelectedIndex == 0)
            {
                context.Agreement.Add(new Models.Agreement
                {
                    Type = (Models.Agreement.TypesAgreement)AgreementType.SelectedIndex,
                    AgreementName = AgreementName.Text,
                    StartDate = DateOnly.ParseExact(AgreementPeriod.Text, "dd.MM.yyyy"),
                    EndDate = DateOnly.ParseExact(AgreementPeriod1.Text, "dd.MM.yyyy"),
                    AgreementNumber = long.Parse(AgreementNumber.Text),
                    DateAgreement = DateOnly.ParseExact(AgreementCreationDate.Text, "dd.MM.yyyy"),
                    IdAgreementCreation = context.AgreementCreation.Where(b => b.AgreementNumber == long.Parse(AgreementCreationNumber.Text))
                                .Select(b => b.IdAgreementCreation).FirstOrDefault()
                });
            }
            else
            {
                context.Agreement.Add(new Models.Agreement
                {
                    Type = (Models.Agreement.TypesAgreement)AgreementType.SelectedIndex,
                    AgreementName = AgreementName.Text,
                    StartDate = DateOnly.ParseExact(AgreementPeriod.Text, "dd.MM.yyyy"),
                    EndDate = DateOnly.ParseExact(AgreementPeriod1.Text, "dd.MM.yyyy"),
                    AgreementNumber = long.Parse(AgreementNumber.Text),
                    DateAgreement = DateOnly.ParseExact(ActUseDate.Text, "dd.MM.yyyy"),
                    IdActUse = context.ActUses.Where(b => b.ActNumber == long.Parse(ActUseNumber.Text))
                                .Select(b => b.IdActUse).FirstOrDefault()
                });
            }

            context.SaveChanges();

            var agreement = context.Agreement.Max(b => b.IdAgreement);
            ListAgreements.Items.Add(context.Agreement.Where(a => a.IdAgreement == agreement).FirstOrDefault());
            ListAgreements.Items.Refresh();

            ClearAgreement();
        }

        private void ClearAgreement()
        {
            AgreementNumber.Clear();
            AgreementCreationNumber.Clear();
            AgreementCreationDate.Clear();
            AgreementCreationFile.Clear();
            ActUseNumber.Clear();
            ActUseDate.Clear();
            ActUsePeriod.Clear();
            ActUsePeriod1.Clear();
            ActUseFile.Clear();
        }

        private void DateInputTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void DateInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdating) return;

            var textBox = sender as TextBox;
            string text = textBox.Text;

            string digitsOnly = RemoveNonDigits(text);

            _isUpdating = true;

            if (digitsOnly.Length > 8)
                digitsOnly = digitsOnly.Substring(0, 8);

            StringBuilder formatted = new StringBuilder();

            for (int i = 0; i < digitsOnly.Length; i++)
            {
                if (i == 2 || i == 4)
                    formatted.Append('.');

                formatted.Append(digitsOnly[i]);
            }

            textBox.Text = formatted.ToString();
            textBox.CaretIndex = textBox.Text.Length;

            _isUpdating = false;
        }

        private string RemoveNonDigits(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void AddPatent_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();

            context.Analysis.Add(new Models.ActComparingAnalysis
            {
                StartDate = DateOnly.ParseExact(ComparingAnalysisPeriodAct.Text, "dd.MM.yyyy"),
                EndDate = DateOnly.ParseExact(ComparingAnalysisPeriodAct1.Text, "dd.MM.yyyy"),
                ActNumber = long.Parse(ComparingAnalysisActNumber.Text),
                DateAct = DateOnly.ParseExact(ComparingAnalysisDateAct.Text, "dd.MM.yyyy")
            });
            context.Implementation.Add(new Models.ActImplementation
            {
                ActNumber = long.Parse(ActImplementationNumber.Text),
                DateAct = DateOnly.ParseExact(ActImplementationDate.Text, "dd.MM.yyyy")
            });
            long idBid = long.Parse(AddBidNumber.SelectedItem.ToString());
            context.Patent.Add(new Models.Patents
            {
                Number = long.Parse(PatentNumberX.Text),
                PatentName = PatentNameX.Text,
                DatePriority = DateOnly.ParseExact(DatePriorityX.Text, "dd.MM.yyyy"),
                DateRegistration = DateOnly.ParseExact(DateRegistrationX.Text, "dd.MM.yyyy"),
                DateFinal = DateOnly.ParseExact(DateFinalX.Text, "dd.MM.yyyy"),
                IdBid = context.Bids.Where(b => b.BidNumber == idBid).Select(b => b.IdBid).FirstOrDefault(),
                IdActComparingAnalysis = context.Analysis.Where(a => a.ActNumber == long.Parse(ComparingAnalysisActNumber.Text)).Select(a => a.IdActComparingAnalysis).FirstOrDefault(),
                IdActImplementation = context.Implementation.Where(i => i.ActNumber == long.Parse(ActImplementationNumber.Text)).Select(i => i.IdActImplementation).FirstOrDefault(),
            });
            context.SaveChanges();
            foreach (Authors item in AddedAuthorsList.Items)
            {
                context.PatentAuthors.Add(new PatentAuthors
                {
                    IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                        .Select(p => p.IdPatent).FirstOrDefault(),
                    IdAuthor = item.IdAuthor,
                });
            }
            foreach (Agreement item in ListAgreements.Items)
            {
                context.PatentAgreement.Add(new PatentAgreement
                {
                    IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                        .Select(p => p.IdPatent).FirstOrDefault(),
                    IdAgreement = item.IdAgreement,
                });
            }
            foreach (PaymentsDuties item in PaymentsDutiesList.Items)
            {
                context.PatentPaymentsDuties.Add(new PatentPaymentsDuties
                {
                    IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                        .Select(p => p.IdPatent).FirstOrDefault(),
                    IdPayment = item.IdPayDuties,
                });
            }
            foreach (LetterAuthor item in LettersAuthorsList.Items)
            {
                context.PatentLetterAuthors.Add(new PatentLetterAuthor
                {
                    IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                        .Select(p => p.IdPatent).FirstOrDefault(),
                    IdLetter = item.IdLetterAuthor,
                });
            }
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            PatentNumberX.Clear();
            PatentNameX.Clear();
            DatePriorityX.Clear();
            DateRegistrationX.Clear();
            DateFinalX.Clear();
            AddedAuthorsList.Items.Clear();
            AddBidNumber.Items.Clear();
            AgreementPeriod.Clear();
            AgreementPeriod1.Clear();
            ListAgreements.Items.Clear();
            ComparingAnalysisPeriodAct.Clear();
            ComparingAnalysisPeriodAct1.Clear();
            ComparingAnalysisActNumber.Clear();
            ComparingAnalysisDateAct.Clear();
            ActImplementationDate.Clear();
            ActImplementationNumber.Clear();
            LettersAuthorsList.Items.Clear();
            PaymentsDutiesList.Items.Clear();
            PaymentsDutiesPeriod.Clear();
            PaymentsDutiesPeriod1.Clear();
            LetterAuthorPeriod.Clear();
            LetterAuthorPeriod1.Clear();
        }

        private void AddLettersAuthors_Click(object sender, RoutedEventArgs e)
        {
            LetterDate.Visibility = Visibility.Visible;
            LetterAuthorDate.Visibility = Visibility.Visible;
            LetterNumber.Visibility = Visibility.Visible;
            LetterAuthorNumber.Visibility = Visibility.Visible;
            FileLetter.Visibility = Visibility.Visible;
            FileLetterAuthor.Visibility = Visibility.Visible;
            AddLetterAuthors.Visibility = Visibility.Visible;
            CloseLetterAuthors.Visibility = Visibility.Visible;
        }

        private void AgreementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AgreementType.SelectedIndex == 0)
            {
                AgreementName.Text = "Договор за создание";
                AgreementCreation.Visibility = Visibility.Visible;
                ActUse.Visibility = Visibility.Collapsed;
            }
            else
            {
                AgreementName.Text = "Акт об использовании";
                ActUse.Visibility = Visibility.Visible;
                AgreementCreation.Visibility = Visibility.Collapsed;
            }
        }

        private void AddAgreements_Click(object sender, RoutedEventArgs e)
        {
            TextType.Visibility = Visibility.Visible;
            AgreementType.Visibility = Visibility.Visible;
            TextName.Visibility = Visibility.Visible;
            AgreementName.Visibility = Visibility.Visible;
            TextPeriod.Visibility = Visibility.Visible;
            AgreementPeriod.Visibility = Visibility.Visible;
            AgreementPeriod1.Visibility = Visibility.Visible;
            TextNumber.Visibility = Visibility.Visible;
            AgreementNumber.Visibility = Visibility.Visible;
            AddAgreement.Visibility = Visibility.Visible;
            CloseAgreements.Visibility = Visibility.Visible;
        }

        private void CloseAgreements_Click(object sender, RoutedEventArgs e)
        {
            TextType.Visibility = Visibility.Collapsed;
            AgreementType.Visibility = Visibility.Collapsed;
            TextName.Visibility = Visibility.Collapsed;
            AgreementName.Visibility = Visibility.Collapsed;
            TextPeriod.Visibility = Visibility.Collapsed;
            AgreementPeriod.Visibility = Visibility.Collapsed;
            AgreementPeriod1.Visibility = Visibility.Collapsed;
            TextNumber.Visibility = Visibility.Collapsed;
            AgreementNumber.Visibility = Visibility.Collapsed;
            AgreementCreation.Visibility = Visibility.Collapsed;
            ActUse.Visibility = Visibility.Collapsed;
        }

        private void AddBidNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();


            string selectedValueString = AddBidNumber.SelectedItem?.ToString();

            if (long.TryParse(selectedValueString, out long idBid1))
            {
                int idBid = context.Bids.Where(b => b.BidNumber == idBid1)
                    .Select(b => b.IdBid).FirstOrDefault();
                var authorsForBid = context.BidAuthor
                .Where(ba => ba.IdBid == idBid)
                .Join(
                context.Author,
                ba => ba.IdAuthor,
                a => a.IdAuthor,
                (ba, a) => new Authors { FullName = a.FullName }
                )
                .ToList();

                foreach (var author in authorsForBid)
                {
                    AddedAuthorsList.Items.Add(author);
                }

                AddedAuthorsList.Items.Refresh();
            }

            //int idBid = context.Bids.Where(b => b.BidNumber == idBid1)
            //    .Select(b => b.IdBid).FirstOrDefault();
            //var authorsForBid = context.BidAuthor
            //.Where(ba => ba.IdBid == idBid)
            //.Join(
            //context.Author,
            //ba => ba.IdAuthor,
            //a => a.IdAuthor,
            //(ba, a) => new Authors { FullName = a.FullName }
            //)
            //.ToList();

            //foreach (var author in authorsForBid)
            //{
            //    AddedAuthorsList.Items.Add(author);
            //}

            //AddedAuthorsList.Items.Refresh();
        }

        private void AddPayments_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            context.PaymentsDuties.Add(new Models.PaymentsDuties
            {
                StartDate = DateOnly.ParseExact(PaymentsDutiesPeriod.Text, "dd.MM.yyyy"),
                EndDate = DateOnly.ParseExact(PaymentsDutiesPeriod1.Text, "dd.MM.yyyy"),
                DatePay = DateOnly.ParseExact(PaymentsDutiesDate.Text, "dd.MM.yyyy")
            });
            context.SaveChanges();
            int Id = context.PaymentsDuties.Max(b => b.IdPayDuties);
            PaymentsDutiesList.Items.Add(context.PaymentsDuties.Where(b => b.IdPayDuties == Id).FirstOrDefault());
            PaymentsDutiesList.Items.Refresh();
            ClearPayment();
        }

        private void ClosePayment_Click(object sender, RoutedEventArgs e)
        {
            TextDatePayment.Visibility = Visibility.Collapsed;
            PaymentsDutiesDate.Visibility = Visibility.Collapsed;
            AddPayments.Visibility = Visibility.Collapsed;
            ClosePayment.Visibility = Visibility.Collapsed;
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            TextDatePayment.Visibility = Visibility.Visible;
            PaymentsDutiesDate.Visibility = Visibility.Visible;
            AddPayments.Visibility = Visibility.Visible;
            ClosePayment.Visibility = Visibility.Visible;
        }

        private void AddLetterAuthors_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            context.LetterAuthor.Add(new Models.LetterAuthor
            {
                StartDate = DateOnly.ParseExact(LetterAuthorPeriod.Text, "dd.MM.yyyy"),
                EndDate = DateOnly.ParseExact(LetterAuthorPeriod1.Text, "dd.MM.yyyy"),
                DateLetter = DateOnly.ParseExact(LetterAuthorDate.Text, "dd.MM.yyyy"),
                LetterNumber = long.Parse(LetterAuthorNumber.Text),
                File = FileLetterAuthor.Text,
            });
            context.SaveChanges();
            int Id = context.LetterAuthor.Max(b => b.IdLetterAuthor);
            LettersAuthorsList.Items.Add(context.LetterAuthor.Where(b => b.IdLetterAuthor == Id).FirstOrDefault());
            LettersAuthorsList.Items.Refresh();
            ClearLetter();
        }

        private void CloseLetterAuthors_Click(object sender, RoutedEventArgs e)
        {
            LetterDate.Visibility = Visibility.Collapsed;
            LetterAuthorDate.Visibility = Visibility.Collapsed;
            LetterNumber.Visibility = Visibility.Collapsed;
            LetterAuthorNumber.Visibility = Visibility.Collapsed;
            FileLetter.Visibility = Visibility.Collapsed;
            FileLetterAuthor.Visibility = Visibility.Collapsed;
            AddLetterAuthors.Visibility = Visibility.Collapsed;
            CloseLetterAuthors.Visibility = Visibility.Collapsed;
        }

        private void ClearLetter()
        {
            LetterAuthorDate.Clear();
            LetterAuthorNumber.Clear();
            FileLetterAuthor.Clear();
        }
        private void ClearPayment()
        {
            PaymentsDutiesDate.Clear();
        }
    }

}
