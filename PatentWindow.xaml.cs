using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DashaD.Context;
using DashaD.Models;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Xml.Linq;
using Path = System.IO.Path;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для PatentWindow.xaml
    /// </summary>
    public partial class PatentWindow : System.Windows.Window
    {
        private int _idPatent;
        private DataGrid _grid;
        public PatentWindow(int idPatent, DataGrid data, bool isAdm)
        {
            _grid = data;
            _idPatent = idPatent;
            InitializeComponent();
            UpdatePatent.IsEnabled = isAdm;
            SetDataOnControlls();
        }

        private void SetDataOnControlls()
        {
            using ApplicationContext context = new();
            Patents patent = context.Patent.First(p => p.IdPatent == _idPatent);
            PatentNameX.Text = patent.PatentName;
        }

        private void AddAgreement_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
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
                IdActUse = context.ActUses.Where(b => b.ActNumber == long.Parse(ActUseNumber.Text))
                .Select(b => b.IdActUse).FirstOrDefault()
            });
            context.SaveChanges();

            int agreement = context.Agreement.Max(b => b.IdAgreement);
            Agreement agr = context.Agreement.Where(b => b.IdAgreement == agreement).FirstOrDefault();

            if (CheckAgreement(agr) == false)
            {
                ListAgreements.Items.Add(agreement);
                ListAgreements.Items.Refresh();
            }
        }

        private bool CheckAgreement(Agreement agr)
        {
            ApplicationContext context = new ApplicationContext();
            bool check = false;
            foreach (Agreement el in context.Agreement)
            {
                if (el.IdAgreement == agr.IdAgreement)
                {
                    check = true;
                }
            }
            return check;
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
            ActUse.Visibility = Visibility.Collapsed;
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

        private void AgreementType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AgreementType.SelectedIndex == 0)
            {
                AgreementName.Text = "Акт об использовании";
                ActUse.Visibility = Visibility.Visible;
            }
        }

        private void ChangePatent_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new();
            Patents patent = context.Patent.First(p => p.IdPatent == _idPatent);
            var authorsForPatent = context.PatentAuthors
            .Where(pa => pa.IdPatent == _idPatent)
            .Join(
            context.Author,
            pa => pa.IdAuthor,
            a => a.IdAuthor,
            (pa, a) => new Authors { FullName = a.FullName }
            )
            .ToList();
            foreach (var author in authorsForPatent)
            {
                AddedAuthorsList.Items.Add(author);
            }
            AddedAuthorsList.Items.Refresh();

            patent.PatentName = PatentNameX.Text;
            patent.Number = long.Parse(PatentNumberX.Text);
            patent.DatePriority = DateOnly.ParseExact(DatePriorityX.Text, "dd.MM.yyyy");
            patent.DateRegistration = DateOnly.ParseExact(DateRegistrationX.Text, "dd.MM.yyyy");
            patent.DateFinal = DateOnly.ParseExact(DateFinalX.Text, "dd.MM.yyyy");
            patent.IdBid = context.Bids.Where(b => b.BidNumber == long.Parse(AddBidNumber.Text)).Select(b => b.IdBid).FirstOrDefault();
            patent.IdActComparingAnalysis = context.Analysis.Where(a => a.ActNumber == long.Parse(ComparingAnalysisActNumber.Text)).Select(a => a.IdActComparingAnalysis).FirstOrDefault();
            patent.IdActImplementation = context.Implementation.Where(i => i.ActNumber == long.Parse(ActImplementationNumber.Text)).Select(i => i.IdActImplementation).FirstOrDefault();
            // PatentNameX.Text = patent.PatentName;
            //AddBidNumber.Text = patent.IdBid.ToString();
            //AddBidNumber.Text = patent.IdBid.ToString();
            //AddBidNumber.Text = patent.IdBid.ToString();
            //AddBidNumber.Text = patent.IdBid.ToString();

            context.SaveChanges();
            PatentsPage.View(_grid);
        }


        private void BackPatent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            // Опционально: открываем главное окно
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Document", "patent.docx");
            MessageBox.Show(templatePath);

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Шаблон не найден!");
                return;
            }

            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;

            Document doc = wordApp.Documents.Open(templatePath);
            doc.Activate();

            //ReplacePlaceholder(doc, "<НОМЕР ЗАЯВКИ>", BidNumber.Text);
            //string authorsList = GetAuthorsFromListBox();
            //ReplacePlaceholder(doc, "<ФИО>", authorsList);
            //ReplacePlaceholder(doc, "<ФОРМУЛА>", BidFormula.Text);
            //ReplacePlaceholder(doc, "<ОПИСАНИЕ>", BidDescription.Text);
            //ReplacePlaceholder(doc, "<РЕФЕРАТ>", BidReport.Text



            string tempFilePath = Path.GetTempFileName() + ".docx";
            doc.SaveAs2(tempFilePath);

            doc.PrintOut(); //это точно надо

            doc.Close();
            wordApp.Quit();

            File.Delete(tempFilePath);
        }

        private void ReplacePlaceholder(Document doc, string placeholder, string value)
        {
            var range = doc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(
                FindText: placeholder,
                ReplaceWith: value,
                Replace: WdReplace.wdReplaceAll);
        }
    }
}
