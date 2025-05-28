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

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AddPatentWindow.xaml
    /// </summary>
    public partial class AddPatentWindow : Window
    {
        public AddPatentWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ApplicationContext context = new();
            foreach(var el in context.Bids)
            {
                AddBidNumber.Items.Add(el.BidNumber);
            }
        }

        private void AddAgreement_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            context.AgreementCreation.Add(new Models.AgreementCreation
            {
                AgreementNumber = long.Parse(AgreementCreationNumber.Text),
                DateAgreement = DateOnly.ParseExact(AgreementCreationDate.Text, "dd.MM.yyyy"),
                File = AgreementCreationFile.Text
            });
            context.ActUses.Add(new Models.ActUse
            {
                ActNumber = long.Parse(ActUseNumber.Text),
                DateActUse = DateOnly.ParseExact(ActUseDate.Text, "dd.MM.yyyy"),
                StartDate = DateOnly.ParseExact(ActUsePeriod.Text, "dd.MM.yyyy"),
                EndDate = DateOnly.ParseExact(ActUsePeriod1.Text, "dd.MM.yyyy"),
                File = ActUseFile.Text
            });
            context.Agreement.Add(new Models.Agreement 
            { 
                Type = (Models.Agreement.TypesAgreement)AgreementType.SelectedIndex,
                AgreementName = AgreementName.Text,
                StartDate = DateOnly.ParseExact(AgreementPeriod.Text, "dd.MM.yyyy"),
                EndDate = DateOnly.ParseExact(AgreementPeriod1.Text, "dd.MM.yyyy"),
                AgreementNumber = long.Parse(AgreementNumber.Text),
                DateAgreement = DateOnly.ParseExact(AgreementDate.Text, "dd.MM.yyyy"),
                IdAgreementCreation = context.AgreementCreation.Where(b => b.AgreementNumber == long.Parse(AgreementCreationNumber.Text))
                .Select(b => b.IdAgreementCreation).FirstOrDefault(),
                IdActUse = context.ActUses.Where(b => b.ActNumber == long.Parse(ActUseNumber.Text))
                .Select(b => b.IdActUse).FirstOrDefault()
            });
            context.SaveChanges();
            var agreement = context.Agreement.Max(b => b.IdAgreement);
            ListAgreements.Items.Add(agreement);
            ListAgreements.Items.Refresh();

            ClearTextBoxes();
        }
        private void AddPatent_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
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
            context.Patent.Add(new Models.Patents
            {
                Number = Convert.ToInt32(PatentNumberX.Text),
                PatentName = PatentNameX.Text,
                DatePriority = DateOnly.ParseExact(DatePriorityX.Text, "dd.MM.yyyy"),
                DateRegistration = DateOnly.ParseExact(DateRegistrationX.Text, "dd.MM.yyyy"),
                DateFinal = DateOnly.ParseExact(DateFinalX.Text, "dd.MM.yyyy"),
                IdBid = context.Bids.Where(b => b.BidNumber == long.Parse(AddBidNumber.SelectedItem.ToString())).Select(b => b.IdBid).FirstOrDefault(),
                IdActComparingAnalysis = context.Analysis.Where(a => a.ActNumber == long.Parse(ComparingAnalysisActNumber.Text)).Select(a => a.IdActComparingAnalysis).FirstOrDefault(),
                IdActImplementation = context.Implementation.Where(i => i.ActNumber == long.Parse(ActImplementationNumber.Text)).Select(i => i.IdActImplementation).FirstOrDefault(),
            });
            context.SaveChanges();
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
            ListAgreements.Items.Clear();
            ComparingAnalysisPeriodAct.Clear();
            ComparingAnalysisPeriodAct1.Clear();
            ComparingAnalysisActNumber.Clear();
            ComparingAnalysisDateAct.Clear();
            ActImplementationDate.Clear();
            ActImplementationNumber.Clear();
            LettersAuthorsList.Items.Clear();
            PaymentsDutiesList.Items.Clear();
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

            int idBid = context.Bids.Where(b=> b.BidNumber == long.Parse(AddBidNumber.SelectedItem.ToString()))
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
            PaymentsDutiesList.Items.Add(context.PaymentsDuties.Where(b => b.IdPayDuties == Id)
                .Select(b => b.DatePay).FirstOrDefault());
            PaymentsDutiesList.Items.Refresh();
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
            LettersAuthorsList.Items.Add(context.LetterAuthor.Where(b => b.IdLetterAuthor == Id)
                .Select(b => b.LetterNumber).FirstOrDefault());
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
    }
}
