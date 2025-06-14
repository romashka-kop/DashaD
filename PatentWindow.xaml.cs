﻿using System;
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
using Microsoft.Data.SqlClient;

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

            var authorsForPatent = context.PatentAuthors
                .Where(pa => pa.IdPatent == _idPatent)
                .Join(
                context.Author,
                pa => pa.IdAuthor,
                a => a.IdAuthor,
                (pa, a) => new Authors { FullName = a.FullName }
                ).ToList();
            foreach (var author in authorsForPatent)
            {
                AddedAuthorsList.Items.Add(author);
            }
            AddedAuthorsList.Items.Refresh();

            var agreementForPatent = context.PatentAgreement
                .Where(pa => pa.IdPatent == _idPatent)
                .Join(
                context.Agreement,
                pa => pa.IdAgreement,
                a => a.IdAgreement,
                (pa, a) => new Agreement { AgreementName = a.AgreementName }
                ).ToList();
            foreach (var agreement in agreementForPatent)
            {
                ListAgreements.Items.Add(agreement);
            }
            ListAgreements.Items.Refresh();

            var paymentsDutiesForPatent = context.PatentPaymentsDuties
                .Where(pp => pp.IdPatent == _idPatent)
                .Join(
                context.PaymentsDuties,
                pp => pp.IdPayment,
                p => p.IdPayDuties,
                (pp, p) => new PaymentsDuties { DatePay = p.DatePay }
                ).ToList();
            foreach (var paymentDuties in paymentsDutiesForPatent)
            {
                PaymentsDutiesList.Items.Add(paymentDuties);
            }
            PaymentsDutiesList.Items.Refresh();

            PatentNameX.Text = patent.PatentName;
            PatentNumberX.Text = patent.Number.ToString();
            DatePriorityX.Text = patent.DatePriority.ToString();
            DateRegistrationX.Text = patent.DateRegistration.ToString();
            DateFinalX.Text = patent.DateFinal.ToString();
            AddBidNumber.Text = patent.IdBid.ToString();
            ComparingAnalysisActNumber.Text = patent.IdActComparingAnalysis.ToString();
            ActImplementationNumber.Text = patent.IdActImplementation.ToString();
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

            ListAgreements.Items.Add(context.Agreement.Where(a => a.IdAgreement == agreement).FirstOrDefault());
            ListAgreements.Items.Refresh();
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

        private bool CheckPaymentsDuties(PaymentsDuties pd)
        {
            ApplicationContext context = new ApplicationContext();
            bool check = false;
            foreach (PaymentsDuties el in context.PaymentsDuties)
            {
                if (el.IdPayDuties == pd.IdPayDuties)
                {
                    check = true;
                }
            }
            return check;
        }

        private bool CheckLetterAuthors(LetterAuthor la)
        {
            ApplicationContext context = new ApplicationContext();
            bool check = false;
            foreach (LetterAuthor el in context.LetterAuthor)
            {
                if (el.IdLetterAuthor == la.IdLetterAuthor)
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

            int paymentDuties = context.PaymentsDuties.Max(p => p.IdPayDuties);
            PaymentsDuties pd = context.PaymentsDuties.Where(p => p.IdPayDuties == paymentDuties).FirstOrDefault();
            foreach (PaymentsDuties item in PaymentsDutiesList.Items)
            {
                if (CheckPaymentsDuties(pd) == false)
                {
                    context.PatentPaymentsDuties.Add(new PatentPaymentsDuties
                    {
                        IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                                           .Select(p => p.IdPatent).FirstOrDefault(),
                        IdPayment = item.IdPayDuties,
                    });
                }
            }

            int letterAuthors = context.LetterAuthor.Max(l => l.IdLetterAuthor);
            LetterAuthor la = context.LetterAuthor.Where(l => l.IdLetterAuthor == letterAuthors).FirstOrDefault();
            foreach (LetterAuthor item in LettersAuthorsList.Items)
            {
                if (CheckLetterAuthors(la) == false)
                {
                    context.PatentLetterAuthors.Add(new PatentLetterAuthor
                    {
                        IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                                            .Select(p => p.IdPatent).FirstOrDefault(),
                        IdLetter = item.IdLetterAuthor,
                    });
                }
            }

            int agreement = context.Agreement.Max(b => b.IdAgreement);
            Agreement agr = context.Agreement.Where(b => b.IdAgreement == agreement).FirstOrDefault();

            foreach (Agreement item in ListAgreements.Items)
            {
                if (CheckAgreement(agr) == false)
                {
                    context.PatentAgreement.Add(new PatentAgreement
                    {
                        IdPatent = context.Patent.Where(p => p.Number == long.Parse(PatentNumberX.Text))
                        .Select(p => p.IdPatent).FirstOrDefault(),
                        IdAgreement = item.IdAgreement,
                    });
                }
            }

            context.SaveChanges();
            PatentsPage.View(_grid);
            this.Close();
        }


        private void BackPatent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

            ReplacePlaceholder(doc, "<НОМЕР ПАТЕНТА>", PatentNumberX.Text);
            ReplacePlaceholder(doc, "<НАЗВАНИЕ ПАТЕНТА>", PatentNameX.Text);
            string authorsRaw = GetAuthorsFromListBox();
            string authorsList = authorsRaw.Replace("\r\n", ", ").Replace("\n", ", ").Replace("\r", ", ");
            ReplacePlaceholder(doc, "<ФИО>", authorsList);
            ReplacePlaceholder(doc, "<НОМЕР ЗАЯВКИ>", AddBidNumber.Text);
            ReplacePlaceholder(doc, "<ДАТА ПРИОРИТЕТ>", DatePriorityX.Text);
            ReplacePlaceholder(doc, "<ДАТА РЕГ>", DateRegistrationX.Text);
            ReplacePlaceholder(doc, "<ДАТА СРОК>", DateFinalX.Text);
            var bidDetails = GetBidDetails(AddBidNumber.Text);
            ReplacePlaceholder(doc, "<ФОРМУЛА>", bidDetails.Formula);
            ReplacePlaceholder(doc, "<ОПИСАНИЕ>", bidDetails.Description);
            ReplacePlaceholder(doc, "<РЕФЕРАТ>", bidDetails.Report);

            string tempFilePath = Path.GetTempFileName() + ".docx";
            doc.SaveAs2(tempFilePath);

            doc.PrintOut();

            doc.Close();
            wordApp.Quit();

            File.Delete(tempFilePath);
        }

        public (string Formula, string Description, string Report) GetBidDetails(string idBid)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string formula = "";
            string description = "";
            string report = "";

            string query = "SELECT Formula, Description, Report FROM BidDetails WHERE IdBid = @IdBid";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdBid", idBid);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            formula = reader["Formula"]?.ToString() ?? "";
                            description = reader["Description"]?.ToString() ?? "";
                            report = reader["Report"]?.ToString() ?? "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении данных: " + ex.Message);
            }

            return (formula, description, report);
        }


        private string GetAuthorsFromListBox()
        {
            var authors = new List<string>();

            foreach (var item in AddedAuthorsList.Items)
            {
                if (item is Authors author)
                {
                    authors.Add(author.FullName);
                }
            }

            return string.Join(Environment.NewLine, authors);
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
