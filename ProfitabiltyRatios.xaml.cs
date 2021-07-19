using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
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

namespace GFC_V0
{
    /// <summary>
    /// Lógica interna para ProfitabiltyRatios.xaml
    /// </summary>
    public partial class ProfitabiltyRatios : Window
    {
        public ProfitabiltyRatios()
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

        private void GraphProfitability_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo4.Text = "Anual";
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    List<KeyValuePair<DateTime, double>> kvp1 = new List<KeyValuePair<DateTime, double>>();
                    List<KeyValuePair<DateTime, double>> kvp2 = new List<KeyValuePair<DateTime, double>>();
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int fila = 0;
                    foreach (DataRow dc in inputOrdenar.Rows)
                    {
                        if (fila <= inputOrdenar.Rows.Count - 1)
                        {
                            //Margen bruto
                            double grossProfit = Convert.ToDouble(inputOrdenar.Rows[fila][(31)]);
                            double ventas = Convert.ToDouble(inputOrdenar.Rows[fila][(29)]);
                            double r;
                            r = (grossProfit / ventas);
                            double R = Math.Round(r, 4);
                            string X = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Margen operativo
                            double ebitda = Convert.ToDouble(inputOrdenar.Rows[fila][(35)]);
                            double r1;
                            r1 = (ebitda / ventas);
                            double R1 = Math.Round(r1, 4);
                            string X1 = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Margen neto
                            double netIncome = Convert.ToDouble(inputOrdenar.Rows[fila][(44)]);
                            double r2;
                            r2 = netIncome / ventas;
                            double R2 = Math.Round(r2, 4);
                            string X2 = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX2 = Convert.ToDateTime(X2);
                            kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                            fila++;
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    GraphProfitability.DataContext = dataSourceList;
                    GraphProfitability.UpdateLayout();
                }//+++ Info for dashboard ++++++++++++++++++++++++++Fin
            }
            else////tipoSerie == "mes"
            {
                txtGetTipo4.Text = "Mensual";
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
                    List<KeyValuePair<DateTime, double>> kvp1 = new List<KeyValuePair<DateTime, double>>();
                    List<KeyValuePair<DateTime, double>> kvp2 = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila >= 0)
                        {
                            //Margen bruto
                            double grossProfit = Convert.ToDouble(Transition.Rows[fila][(31)]);
                            double ventas = Convert.ToDouble(Transition.Rows[fila][(29)]);
                            double r;
                            r = (grossProfit / ventas);
                            double R = Math.Round(r, 4);
                            string X = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Margen operativo
                            double ebitda = Convert.ToDouble(Transition.Rows[fila][(35)]);
                            double r1;
                            r1 = (ebitda / ventas);
                            double R1 = Math.Round(r1, 4);
                            string X1 = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Margen neto
                            double netIncome = Convert.ToDouble(Transition.Rows[fila][(44)]);
                            double r2;
                            r2 = netIncome / ventas;
                            double R2 = Math.Round(r2, 4);
                            string X2 = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX2 = Convert.ToDateTime(X2);
                            kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                            fila--;
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    GraphProfitability.DataContext = dataSourceList;
                    GraphProfitability.UpdateLayout();
                }
            }
        }

        private void GraphROAROE_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo4.Text = "Anual";
                showColumnChart();
                void showColumnChart()
                {
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    List<KeyValuePair<DateTime, double>> kvp1 = new List<KeyValuePair<DateTime, double>>();
                    DataTable inputOrdenar = FilledTable("inputOrdenar");
                    int fila = 0;
                    foreach (DataRow dc in inputOrdenar.Rows)
                    {
                        if (fila <= inputOrdenar.Rows.Count - 1)
                        {
                            if (fila + 1 < inputOrdenar.Rows.Count)
                            {
                                //ROA
                                double netIncome = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(44)]);
                                double totAsset0 = Convert.ToDouble(inputOrdenar.Rows[fila][(14)]);
                                double totAsset1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(14)]);
                                double r;
                                r = (netIncome / ((totAsset0 + totAsset1) / 2));
                                double R = Math.Round(r, 4);
                                string X = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX = Convert.ToDateTime(X);
                                kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                                //ROE
                                double equity0 = Convert.ToDouble(inputOrdenar.Rows[fila][(27)]);
                                double equity1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(27)]);
                                double r1;
                                r1 = (netIncome / ((equity0 + equity1) / 2));
                                double R1 = Math.Round(r1, 4);
                                string X1 = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX1 = Convert.ToDateTime(X1);
                                kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                                fila++;
                            }
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    GraphROAROE.DataContext = dataSourceList;
                    GraphROAROE.UpdateLayout();
                }//+++ Info for dashboard ++++++++++++++++++++++++++Fin
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo4.Text = "Mensual";
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
                    List<KeyValuePair<DateTime, double>> kvp = new List<KeyValuePair<DateTime, double>>();
                    List<KeyValuePair<DateTime, double>> kvp1 = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila > 0)
                        {
                            //ROA
                            double netIncome = Convert.ToDouble(Transition.Rows[fila - 1][(44)]);
                            double totAsset0 = Convert.ToDouble(Transition.Rows[fila][(14)]);
                            double totAsset1 = Convert.ToDouble(Transition.Rows[fila - 1][(14)]);
                            double r;
                            r = (netIncome / ((totAsset0 + totAsset1) / 2));
                            double R = Math.Round(r, 4);
                            string X = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //ROE
                            double equity0 = Convert.ToDouble(Transition.Rows[fila][(27)]);
                            double equity1 = Convert.ToDouble(Transition.Rows[fila - 1][(27)]);
                            double r1;
                            r1 = (netIncome / ((equity0 + equity1) / 2));
                            double R1 = Math.Round(r1, 4);
                            string X1 = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            fila--;
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    GraphROAROE.DataContext = dataSourceList;
                    GraphROAROE.UpdateLayout();
                }
            }
        }

        private void btnCloseIR_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}
