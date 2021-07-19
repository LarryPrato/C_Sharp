using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows;

namespace GFC_V0
{
    /// <summary>
    /// Lógica interna para LiquidityRatios.xaml
    /// </summary>
    public partial class LiquidityRatios : Window
    {
        BLogic BL_Instancia = new BLogic();
        public LiquidityRatios()
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

        private void graphRazonCorrienteVarios_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie== "Anual")
            {
                txtGetTipo.Text = "Anual";
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
                            //Razon circulante
                            double CurrentAsset = Convert.ToDouble(inputOrdenar.Rows[fila][(6)]);
                            double CurrentLiability = Convert.ToDouble(inputOrdenar.Rows[fila][(21)]);
                            double r;
                            r = (CurrentAsset / CurrentLiability);
                            double R = Math.Round(r, 2);
                            string X = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Prueba ácida
                            double efectivo = Convert.ToDouble(inputOrdenar.Rows[fila][(1)]);
                            double invtemp = Convert.ToDouble(inputOrdenar.Rows[fila][(2)]);
                            double cxc = Convert.ToDouble(inputOrdenar.Rows[fila][(3)]);
                            double currentLiability = Convert.ToDouble(inputOrdenar.Rows[fila][(21)]);
                            double r1;
                            r1 = ((efectivo + invtemp + cxc) / currentLiability);
                            double R1 = Math.Round(r1, 2);
                            string X1 = (inputOrdenar.Rows[fila][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Indice de liquidez
                            double r2;
                            r2 = ((efectivo + invtemp) / currentLiability);
                            double R2 = Math.Round(r2, 2);
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
                    graphRazonCorrienteVarios.DataContext = dataSourceList;
                    graphRazonCorrienteVarios.UpdateLayout();
                }//+++ Info for dashboard ++++++++++++++++++++++++++Fin
            }
            else////tipoSerie == "mes"
            {
                txtGetTipo.Text = "Mensual";
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
                    int fila = Transition.Rows.Count-1;
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila >=   0)
                        {
                            //Razon circulante
                            double CurrentAsset = Convert.ToDouble(Transition.Rows[fila][(6)]);
                            double CurrentLiability = Convert.ToDouble(Transition.Rows[fila][(21)]);
                            double r;
                            r = (CurrentAsset / CurrentLiability);
                            double R = Math.Round(r, 2);
                            string X = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Prueba ácida
                            double efectivo = Convert.ToDouble(Transition.Rows[fila][(1)]);
                            double invtemp = Convert.ToDouble(Transition.Rows[fila][(2)]);
                            double cxc = Convert.ToDouble(Transition.Rows[fila][(3)]);
                            double currentLiability = Convert.ToDouble(Transition.Rows[fila][(21)]);
                            double r1;
                            r1 = ((efectivo + invtemp + cxc) / currentLiability);
                            double R1 = Math.Round(r1, 2);
                            string X1 = (Transition.Rows[fila][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Indice de liquidez
                            double r2;
                            r2 = ((efectivo + invtemp) / currentLiability);
                            double R2 = Math.Round(r2, 2);
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
                    graphRazonCorrienteVarios.DataContext = dataSourceList;
                    graphRazonCorrienteVarios.UpdateLayout();
                }
            }
        }

        private void graphCashFlow_Loaded(object sender, RoutedEventArgs e)
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
                            if (fila + 1 < inputOrdenar.Rows.Count)
                            {
                                double costos = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(30)]);
                                double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila][(4)]);
                                double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(4)]);
                                double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias
                                double venta = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(29)]);
                                double cxc0 = Convert.ToDouble(inputOrdenar.Rows[fila][(3)]);
                                double cxc1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(3)]);
                                double compras = Inv1 + costos - Inv0;
                                double cxp0 = Convert.ToDouble(inputOrdenar.Rows[fila][(15)]);
                                double cxp1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(15)]);
                                double r = 0;
                                r = ((dias / (costos / ((Inv0 + Inv1) / 2))) + (dias / (venta / ((cxc0 + cxc1) / 2))) - (dias / (compras / ((cxp0 + cxp1) / 2))));
                                double R = Math.Round(r, 2);
                                string X = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX = Convert.ToDateTime(X);
                                kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                                fila++;
                            }
                        }
                    }
                    graphCashFlow.DataContext = kvp;
                    graphCashFlow.UpdateLayout();
                }//+++ Info for dashboard Ciclo de caja++++++++++++++++++++++++++Fin
            }
            else////tipoSerie == "mes"
            {
                txtGetTipo.Text = "Mensual";
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
                    int fila = Transition.Rows.Count - 1;
                    //txtTodele.Text = Convert.ToString(Transition.Rows.Count);
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila >  0)
                        {
                            double costos = Convert.ToDouble(Transition.Rows[fila - 1][(30)]);
                            double Inv0 = Convert.ToDouble(Transition.Rows[fila][(4)]);
                            double Inv1 = Convert.ToDouble(Transition.Rows[fila - 1][(4)]);
                            double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias
                            double venta = Convert.ToDouble(Transition.Rows[fila - 1][(29)]);
                            double cxc0 = Convert.ToDouble(Transition.Rows[fila][(3)]);
                            double cxc1 = Convert.ToDouble(Transition.Rows[fila - 1][(3)]);
                            double compras = Inv1 + costos - Inv0;
                            double cxp0 = Convert.ToDouble(Transition.Rows[fila][(15)]);
                            double cxp1 = Convert.ToDouble(Transition.Rows[fila - 1][(15)]);
                            double r = 0;
                            r = ((dias / (costos / ((Inv0 + Inv1) / 2))) + (dias / (venta / ((cxc0 + cxc1) / 2))) - (dias / (compras / ((cxp0 + cxp1) / 2))));
                            double R = Math.Round(r, 2);
                            string X = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            fila--;
                        }
                    }
                    graphCashFlow.DataContext = kvp;
                    graphCashFlow.UpdateLayout();
                }
            }
        }

        private void btnCloseIL_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        /*private void TodeleteGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable inputOrdenar = FilledTableI("inputOrdenar");
            string fecha = inputOrdenar.Rows[1]["Periodo"].ToString();
            DateTime LastDate = DateTime.Parse(fecha);
            DateTime limite = LastDate.AddDays(-366);
            DataTable Transition = new DataTable();
            for (int i = 0; i < inputOrdenar.Columns.Count; i++)
            {
                Transition.Columns.Add(inputOrdenar.Columns[i].ColumnName);
            }
            for (int i = 0; i < inputOrdenar.Rows.Count; i++)
            {
                DateTime control = DateTime.Parse(inputOrdenar.Rows[i][0].ToString());
                if (control > limite)
                {
                    Transition.ImportRow(inputOrdenar.Rows[i]);
                }
            }
            TodeleteGrid.DataContext = Transition.DefaultView;
        }
        */
    }
}
