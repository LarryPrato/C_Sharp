using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GFC_V0
{
    /// <summary>
    /// Lógica interna para SolvencyRatios.xaml
    /// </summary>
    public partial class SolvencyRatios : Window
    {
        public SolvencyRatios()
        {
            InitializeComponent();
        }

        ///////////////////////////
        public static DataTable FilledTable(string tablename)
        {
            BLogic BL_Instancia = new BLogic();
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = BL_Instancia.ObtenerNumeroMes(mesCorte);
            DataTable inputOrdenar = new DataTable();
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo asc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            return inputOrdenar;
        }

        public static DataTable FilledTableI(string tablename)
        {
            BLogic BL_Instancia = new BLogic();
            DataTable inputOrdenar = new DataTable();
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            return inputOrdenar;
        }
        ///////////////////////////

        private void DebtToActive_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo3.Text = "Anual";
                showColumnChart();
                void showColumnChart()
                {
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int last = inputOrdenar.Rows.Count - 1;
                    double totDebt = Convert.ToDouble(inputOrdenar.Rows[last][(24)]);
                    double totAsset = Convert.ToDouble(inputOrdenar.Rows[last][(14)]);
                    double delta = totAsset - totDebt;
                    ((PieSeries)DebtToActive.Series[0]).ItemsSource =
                    new KeyValuePair<string, double>[]{
                    new KeyValuePair<string, double>("A", totDebt),
                    new KeyValuePair<string, double>("B", delta) };
                    DebtToActive.UpdateLayout();
                }
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-340);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                showColumnChart();
                void showColumnChart()
                {
                    double totDebt = Convert.ToDouble(Transition.Rows[0][(24)]);
                    double totAsset = Convert.ToDouble(Transition.Rows[0][(14)]);
                    double delta = totAsset - totDebt;
                    ((PieSeries)DebtToActive.Series[0]).ItemsSource =
                    new KeyValuePair<string, double>[]{
                    new KeyValuePair<string, double>("A", totDebt),
                    new KeyValuePair<string, double>("B", delta) };
                    DebtToActive.UpdateLayout();                    
                }
            }
        }

        private void LblDebtToAsset_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = FilledTable("inputOrdenar");
                int last = inputOrdenar.Rows.Count - 1;
                double totDebt = Convert.ToDouble(inputOrdenar.Rows[last][(24)]);
                double totAsset = Convert.ToDouble(inputOrdenar.Rows[last][(14)]);
                double Cover = totDebt / totAsset;
                LblDebtToAsset.Content = Cover.ToString("P");
            }
            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-340);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                double totDebt = Convert.ToDouble(Transition.Rows[0][(24)]);
                double totAsset = Convert.ToDouble(Transition.Rows[0][(14)]);
                double Cover = totDebt / totAsset;
                LblDebtToAsset.Content = Cover.ToString("P");
            }
        }

        private void GraphColumnRazonEndeudamiento_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int fila = 0;
                    foreach (DataRow dc in inputOrdenar.Rows)
                    {
                        if (fila <= inputOrdenar.Rows.Count - 1)
                        {
                            //Razon de endeudamiento
                            double totDebt = Convert.ToDouble(inputOrdenar.Rows[fila][(24)]);
                            double totAsset = Convert.ToDouble(inputOrdenar.Rows[fila][(14)]);
                            double r;
                            r = (totDebt / totAsset);
                            double R = Math.Round(r, 4);
                            string X = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            fila++;
                        }
                    }
                    GraphColumnRazonEndeudamiento.DataContext = kvp;
                    GraphColumnRazonEndeudamiento.UpdateLayout();
                }
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-320);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    //txtTodele.Text = Convert.ToString(Transition.Rows.Count);
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila >= 0)
                        {
                            //Razon de endeudamiento
                            double totDebt = Convert.ToDouble(Transition.Rows[fila][(24)]);
                            double totAsset = Convert.ToDouble(Transition.Rows[fila][(14)]);
                            double r;
                            r = (totDebt / totAsset);
                            double R = Math.Round(r, 4);
                            string X = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            fila--;
                        }
                    }
                    GraphColumnRazonEndeudamiento.DataContext = kvp;
                    GraphColumnRazonEndeudamiento.UpdateLayout();
                }
            }
        }

        private void GraphColumnRazonDeudaPatrimonio_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int fila = 0;
                    foreach (DataRow dc in inputOrdenar.Rows)
                    {
                        if (fila <= inputOrdenar.Rows.Count - 1)
                        {
                            //Razon deuda/patrimonio
                            double totDebt = Convert.ToDouble(inputOrdenar.Rows[fila][(24)]);
                            double totEquity = Convert.ToDouble(inputOrdenar.Rows[fila][(27)]);
                            double r;
                            r = (totDebt / totEquity);
                            double R = Math.Round(r, 4);
                            string X = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            fila++;
                        }
                    }
                    GraphColumnRazonDeudaPatrimonio.DataContext = kvp;
                    GraphColumnRazonDeudaPatrimonio.UpdateLayout();
                }
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-320);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    //txtTodele.Text = Convert.ToString(Transition.Rows.Count);
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila >= 0)
                        {
                            //Razon deuda/patrimonio
                            double totDebt = Convert.ToDouble(Transition.Rows[fila][(24)]);
                            double totEquity = Convert.ToDouble(Transition.Rows[fila][(27)]);
                            double r;
                            r = (totDebt / totEquity);
                            double R = Math.Round(r, 4);
                            string X = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            fila--;
                        }
                    }
                    GraphColumnRazonDeudaPatrimonio.DataContext = kvp;
                    GraphColumnRazonDeudaPatrimonio.UpdateLayout();
                }
            }
        }

        private void DebtToEquity_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo3.Text = "Anual";
                showColumnChart();
                void showColumnChart()
                {
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int last = inputOrdenar.Rows.Count - 1;
                    double totDebt = Convert.ToDouble(inputOrdenar.Rows[last][(24)]);
                    double totEquity = Convert.ToDouble(inputOrdenar.Rows[last][(27)]);
                    double control = totDebt / totEquity;
                    if (control <= 1)
                    {
                        double delta = totEquity - totDebt;
                        ((PieSeries)DebtToEquity.Series[0]).ItemsSource =
                        new KeyValuePair<string, double>[]{
                        new KeyValuePair<string, double>("A", totDebt),
                        new KeyValuePair<string, double>("B", delta) };
                        DebtToEquity.UpdateLayout();
                    }
                }
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-320);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                showColumnChart();
                void showColumnChart()
                {
                    double totDebt = Convert.ToDouble(Transition.Rows[0][(24)]);
                    double totEquity = Convert.ToDouble(Transition.Rows[0][(27)]);
                    double control = totDebt / totEquity;
                    if (control <= 1)
                    {
                        double delta = totEquity - totDebt;
                        ((PieSeries)DebtToEquity.Series[0]).ItemsSource =
                        new KeyValuePair<string, double>[]{
                        new KeyValuePair<string, double>("A", totDebt),
                        new KeyValuePair<string, double>("B", delta) };
                        DebtToEquity.UpdateLayout();
                    }
                }
            }
        }

        private void LblDebtToEquity_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = FilledTable("inputOrdenar");
                int last = inputOrdenar.Rows.Count - 1;
                double totDebt = Convert.ToDouble(inputOrdenar.Rows[last][(24)]);
                double totEquity = Convert.ToDouble(inputOrdenar.Rows[last][(27)]);
                double Cover = totDebt / totEquity;
                LblDebtToEquity.Content = Cover.ToString("P");
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo3.Text = "Mensual";
                DataTable inputOrdenarI = FilledTableI("inputOrdenarI");
                string fecha = inputOrdenarI.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-340);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
                DataTable Transition = new DataTable();
                for (int i = 0; i < inputOrdenarI.Columns.Count; i++)
                {
                    Transition.Columns.Add(inputOrdenarI.Columns[i].ColumnName);
                }
                for (int i = 0; i < inputOrdenarI.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(inputOrdenarI.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        Transition.ImportRow(inputOrdenarI.Rows[i]);
                    }
                }
                double totDebt = Convert.ToDouble(Transition.Rows[0][(24)]);
                double totEquity = Convert.ToDouble(Transition.Rows[0][(27)]);
                double Cover = totDebt / totEquity;
                LblDebtToEquity.Content = Cover.ToString("P");
            }
        }

        private void btnCloseIS_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}
