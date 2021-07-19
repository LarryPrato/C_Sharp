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
    /// Lógica interna para ActivityRatios.xaml
    /// </summary>
    public partial class ActivityRatios : Window
    {
        BLogic BL_Instancia = new BLogic();
        public ActivityRatios()
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

        private void graphIndicesActividadVarios_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo2.Text = "Anual";
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
                            if (fila + 1 < inputOrdenar.Rows.Count)
                            {
                                //Rotacion de inventarios
                                double costos = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(30)]);
                                double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila][(4)]);
                                double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(4)]);
                                double r = 0;
                                r = ((costos / ((Inv0 + Inv1) / 2)));
                                double R = Math.Round(r, 2);
                                string X = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX = Convert.ToDateTime(X);
                                kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                                //Rotacion de CxC
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(29)]);
                                double cxc0 = Convert.ToDouble(inputOrdenar.Rows[fila][(3)]);
                                double cxc1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(3)]);
                                double r1 = 0;
                                r1 = ((ventas / ((cxc0 + cxc1) / 2)));
                                double R1 = Math.Round(r1, 2);
                                string X1 = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX1 = Convert.ToDateTime(X1);
                                kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                                //Rotacion de CxP
                                double cxp0 = Convert.ToDouble(inputOrdenar.Rows[fila][(3)]);
                                double cxp1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(3)]);
                                double compras = Inv1 + costos - Inv0;
                                double r2 = 0;
                                r2 = ((compras / ((cxp0 + cxp1) / 2)));
                                double R2 = Math.Round(r2, 2);
                                string X2 = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX2 = Convert.ToDateTime(X2);
                                kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                                fila++;
                            }
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    graphIndicesActividadVarios.DataContext = dataSourceList;
                    graphIndicesActividadVarios.UpdateLayout();
                }
            }
            else////tipoSerie == "mes"
            {
                txtGetTipo2.Text = "Mensual";
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
                    List<KeyValuePair<DateTime, double>> kvp2 = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila > 0)
                        {
                            //Rotacion de inventarios
                            double costos = Convert.ToDouble(Transition.Rows[fila - 1][(30)]);
                            double Inv0 = Convert.ToDouble(Transition.Rows[fila][(4)]);
                            double Inv1 = Convert.ToDouble(Transition.Rows[fila - 1][(4)]);
                            double r = 0;
                            r = ((costos / ((Inv0 + Inv1) / 2)));
                            double R = Math.Round(r, 2);
                            string X = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Rotacion de CxC
                            double ventas = Convert.ToDouble(Transition.Rows[fila - 1][(29)]);
                            double cxc0 = Convert.ToDouble(Transition.Rows[fila][(3)]);
                            double cxc1 = Convert.ToDouble(Transition.Rows[fila - 1][(3)]);
                            double r1 = 0;
                            r1 = ((ventas / ((cxc0 + cxc1) / 2)));
                            double R1 = Math.Round(r1, 2);
                            string X1 = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Rotacion de CxP
                            double cxp0 = Convert.ToDouble(Transition.Rows[fila][(3)]);
                            double cxp1 = Convert.ToDouble(Transition.Rows[fila - 1][(3)]);
                            double compras = Inv1 + costos - Inv0;
                            double r2 = 0;
                            r2 = ((compras / ((cxp0 + cxp1) / 2)));
                            double R2 = Math.Round(r2, 2);
                            string X2 = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX2 = Convert.ToDateTime(X2);
                            kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                            fila--;
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    graphIndicesActividadVarios.DataContext = dataSourceList;
                    graphIndicesActividadVarios.UpdateLayout();
                }
            }
        }

        private void graphRotacionCapital_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            if (tipoSerie == "Anual")
            {
                txtGetTipo2.Text = "Anual";
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
                            if (fila + 1 < inputOrdenar.Rows.Count)
                            {
                                //Rotacion de capital de trabajo
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(29)]);
                                double activosCirculantes0 = Convert.ToDouble(inputOrdenar.Rows[fila][(6)]);
                                double activosCirculantes1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(6)]);
                                double pasivosCirculantes0 = Convert.ToDouble(inputOrdenar.Rows[fila][(21)]);
                                double pasivosCirculantes1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(21)]);
                                double promedio = (((activosCirculantes0 - pasivosCirculantes0) + (activosCirculantes1 - pasivosCirculantes1)) / 2);
                                double r = 0;
                                r = (ventas / promedio);
                                double R = Math.Round(r, 2);
                                string X = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX = Convert.ToDateTime(X);
                                kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                                //Rotacion de activo fijo                                
                                double activosFijos0 = Convert.ToDouble(inputOrdenar.Rows[fila][(13)]);
                                double activosFijos1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(13)]);
                                double r1 = 0;
                                r1 = (ventas / ((activosFijos0 + activosFijos1) / 2));
                                double R1 = Math.Round(r1, 2);
                                string X1 = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX1 = Convert.ToDateTime(X1);
                                kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                                //Rotacion de activo total                                
                                double activosTotal0 = Convert.ToDouble(inputOrdenar.Rows[fila][(14)]);
                                double activosTotal1 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(14)]);
                                double r2 = 0;
                                r2 = (ventas / ((activosTotal0 + activosTotal1) / 2));
                                double R2 = Math.Round(r2, 2);
                                string X2 = (inputOrdenar.Rows[fila + 1][(0)]).ToString();
                                DateTime XX2 = Convert.ToDateTime(X2);
                                kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                                fila++;
                            }
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    graphRotacionCapital.DataContext = dataSourceList;
                    graphRotacionCapital.UpdateLayout();
                }
            }

            else////tipoSerie == "mes"
            {
                txtGetTipo2.Text = "Mensual";
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
                    List<KeyValuePair<DateTime, double>> kvp2 = new List<KeyValuePair<DateTime, double>>();
                    int fila = Transition.Rows.Count - 1;
                    foreach (DataRow dc in Transition.Rows)
                    {
                        if (fila > 0)
                        {
                            //Rotacion de capital de trabajo
                            double ventas = Convert.ToDouble(Transition.Rows[fila - 1][(29)]);
                            double activosCirculantes0 = Convert.ToDouble(Transition.Rows[fila][(6)]);
                            double activosCirculantes1 = Convert.ToDouble(Transition.Rows[fila - 1][(6)]);
                            double pasivosCirculantes0 = Convert.ToDouble(Transition.Rows[fila][(21)]);
                            double pasivosCirculantes1 = Convert.ToDouble(Transition.Rows[fila - 1][(21)]);
                            double promedio = (((activosCirculantes0 - pasivosCirculantes0) + (activosCirculantes1 - pasivosCirculantes1)) / 2);
                            double r = 0;
                            r = (ventas / promedio);
                            double R = Math.Round(r, 2);
                            string X = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX = Convert.ToDateTime(X);
                            kvp.Add(new KeyValuePair<DateTime, double>(XX, R));
                            //Rotacion de activo fijo                                
                            double activosFijos0 = Convert.ToDouble(Transition.Rows[fila][(13)]);
                            double activosFijos1 = Convert.ToDouble(Transition.Rows[fila - 1][(13)]);
                            double r1 = 0;
                            r1 = (ventas / ((activosFijos0 + activosFijos1) / 2));
                            double R1 = Math.Round(r1, 2);
                            string X1 = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX1 = Convert.ToDateTime(X1);
                            kvp1.Add(new KeyValuePair<DateTime, double>(XX1, R1));
                            //Rotacion de activo total                                
                            double activosTotal0 = Convert.ToDouble(Transition.Rows[fila][(14)]);
                            double activosTotal1 = Convert.ToDouble(Transition.Rows[fila - 1][(14)]);
                            double r2 = 0;
                            r2 = (ventas / ((activosTotal0 + activosTotal1) / 2));
                            double R2 = Math.Round(r2, 2);
                            string X2 = (Transition.Rows[fila - 1][(0)]).ToString();
                            DateTime XX2 = Convert.ToDateTime(X2);
                            kvp2.Add(new KeyValuePair<DateTime, double>(XX2, R2));
                            fila--;
                        }
                    }
                    var dataSourceList = new List<List<KeyValuePair<DateTime, double>>>();
                    dataSourceList.Add(kvp);
                    dataSourceList.Add(kvp1);
                    dataSourceList.Add(kvp2);
                    graphRotacionCapital.DataContext = dataSourceList;
                    graphRotacionCapital.UpdateLayout();
                }
            }
        }

        private void btnCloseIA_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }        
    }
}
