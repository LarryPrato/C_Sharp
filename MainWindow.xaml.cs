using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;

namespace GFC_V0
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
   
    public partial class MainWindow : Window
    {
        BLogic BL_Instancia = new BLogic();
        public MainWindow()
        {
            InitializeComponent();
            BL_Instancia.CrearBaseDatos();           
        }
        
        private void dgPeriodos_Loaded(object sender, RoutedEventArgs e)
        {
            dgPeriodos.ItemsSource = BL_Instancia.UpdateDatagrid().DefaultView;
            dgPeriodos.Columns[45].Visibility = Visibility.Collapsed;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)//Validación de campos
        {
            //Validar que se suministre la información general
            bool b = DBInfoFill();
            if(b== true)
            {
                //////////////////////
                if (cbxTipoInfo.SelectedIndex == 0)
                {
                    System.Windows.MessageBox.Show("El campo 'Tipo de datos' debe seleccionar un opción");
                    cbxTipoInfo.Focus();
                    return;
                }
                
                if (dprFecha.SelectedDate == null)
                {
                    System.Windows.MessageBox.Show("Debe ingresar una fecha");
                    dprFecha.Focus();
                    dprFecha.Background = Brushes.LightGray;
                    return;
                }
                if (dprFecha.Focus() == false)
                {
                    dprFecha.Background = Brushes.White;
                }
                if (txtEfectivo.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Efectivo' no puede estar vacio");
                    txtEfectivo.Focus();
                    return;
                }
                //decimal efectivo = 0;
                if (!decimal.TryParse(txtEfectivo.Text, out decimal efectivo))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtEfectivo.Focus();
                    return;
                }
                //////////////////////
                if (txtInversionesTemporales.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Inversiones temporales' no puede estar vacio");
                    txtInversionesTemporales.Focus();
                    return;
                }
                //decimal itemp = 0;
                if (!decimal.TryParse(txtInversionesTemporales.Text, out decimal itemp))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtInversionesTemporales.Focus();
                    return;
                }
                //////////////////////
                if (txtCxC.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Cuentas p/Cobrar' no puede estar vacio");
                    txtCxC.Focus();
                    return;
                }
                //decimal cxc = 0;
                if (!decimal.TryParse(txtCxC.Text, out decimal cxc))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtCxC.Focus();
                    return;
                }
                //////////////////////
                if (txtInventarios.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Inventarios' no puede estar vacio");
                    txtInventarios.Focus();
                    return;
                }
                //decimal inventario = 0;
                if (!decimal.TryParse(txtInventarios.Text, out decimal inventario))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtInventarios.Focus();
                    return;
                }
                //////////////////////
                if (txtOtrosActivosCirculantes.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Otros activos circulantes' no puede estar vacio");
                    txtOtrosActivosCirculantes.Focus();
                    return;
                }
                //decimal varControl = 0;
                if (!decimal.TryParse(txtOtrosActivosCirculantes.Text, out decimal varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtOtrosActivosCirculantes.Focus();
                    return;
                }
                //////////////////////
                if (txtTotalActivosCirculantes.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Total Activos Circulantes' no puede estar vacio");
                    txtTotalActivosCirculantes.Focus();
                    return;
                }

                if (!decimal.TryParse(txtTotalActivosCirculantes.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtTotalActivosCirculantes.Focus();
                    return;
                }
                //////////////////////
                if (txtEquiposYMaquinarias.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Equipos y maquinarias' no puede estar vacio");
                    txtEquiposYMaquinarias.Focus();
                    return;
                }

                if (!decimal.TryParse(txtEquiposYMaquinarias.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtEquiposYMaquinarias.Focus();
                    return;
                }
                //////////////////////
                if (txtBienesInmuebles.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Bienes inmuebles' no puede estar vacio");
                    txtBienesInmuebles.Focus();
                    return;
                }

                if (!decimal.TryParse(txtBienesInmuebles.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtBienesInmuebles.Focus();
                    return;
                }
                //////////////////////
                if (txtTerrenos.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Terrenos' no puede estar vacio");
                    txtTerrenos.Focus();
                    return;
                }

                if (!decimal.TryParse(txtTerrenos.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtTerrenos.Focus();
                    return;
                }
                //////////////////////
                if (txtActivosIntangibles.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Activos intangibles' no puede estar vacio");
                    txtActivosIntangibles.Focus();
                    return;
                }

                if (!decimal.TryParse(txtActivosIntangibles.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtActivosIntangibles.Focus();
                    return;
                }
                //////////////////////
                if (txtDepreciacionAcumulada.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Depreciación acumulada' no puede estar vacio");
                    txtDepreciacionAcumulada.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDepreciacionAcumulada.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtDepreciacionAcumulada.Focus();
                    return;
                }
                //////////////////////
                if (txtOtrosActivosLargoPlazo.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Otros activos largo plazo' no puede estar vacio");
                    txtOtrosActivosLargoPlazo.Focus();
                    return;
                }

                if (!decimal.TryParse(txtOtrosActivosLargoPlazo.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtOtrosActivosLargoPlazo.Focus();
                    return;
                }
                //////////////////////
                if (txtCxP.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Cuentas p/Pagar' no puede estar vacio");
                    txtCxP.Focus();
                    return;
                }

                if (!decimal.TryParse(txtCxP.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtCxP.Focus();
                    return;
                }
                //////////////////////
                if (txtEfectosxPagar.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Efectos p/Pagar' no puede estar vacio");
                    txtEfectosxPagar.Focus();
                    return;
                }

                if (!decimal.TryParse(txtEfectosxPagar.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtEfectosxPagar.Focus();
                    return;
                }
                //////////////////////
                if (txtObligacionesLaborales.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Obligaciones laborales' no puede estar vacio");
                    txtObligacionesLaborales.Focus();
                    return;
                }

                if (!decimal.TryParse(txtObligacionesLaborales.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtObligacionesLaborales.Focus();
                    return;
                }
                //////////////////////
                if (txtObligacionesFiscales.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Obligaciones fiscales' no puede estar vacio");
                    txtObligacionesFiscales.Focus();
                    return;
                }

                if (!decimal.TryParse(txtObligacionesFiscales.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtObligacionesFiscales.Focus();
                    return;
                }
                //////////////////////
                if (txtPrevisionesYContingencia.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Provisiones y contingencia' no puede estar vacio");
                    txtPrevisionesYContingencia.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrevisionesYContingencia.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtPrevisionesYContingencia.Focus();
                    return;
                }
                //////////////////////
                if (txtOtrosPasivosCirculantes.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Otros pasivos circulantes' no puede estar vacio");
                    txtOtrosPasivosCirculantes.Focus();
                    return;
                }

                if (!decimal.TryParse(txtOtrosPasivosCirculantes.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtOtrosPasivosCirculantes.Focus();
                    return;
                }
                //////////////////////
                if (txtBonos.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Bonos' no puede estar vacio");
                    txtBonos.Focus();
                    return;
                }

                if (!decimal.TryParse(txtBonos.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtBonos.Focus();
                    return;
                }
                //////////////////////
                if (txtOtrosPasivosLargoPlazo.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Otros pasivos a largo plazo' no puede estar vacio");
                    txtOtrosPasivosLargoPlazo.Focus();
                    return;
                }

                if (!decimal.TryParse(txtOtrosPasivosLargoPlazo.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtOtrosPasivosLargoPlazo.Focus();
                    return;
                }
                //////////////////////
                if (txtCapital.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Capital' no puede estar vacio");
                    txtCapital.Focus();
                    return;
                }

                if (!decimal.TryParse(txtCapital.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtCapital.Focus();
                    return;
                }
                //////////////////////
                if (txtUtilidadRetenida.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Utilidades retenidas' no puede estar vacio");
                    txtUtilidadRetenida.Focus();
                    return;
                }

                if (!decimal.TryParse(txtUtilidadRetenida.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtUtilidadRetenida.Focus();
                    return;
                }
                //////////////////////
                if (txtVentas.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Ventas' no puede estar vacio");
                    txtVentas.Focus();
                    return;
                }

                if (!decimal.TryParse(txtVentas.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtVentas.Focus();
                    return;
                }
                //////////////////////
                if (txtCostos.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Costos' no puede estar vacio");
                    txtCostos.Focus();
                    return;
                }

                if (!decimal.TryParse(txtCostos.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtCostos.Focus();
                    return;
                }
                //////////////////////
                if (txtGastosAdmin.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Gastos administrativos' no puede estar vacio");
                    txtGastosAdmin.Focus();
                    return;
                }

                if (!decimal.TryParse(txtGastosAdmin.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtGastosAdmin.Focus();
                    return;
                }
                //////////////////////
                if (txtGastosVentas.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Gastos de ventas' no puede estar vacio");
                    txtGastosVentas.Focus();
                    return;
                }

                if (!decimal.TryParse(txtGastosVentas.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtGastosVentas.Focus();
                    return;
                }
                //////////////////////
                if (txtDepreciacion.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Depreciacion' no puede estar vacio");
                    txtDepreciacion.Focus();
                    return;
                }

                if (!decimal.TryParse(txtDepreciacion.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtDepreciacion.Focus();
                    return;
                }
                //////////////////////
                if (txtIntereses.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Gastos por intereses' no puede estar vacio");
                    txtIntereses.Focus();
                    return;
                }

                if (!decimal.TryParse(txtIntereses.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtIntereses.Focus();
                    return;
                }
                //////////////////////
                if (txtImpuestos.Text == string.Empty)
                {
                    System.Windows.MessageBox.Show("El campo 'Impuestos' no puede estar vacio");
                    txtImpuestos.Focus();
                    return;
                }

                if (!decimal.TryParse(txtImpuestos.Text, out varControl))
                {
                    System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                    txtImpuestos.Focus();
                    return;
                }
                //////////////////////
                if (cbxTipoInfo.SelectedIndex == 1)
                {
                    //Guardar valores en base de datos
                    string CurrentMonth = dprFecha.SelectedDate.Value.Month.ToString();  // Ejecuta esta linea para caturar el numero del mes en la columna DummyMes         
                    txtDummyMes.Text = CurrentMonth; // Ejecuta esta linea para caturar el numero del mes en la columna DummyMes
                    string sql = "INSERT INTO Periodos(Periodo,Efectivo,InversionesTemporales,CuentasPorCobrar,Inventarios,OtrosActivosCirculantes,TotalActivosCirculantes," +
                        "EquiposYMaquinarias,BienesInmuebles,Terrenos,ActivosIntangibles,DepreciacionAcumulada,OtrosActivosLargoPlazo,TotalActivosFijos,TotalActivos," +
                        "CuentasPorPagar,EfectosPorPagar,ObligacionesLaborales,ObligacionesFiscales,ProvisionesYContingencia,OtrosPasivosCirculantes,TotalPasivosCirculantes, " +
                        "Bonos,OtrosPasivosLargoPlazo,TotalPasivosLargoPlazo,Capital,UtilidadesRetenidas,TotalPatrimonio,TotalPasivoYPatrimonio," +
                        "Ventas,Costos,UtilidadBruta,GastosAdministrativos,GastosVentas,CostosOperativos,EBITDA,Depreciacion,CostosInversion,EBIT,GastosInteres, " +
                        "CostosFinancieros,UtilidadAntesImpuesto,Impuestos,CostosFiscales,UtilidadNeta,DummyMes)" +
                        "VALUES(@Periodo,@Efectivo,@InversionesTemporales,@CuentasPorCobrar,@Inventarios,@OtrosActivosCirculantes,@TotalActivosCirculantes," +
                        "@EquiposYMaquinarias,@BienesInmuebles,@Terrenos,@ActivosIntangibles,@DepreciacionAcumulada,@OtrosActivosLargoPlazo,@TotalActivosFijos,@TotalActivos," +
                        "@CuentasPorPagar,@EfectosPorPagar,@ObligacionesLaborales,@ObligacionesFiscales,@ProvisionesYContingencia,@OtrosPasivosCirculantes,@TotalPasivosCirculantes, " +
                        "@Bonos,@OtrosPasivosLargoPlazo,@TotalPasivosLargoPlazo,@Capital,@UtilidadesRetenidas,@TotalPatrimonio,@TotalPasivoYPatrimonio," +
                        "@Ventas,@Costos,@UtilidadBruta,@GastosAdministrativos,@GastosVentas,@CostosOperativos,@EBITDA,@Depreciacion,@CostosInversion,@EBIT,@GastosInteres," +
                        "@CostosFinancieros,@UtilidadAntesImpuesto,@Impuestos,@CostosFiscales,@UtilidadNeta,@DummyMes)";
                    BL_Instancia.AD(sql, 0);
                }
                else
                {
                    //Guardar valores en base de datos
                    string CurrentMonth = dprFecha.SelectedDate.Value.Month.ToString();  // Ejecuta esta linea para caturar el numero del mes en la columna DummyMes         
                    txtDummyMes.Text = CurrentMonth; // Ejecuta esta linea para caturar el numero del mes en la columna DummyMes
                    string sql = "INSERT INTO Mensual(Periodo,Efectivo,InversionesTemporales,CuentasPorCobrar,Inventarios,OtrosActivosCirculantes,TotalActivosCirculantes," +
                        "EquiposYMaquinarias,BienesInmuebles,Terrenos,ActivosIntangibles,DepreciacionAcumulada,OtrosActivosLargoPlazo,TotalActivosFijos,TotalActivos," +
                        "CuentasPorPagar,EfectosPorPagar,ObligacionesLaborales,ObligacionesFiscales,ProvisionesYContingencia,OtrosPasivosCirculantes,TotalPasivosCirculantes, " +
                        "Bonos,OtrosPasivosLargoPlazo,TotalPasivosLargoPlazo,Capital,UtilidadesRetenidas,TotalPatrimonio,TotalPasivoYPatrimonio," +
                        "Ventas,Costos,UtilidadBruta,GastosAdministrativos,GastosVentas,CostosOperativos,EBITDA,Depreciacion,CostosInversion,EBIT,GastosInteres, " +
                        "CostosFinancieros,UtilidadAntesImpuesto,Impuestos,CostosFiscales,UtilidadNeta,DummyMes)" +
                        "VALUES(@Periodo,@Efectivo,@InversionesTemporales,@CuentasPorCobrar,@Inventarios,@OtrosActivosCirculantes,@TotalActivosCirculantes," +
                        "@EquiposYMaquinarias,@BienesInmuebles,@Terrenos,@ActivosIntangibles,@DepreciacionAcumulada,@OtrosActivosLargoPlazo,@TotalActivosFijos,@TotalActivos," +
                        "@CuentasPorPagar,@EfectosPorPagar,@ObligacionesLaborales,@ObligacionesFiscales,@ProvisionesYContingencia,@OtrosPasivosCirculantes,@TotalPasivosCirculantes, " +
                        "@Bonos,@OtrosPasivosLargoPlazo,@TotalPasivosLargoPlazo,@Capital,@UtilidadesRetenidas,@TotalPatrimonio,@TotalPasivoYPatrimonio," +
                        "@Ventas,@Costos,@UtilidadBruta,@GastosAdministrativos,@GastosVentas,@CostosOperativos,@EBITDA,@Depreciacion,@CostosInversion,@EBIT,@GastosInteres," +
                        "@CostosFinancieros,@UtilidadAntesImpuesto,@Impuestos,@CostosFiscales,@UtilidadNeta,@DummyMes)";
                    BL_Instancia.AD2(sql, 0);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Debe actualizar la 'Información general'");
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            EditeDelete window = new EditeDelete();
            window.Show();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            dgPeriodos.ItemsSource = BL_Instancia.UpdateDatagrid().DefaultView;
            dgPeriodos.Columns[45].Visibility = Visibility.Collapsed;
            if (rbtAnual.IsChecked == true)
            {
                DummySerie.Text = "Anual";
            }
            if (rbtMensual.IsChecked == true)
            {
                DummySerie.Text = "Mensual";
            }
            if (rbtAnual.IsChecked == true)
            {
                DummySerie1.Text = "Datos Anuales";
            }
            if (rbtMensual.IsChecked == true)
            {
                DummySerie1.Text = "Datos Mensuales";
            }
        }

        private void dgPeriodos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Periodo")
            {
                //((DataGridTextColumn)e.Column).Binding.StringFormat = "dd/MM/yyyy";// otra forma e.PropertyType == (DateTime)
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                System.Windows.Data.Binding binding = column.Binding as System.Windows.Data.Binding;
                binding.StringFormat = "MMM-yyy";
            }
            else
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                System.Windows.Data.Binding binding = column.Binding as System.Windows.Data.Binding;
                binding.StringFormat = "{0:0,0.00}";
            }
        }

        ///////////////////////////      
        public static DataTable FilledTable(string tablename)
        {
            BLogic BL_Instancia = new BLogic();
            DataTable inputOrdenar = new DataTable();
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            return inputOrdenar;
        }

        public static DataTable FilledTableMonth(string tablename)
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

        public static Boolean DBFill()//Metodo para verificar si la base de datos esta vacia
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            bool YorN;
            if (a == 0)
            {
                YorN = false; // DB is empty
            }
            else
            {
                YorN = true;
            }
            return YorN; // DB is not empty
        }
        public static Boolean DBFillM()//Metodo para verificar si la base de datos esta vacia
        {
            DataTable inputOrdenar = FilledTableMonth("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            bool YorN;
            if (a == 0)
            {
                YorN = false; // DB is empty
            }
            else
            {
                YorN = true;
            }
            return YorN; // DB is not empty
        }
        //////////////////////////

        public int CheckFiscalMonth()// Metodo para verificar que exista al menos un registro con el mes de corte
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            int min = Math.Min(a, 12);
            int b = 0;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = BL_Instancia.ObtenerNumeroMes(mesCorte).ToString();            
            for(int r = 0; r <min;r++)
            {
                if(inputOrdenar.Rows[r][45].ToString()==month)
                {
                    b = b+1;                    
                }   
            }
            return b;
        }

        //////////////////////////
        private void winformhostBGAH_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            int b = CheckFiscalMonth();
            if (a == true)
            {
                DataGridView dgBGAH = new DataGridView();
                winformhostBGAH.Child = dgBGAH;
                dgBGAH.DataSource = BL_Instancia.BGAH();
                dgBGAH.AllowUserToAddRows = false;
                dgBGAH.RowHeadersVisible = false;
                if (b > 0)
                {
                    dgBGAH.Columns[0].MinimumWidth = 180;
                    dgBGAH.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                    dgBGAH.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgBGAH.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgBGAH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgBGAH.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgBGAH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgBGAH.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                else
                {
                    System.Windows.MessageBox.Show("Debe ingresar al menos un registro para el mes de corte de ejercicio fiscal");
                }                
            }
            else
            {
                winformhostBGAH.Visibility = System.Windows.Visibility.Hidden;
            }           
        }

        private void winformhostBGAV_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgBGAV = new DataGridView();
                winformhostBGAV.Child = dgBGAV;
                dgBGAV.DataSource = BL_Instancia.BGAV();
                dgBGAV.AllowUserToAddRows = false;
                dgBGAV.RowHeadersVisible = false;
                dgBGAV.Columns[0].MinimumWidth = 180;
                dgBGAV.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgBGAV.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgBGAV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgBGAV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgBGAV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgBGAV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgBGAV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostBGAV.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void winformhostERAH_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            int b = CheckFiscalMonth();
            if (a == true)
            {
                DataGridView dgERAH = new DataGridView();
                winformhostERAH.Child = dgERAH;
                dgERAH.DataSource = BL_Instancia.ERAH();
                dgERAH.AllowUserToAddRows = false;
                dgERAH.RowHeadersVisible = false;
                if (b > 0)
                {
                    dgERAH.Columns[0].MinimumWidth = 180;
                    dgERAH.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                    dgERAH.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                    dgERAH.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgERAH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgERAH.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgERAH.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgERAH.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }            
        }

        private void winformhostERAV_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgERAV = new DataGridView();
                winformhostERAV.Child = dgERAV;
                dgERAV.DataSource = BL_Instancia.ERAV();
                dgERAV.AllowUserToAddRows = false;
                dgERAV.RowHeadersVisible = false;
                dgERAV.Columns[0].MinimumWidth = 180;
                dgERAV.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgERAV.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgERAV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgERAV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgERAV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgERAV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgERAV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostERAV.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void winformhostIndicesI_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgWinformIndicesI = new DataGridView();
                winformhostIndicesI.Child = dgWinformIndicesI;
                dgWinformIndicesI.DataSource = BL_Instancia.CalcularIndicesI();
                dgWinformIndicesI.AllowUserToAddRows = false;
                dgWinformIndicesI.RowHeadersVisible = false;
                dgWinformIndicesI.Columns[0].MinimumWidth = 250;
                dgWinformIndicesI.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgWinformIndicesI.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgWinformIndicesI.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgWinformIndicesI.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesI.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgWinformIndicesI.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesI.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostIndicesI.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void winformhostIndicesII_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgWinformIndicesII = new DataGridView();
                winformhostIndicesII.Child = dgWinformIndicesII;
                dgWinformIndicesII.DataSource = BL_Instancia.CalcularIndicesII();
                dgWinformIndicesII.AllowUserToAddRows = false;
                dgWinformIndicesII.RowHeadersVisible = false;
                dgWinformIndicesII.Columns[0].MinimumWidth = 250;
                dgWinformIndicesII.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgWinformIndicesII.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgWinformIndicesII.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgWinformIndicesII.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesII.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgWinformIndicesII.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesII.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostIndicesII.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void winformhostIndicesIII_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgWinformIndicesIII = new DataGridView();
                winformhostIndicesIII.Child = dgWinformIndicesIII;
                dgWinformIndicesIII.DataSource = BL_Instancia.CalcularIndicesIII();
                dgWinformIndicesIII.AllowUserToAddRows = false;
                dgWinformIndicesIII.RowHeadersVisible = false;
                dgWinformIndicesIII.Columns[0].MinimumWidth = 250;
                dgWinformIndicesIII.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgWinformIndicesIII.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgWinformIndicesIII.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgWinformIndicesIII.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesIII.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgWinformIndicesIII.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesIII.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostIndicesIII.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void winformhostIndicesIV_Loaded(object sender, RoutedEventArgs e)
        {
            bool a = DBFill();
            if (a == true)
            {
                DataGridView dgWinformIndicesIV = new DataGridView();
                winformhostIndicesIV.Child = dgWinformIndicesIV;
                dgWinformIndicesIV.DataSource = BL_Instancia.CalcularIndicesIV();
                dgWinformIndicesIV.AllowUserToAddRows = false;
                dgWinformIndicesIV.RowHeadersVisible = false;
                dgWinformIndicesIV.Columns[0].MinimumWidth = 250;
                dgWinformIndicesIV.RowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
                dgWinformIndicesIV.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgWinformIndicesIV.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgWinformIndicesIV.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesIV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgWinformIndicesIV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgWinformIndicesIV.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            else
            {
                winformhostIndicesIV.Visibility = System.Windows.Visibility.Hidden;
            }
        }
       
        private void Graficos1_Click(object sender, RoutedEventArgs e)
        {
            LiquidityRatios window = new LiquidityRatios();
            window.Show();
        }

        private void Graficos2_Click(object sender, RoutedEventArgs e)
        {
            ActivityRatios window = new ActivityRatios();
            window.Show();
        }

        private void Graficos3_Click(object sender, RoutedEventArgs e)
        {
            SolvencyRatios window = new SolvencyRatios();
            window.Show();
        }

        private void Graficos4_Click(object sender, RoutedEventArgs e)
        {
            ProfitabiltyRatios window = new ProfitabiltyRatios();
            window.Show();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("El campo 'Nombre de la empresa' no puede estar vacio");
                txtNombre.Focus();
                return;
            }

            if (txtDireccion.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("El campo 'Dirección' no puede estar vacio");
                txtDireccion.Focus();
                return;
            }

            if (cbxTipoEmpresa.Text == "Select" || cbxTipoEmpresa.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("En 'Tipo de empresa' debe seleccionar una opción");
                cbxTipoEmpresa.Focus();
                return;
            }

            if (txtNumeroEmpleados.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("El campo 'Numero de empleados' no puede estar vacio");
                txtNumeroEmpleados.Focus();
                return;
            }
            if (!decimal.TryParse(txtNumeroEmpleados.Text, out decimal numEmpl))
            {
                System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtInventarios.Focus();
                return;
            }

            if (cbxMesCorte.Text == "Select" || cbxMesCorte.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("En 'Mes de corte de ejercicio fiscal' debe seleccionar una opción");
                cbxMesCorte.Focus();
                return;
            }

            if (txtWACC.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("El campo 'Costo promedio de capital ponderado' no puede estar vacio");
                txtWACC.Focus();
                return;
            }
            if (!decimal.TryParse(txtWACC.Text, out decimal wacc))
            {
                System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtWACC.Focus();
                return;
            }

            if (txtTax.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("El campo 'Tasa media de impuesto' no puede estar vacio");
                txtTax.Focus();
                return;
            }
            if (!decimal.TryParse(txtTax.Text, out decimal tax))
            {
                System.Windows.MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtTax.Focus();
                return;
            }

            if (cbxEstrategia.Text == "Select" || cbxEstrategia.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("En '¿Cual es la estrategia genérica que mas se adecua a la empresa?' debe seleccionar una opción");
                cbxEstrategia.Focus();
                return;
            }

            if (cbxObjetivos.Text == "Select" || cbxObjetivos.Text == string.Empty)
            {
                System.Windows.MessageBox.Show("En '¿Tiene metas y objetivos claramente establecidos?' debe seleccionar una opción");
                cbxObjetivos.Focus();
                return;
            }

            if (dprInfo.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Debe ingresar una fecha");
                dprInfo.Focus();
                dprInfo.Background = Brushes.LightGray;
                return;
            }
            if (dprInfo.Focus() == false)
            {
                dprInfo.Background = Brushes.White;
            }
                        
            string sql = "INSERT INTO Info(Name,Address,Type,NumEmploy,FiscalMonth,Wacc,Tax,Strategy,Objetives,Data)" +
                "VALUES(@Name,@Address,@Type,@NumEmploy,@FiscalMonth,@Wacc,@Tax,@Strategy,@Objetives,@Data)";
            BL_Instancia.AD1(sql, 0);
            dgInfo.ItemsSource = BL_Instancia.UpdateInfoGeneral().DefaultView;
            object item = dgInfo.Items[0];
            dgInfo.SelectedItem = item;
        }
        ///////////////////////////      
        public static DataTable FilledTableIfo(string tablename)
        {
            BLogic BL_Instancia = new BLogic();
            DataTable inputOrdenar = new DataTable();
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Info order by Data desc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            return inputOrdenar;
        }
        ///////////////////////////

        public static Boolean DBInfoFill()//Metodo para verificar si la base de datos esta vacia
        {
            DataTable inputOrdenar = FilledTableIfo("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            bool YorN;
            if (a == 0)
            {
                YorN = false; // DB is empty
            }
            else
            {
                YorN = true;
            }
            return YorN; // DB is not empty
        }
        //////////////////////////
        private void dgInfo_Loaded(object sender, RoutedEventArgs e)
        {
            dgInfo.ItemsSource = BL_Instancia.UpdateInfoGeneral().DefaultView;
            object item = dgInfo.Items[0];
            dgInfo.SelectedItem = item;
        }
                
        private void txtEnable001_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros anuales
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable001.Text = "False";
            }
            else
            {
                txtEnable001.Text = "True";
            }
        }

        private void txtEnable002_Loaded(object sender, RoutedEventArgs e) //Verifica si hay al menos 3 registros mensuales
        {
            DataTable inputOrdenar = FilledTableMonth("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable002.Text = "False";
            }
            else
            {
                txtEnable002.Text = "True";
            }
        }

        private void txtEnable003_Loaded(object sender, RoutedEventArgs e)
        {
            if(txtEnable001.Text=="True" || txtEnable002.Text == "True")
            {
                txtEnable003.Text = "True";
            }
            else
            {
                txtEnable003.Text = "False";
            }
        }

        private void txtEnable004_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros anuales / ABA AF
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable004.Text = "False";
            }
            else
            {
                txtEnable004.Text = "True";
            }
        }
        
        private void txtEnable005_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros mensuales/ ABA AF
        {
            DataTable inputOrdenar = FilledTableMonth("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable005.Text = "False";
            }
            else
            {
                txtEnable005.Text = "True";
            }
        }

        private void txtEnable006_Loaded(object sender, RoutedEventArgs e)//Valor buscado / ABA AF
        {
            if (cbxTipoSerie.Text == "Anual" && txtEnable004.Text == "True")
            {
                txtEnable006.Text = "True";
            }
            else
            {
                if (cbxTipoSerie.Text == "Mensual" && txtEnable005.Text == "True")
                {
                    txtEnable006.Text = "True";
                }
                else
                {
                    if (cbxTipoSerie.Text == "Anual" && txtEnable004.Text == "False")
                    {
                        txtEnable006.Text = "False";
                    }
                    else
                    {
                        txtEnable006.Text = "False";
                    }
                }
            }
        }

        private void txtEnable007_Loaded(object sender, RoutedEventArgs e)//Visibilidad / ABA AF
        {
            if (txtEnable006.Text == "True")
            {
                txtEnable007.Text = "Visible";
            }
            else
            {
                txtEnable007.Text = "Hidden";
            }
        }

        private void cbxTipoSerie_DropDownClosed(object sender, EventArgs e) // ABA AF
        {
            if (cbxTipoSerie.Text == "Anual" && txtEnable004.Text == "True")
            {
                txtEnable006.Text = "True";
            }
            else
            {
                if (cbxTipoSerie.Text == "Mensual" && txtEnable005.Text == "True")
                {
                    txtEnable006.Text = "True";
                }
                else
                {
                    if (cbxTipoSerie.Text == "Anual" && txtEnable004.Text == "False")
                    {
                        txtEnable006.Text = "False";
                    }
                    else
                    {
                        txtEnable006.Text = "False";
                    }
                }
            }
            //Visibilidad de las tablas
            if (txtEnable006.Text == "True")
            {
                txtEnable007.Text = "Visible";
            }
            else
            {
                txtEnable007.Text = "Hidden";
            }
        }

        private void txtEnable008_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros anuales / ABA IF
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable008.Text = "False";
            }
            else
            {
                txtEnable008.Text = "True";
            }
        }

        private void txtEnable009_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros mensuales / ABA IF
        {
            DataTable inputOrdenar = FilledTableMonth("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable009.Text = "False";
            }
            else
            {
                txtEnable009.Text = "True";
            }
        }

        private void txtEnable010_Loaded(object sender, RoutedEventArgs e)//Valor buscado / ABA IF
        {
            if(cbxTipoSerieIF.Text=="Anual" && txtEnable008.Text == "True")//1. Caso anual
            {
                txtEnable010.Text = "True";
            }
            else
            {
                if(cbxTipoSerieIF.Text=="Mensual" && txtEnable009.Text == "True")//2. Caso mensual
                {
                    txtEnable010.Text = "True";
                }
                else
                {
                    if (cbxTipoSerieIF.Text == "Anual" && txtEnable008.Text == "False")//3. Caso anual
                    {
                        txtEnable010.Text = "False";
                    }
                    else//4. Caso Mensual
                    {
                        txtEnable010.Text = "False";
                    }
                }
            }
        }

        private void txtEnable011_Loaded(object sender, RoutedEventArgs e)//Visibilidad / ABA IF
        {
            if (txtEnable010.Text == "True")
            {
                txtEnable011.Text = "Visible";
            }
            else
            {
                txtEnable011.Text = "Hidden";
            }
        }

        private void cbxTipoSerieIF_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxTipoSerieIF.Text == "Anual" && txtEnable008.Text == "True")
            {
                txtEnable010.Text = "True";
            }
            else
            {
                if (cbxTipoSerieIF.Text == "Mensual" && txtEnable009.Text == "True")
                {
                    txtEnable010.Text = "True";
                }
                else
                {
                    if (cbxTipoSerieIF.Text == "Mensual" && txtEnable008.Text == "False")
                    {
                        txtEnable010.Text = "False";
                    }
                    else
                    {
                        txtEnable010.Text = "False";
                    }
                }
            }
            //Visibilidad de las tablas
            if (txtEnable010.Text == "True")
            {
                txtEnable011.Text = "Visible";
            }
            else
            {
                txtEnable011.Text = "Hidden";
            }
        }

        private void txtEnable012_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros anuales / ABA Rep
        {
            DataTable inputOrdenar = FilledTable("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable012.Text = "False";
            }
            else
            {
                txtEnable012.Text = "True";
            }
        }

        private void txtEnable013_Loaded(object sender, RoutedEventArgs e)//Verifica si hay al menos 3 registros mensuales / ABA Rep
        {
            DataTable inputOrdenar = FilledTableMonth("inputOrdenar");
            int a = inputOrdenar.Rows.Count;
            if (a <= 2)
            {
                txtEnable013.Text = "False";
            }
            else
            {
                txtEnable013.Text = "True";
            }
        }

        private void txtEnable014_Loaded(object sender, RoutedEventArgs e)//Valor buscado / ABA Rep
        {
            if(cbxTipoSerieRepo.Text=="Anual" && txtEnable012.Text == "True")//1. Caso anual
            {
                txtEnable014.Text = "True";
            }
            else
            {
                if (cbxTipoSerieRepo.Text == "Mensual" && txtEnable013.Text == "True")//2. Caso mensual
                {
                    txtEnable014.Text = "True";
                }
                else
                {
                    if (cbxTipoSerieRepo.Text == "Anual" && txtEnable012.Text == "False")//3. Caso anual
                    {
                        txtEnable014.Text = "False";
                    }
                    else//4. Caso Mensual
                    {
                        txtEnable014.Text = "False";
                    }
                }
            }
        }

        private void txtEnable015_Loaded(object sender, RoutedEventArgs e)//Visibilidad / ABA Rep
        {
            if (txtEnable014.Text == "True")
            {
                txtEnable015.Text = "Visible";
            }
            else
            {
                txtEnable015.Text = "Hidden";
            }
        }


        private void cbxTipoSerieRepo_DropDownClosed(object sender, EventArgs e)
        {
            if (cbxTipoSerieRepo.Text == "Anual" && txtEnable012.Text == "True")//1. Caso anual
            {
                txtEnable014.Text = "True";
            }
            else
            {
                if (cbxTipoSerieRepo.Text == "Mensual" && txtEnable013.Text == "True")//2. Caso mensual
                {
                    txtEnable014.Text = "True";
                }
                else
                {
                    if (cbxTipoSerieRepo.Text == "Anual" && txtEnable012.Text == "False")//3. Caso anual
                    {
                        txtEnable014.Text = "False";
                    }
                    else//4. Caso Mensual
                    {
                        txtEnable014.Text = "False";
                    }
                }
            }
            // Visibilidad
            if (txtEnable014.Text == "True")
            {
                txtEnable015.Text = "Visible";
            }
            else
            {
                txtEnable015.Text = "Hidden";
            }
        }
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog imprimir = new System.Windows.Controls.PrintDialog();
            if (imprimir.ShowDialog() == true)
            {
                imprimir.PrintVisual(cnvReporte, "Imprimiendo");
            }
        }

        private void dgEFChanges_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChanges.ItemsSource = BL_Instancia.EFChangesII().DefaultView;
        }
        


        private void txt1stChange_Loaded(object sender, RoutedEventArgs e)
        {
            int n = BL_Instancia.EFChanges().Rows.Count;
            if (n > 0)
            {
                dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
                object item = dgEFChanges.Items[1];
                dgEFChanges.SelectedItem = item;
                txt1stChange.Text = ((DataRowView)dgEFChanges.Items[dgEFChanges.SelectedIndex]).Row["Cuenta"].ToString();
            }
            else
            {
                txt1stChange.Text =null;
            }
                      
        }

        private void txt2ndChange_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
            if (txtEnable014.Text == "True")
            {
                object item = dgEFChanges.Items[2];
                dgEFChanges.SelectedItem = item;
                txt2ndChange.Text = ((DataRowView)dgEFChanges.Items[dgEFChanges.SelectedIndex]).Row["Cuenta"].ToString();
            }
            else
            {
                txt2ndChange.Text = null;
            }
            
        }

        private void txt3rdChange_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
            if (txtEnable014.Text == "True")
            {
                object item = dgEFChanges.Items[3];
                dgEFChanges.SelectedItem = item;
                txt3rdChange.Text = ((DataRowView)dgEFChanges.Items[dgEFChanges.SelectedIndex]).Row["Cuenta"].ToString();
            }
            else
            {
                txt3rdChange.Text = null;
            }
                
        }

        private void txt4thChange_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
            if (txtEnable014.Text == "True")
            {
                object item = dgEFChanges.Items[4];
                dgEFChanges.SelectedItem = item;
                txt4thChange.Text = ((DataRowView)dgEFChanges.Items[dgEFChanges.SelectedIndex]).Row["Cuenta"].ToString();
            }
            else
            {
                txt4thChange.Text = null;
            }
                
        }

        private void txt5thChange_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
            if (txtEnable014.Text == "True")
            {
                object item = dgEFChanges.Items[5];
                dgEFChanges.SelectedItem = item;
                txt5thChange.Text = ((DataRowView)dgEFChanges.Items[dgEFChanges.SelectedIndex]).Row["Cuenta"].ToString();
            }
            else
            {
                txt5thChange.Text = null;
            }
                
        }        

        private void txtTenVent_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[0];
                dgEFChangesI.SelectedItem = item;
                txtTenVent.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[0];
                    dgEFChangesII.SelectedItem = item;
                    txtTenVent.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenCos_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[1];
                dgEFChangesI.SelectedItem = item;
                txtTenCos.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[1];
                    dgEFChangesII.SelectedItem = item;
                    txtTenCos.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenUtiBru_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[2];
                dgEFChangesI.SelectedItem = item;
                txtTenUtiBru.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[2];
                    dgEFChangesII.SelectedItem = item;
                    txtTenUtiBru.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenGAdm_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[3];
                dgEFChangesI.SelectedItem = item;
                txtTenGAdm.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[3];
                    dgEFChangesII.SelectedItem = item;
                    txtTenGAdm.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenGVen_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[4];
                dgEFChangesI.SelectedItem = item;
                txtTenGVen.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[4];
                    dgEFChangesII.SelectedItem = item;
                    txtTenGVen.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenEBITDA_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[6];
                dgEFChangesI.SelectedItem = item;
                txtTenEBITDA.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[6];
                    dgEFChangesII.SelectedItem = item;
                    txtTenEBITDA.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenCostInv_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[8];
                dgEFChangesI.SelectedItem = item;
                txtTenCostInv.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Cuenta (Anual)"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[8];
                    dgEFChangesII.SelectedItem = item;
                    txtTenCostInv.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenCostFin_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[11];
                dgEFChangesI.SelectedItem = item;
                txtTenCostFin.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[11];
                    dgEFChangesII.SelectedItem = item;
                    txtTenCostFin.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenCostFisc_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[14];
                dgEFChangesI.SelectedItem = item;
                txtTenCostFisc.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[14];
                    dgEFChangesII.SelectedItem = item;
                    txtTenCostFisc.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }

        private void txtTenUtiNet_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                object item = dgEFChangesI.Items[15];
                dgEFChangesI.SelectedItem = item;
                txtTenUtiNet.Text = ((DataRowView)dgEFChangesI.Items[dgEFChangesI.SelectedIndex]).Row["Tendencia"].ToString();
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    object item = dgEFChangesII.Items[15];
                    dgEFChangesII.SelectedItem = item;
                    txtTenUtiNet.Text = ((DataRowView)dgEFChangesII.Items[dgEFChangesII.SelectedIndex]).Row["Tendencia"].ToString();
                }
            }
        }
                
        private void DummySerie_Loaded(object sender, RoutedEventArgs e)
        {
            if (rbtAnual.IsChecked == true)
            {
                DummySerie.Text = "Anual";
            }
            if (rbtMensual.IsChecked == true)
            {
                DummySerie.Text = "Mensual";
            }
        }

        private void DummySerie1_Loaded(object sender, RoutedEventArgs e)
        {
            if (rbtAnual.IsChecked == true)
            {
                DummySerie1.Text = "Datos Anuales";
            }
            if (rbtMensual.IsChecked == true)
            {
                DummySerie1.Text = "Datos Mensuales";
            }
        }
                
        private void txtEfectivo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEfectivo.Clear();
        }

        private void txtEfectivo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEfectivo.Text == "")
            {
                txtEfectivo.Text = "0";
            }
        }

        private void txtInversionesTemporales_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInversionesTemporales.Clear();
        }

        private void txtInversionesTemporales_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtInversionesTemporales.Text == "")
            {
                txtInversionesTemporales.Text = "0";
            }
        }

        private void txtCxC_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCxC.Clear();
        }

        private void txtCxC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCxC.Text == "")
            {
                txtCxC.Text = "0";
            }
        }

        private void txtInventarios_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInventarios.Clear();
        }

        private void txtInventarios_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtInventarios.Text == "")
            {
                txtInventarios.Text = "0";
            }
        }

        private void txtOtrosActivosCirculantes_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtrosActivosCirculantes.Clear();
        }

        private void txtOtrosActivosCirculantes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosActivosCirculantes.Text == "")
            {
                txtOtrosActivosCirculantes.Text = "0";
            }
        }

        private void txtEquiposYMaquinarias_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEquiposYMaquinarias.Clear();
        }

        private void txtEquiposYMaquinarias_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEquiposYMaquinarias.Text == "")
            {
                txtEquiposYMaquinarias.Text = "0";
            }
        }

        private void txtBienesInmuebles_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBienesInmuebles.Clear();
        }

        private void txtBienesInmuebles_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBienesInmuebles.Text == "")
            {
                txtBienesInmuebles.Text = "0";
            }
        }

        private void txtTerrenos_GotFocus(object sender, RoutedEventArgs e)
        {
            txtTerrenos.Clear();
        }

        private void txtTerrenos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtTerrenos.Text == "")
            {
                txtTerrenos.Text = "0";
            }
        }

        private void txtActivosIntangibles_GotFocus(object sender, RoutedEventArgs e)
        {
            txtActivosIntangibles.Clear();
        }

        private void txtActivosIntangibles_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtActivosIntangibles.Text == "")
            {
                txtActivosIntangibles.Text = "0";
            }
        }

        private void txtDepreciacionAcumulada_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDepreciacionAcumulada.Clear();
        }

        private void txtDepreciacionAcumulada_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDepreciacionAcumulada.Text == "")
            {
                txtDepreciacionAcumulada.Text = "0";
            }
        }

        private void txtOtrosActivosLargoPlazo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtrosActivosLargoPlazo.Clear();
        }

        private void txtOtrosActivosLargoPlazo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosActivosLargoPlazo.Text == "")
            {
                txtOtrosActivosLargoPlazo.Text = "0";
            }
        }

        private void txtCxP_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCxP.Clear();
        }

        private void txtCxP_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCxP.Text == "")
            {
                txtCxP.Text = "0";
            }
        }

        private void txtEfectosxPagar_GotFocus(object sender, RoutedEventArgs e)
        {
            txtEfectosxPagar.Clear();
        }

        private void txtEfectosxPagar_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtEfectosxPagar.Text == "")
            {
                txtEfectosxPagar.Text = "0";
            }
        }

        private void txtObligacionesLaborales_GotFocus(object sender, RoutedEventArgs e)
        {
            txtObligacionesLaborales.Clear();
        }

        private void txtObligacionesLaborales_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtObligacionesLaborales.Text == "")
            {
                txtObligacionesLaborales.Text = "0";
            }
        }

        private void txtObligacionesFiscales_GotFocus(object sender, RoutedEventArgs e)
        {
            txtObligacionesFiscales.Clear();
        }

        private void txtObligacionesFiscales_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtObligacionesFiscales.Text == "")
            {
                txtObligacionesFiscales.Text = "0";
            }
        }

        private void txtPrevisionesYContingencia_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPrevisionesYContingencia.Clear();
        }

        private void txtPrevisionesYContingencia_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPrevisionesYContingencia.Text == "")
            {
                txtPrevisionesYContingencia.Text = "0";
            }
        }

        private void txtOtrosPasivosCirculantes_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtrosPasivosCirculantes.Clear();
        }

        private void txtOtrosPasivosCirculantes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosPasivosCirculantes.Text == "")
            {
                txtOtrosPasivosCirculantes.Text = "0";
            }
        }

        private void txtBonos_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBonos.Clear();
        }

        private void txtBonos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBonos.Text == "")
            {
                txtBonos.Text = "0";
            }
        }

        private void txtOtrosPasivosLargoPlazo_GotFocus(object sender, RoutedEventArgs e)
        {
            txtOtrosPasivosLargoPlazo.Clear();
        }

        private void txtOtrosPasivosLargoPlazo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtOtrosPasivosLargoPlazo.Text == "")
            {
                txtOtrosPasivosLargoPlazo.Text = "0";
            }
        }

        private void txtCapital_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCapital.Clear();
        }

        private void txtCapital_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCapital.Text == "")
            {
                txtCapital.Text = "0";
            }
        }

        private void txtUtilidadRetenida_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUtilidadRetenida.Clear();
        }

        private void txtUtilidadRetenida_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtUtilidadRetenida.Text == "")
            {
                txtUtilidadRetenida.Text = "0";
            }
        }

        private void txtVentas_GotFocus(object sender, RoutedEventArgs e)
        {
            txtVentas.Clear();
        }

        private void txtVentas_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtVentas.Text == "")
            {
                txtVentas.Text = "0";
            }
        }

        private void txtCostos_GotFocus(object sender, RoutedEventArgs e)
        {
            txtCostos.Clear();
        }

        private void txtCostos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtCostos.Text == "")
            {
                txtCostos.Text = "0";
            }
        }

        private void txtGastosAdmin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtGastosAdmin.Clear();
        }

        private void txtGastosAdmin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtGastosAdmin.Text == "")
            {
                txtGastosAdmin.Text = "0";
            }
        }

        private void txtGastosVentas_GotFocus(object sender, RoutedEventArgs e)
        {
            txtGastosVentas.Clear();
        }

        private void txtGastosVentas_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtGastosVentas.Text == "")
            {
                txtGastosVentas.Text= "0";
            }
        }

        private void txtDepreciacion_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDepreciacion.Clear();
        }

        private void txtDepreciacion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDepreciacion.Text == "")
            {
                txtDepreciacion.Text = "0";
            }
        }

        private void txtIntereses_GotFocus(object sender, RoutedEventArgs e)
        {
            txtIntereses.Clear();
        }

        private void txtIntereses_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtIntereses.Text == "")
            {
                txtIntereses.Text = "0";
            }
        }

        private void txtImpuestos_GotFocus(object sender, RoutedEventArgs e)
        {
            txtImpuestos.Clear();
        }

        private void txtImpuestos_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtImpuestos.Text == "")
            {
                txtImpuestos.Text = "0";
            }
        }

        private void txtComentario00_Loaded(object sender, RoutedEventArgs e)// Comentario ventas
        {
        }
       
        private void txtComentario01_Loaded(object sender, RoutedEventArgs e) // Comentario utilidad neta
        {
        }
        
        private void txtComentario02_Loaded(object sender, RoutedEventArgs e) // Comentario utilidad bruta
        {
        }
               
        private void txtComentario03_Loaded(object sender, RoutedEventArgs e) // Comentario pasivos circulantes
        {
        }

        public DataTable ComentariosLoad() //Comentarios para frecuencia anual
        {
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            DataTable inputOrdenar = new DataTable();//Tabla para obtener valores de base de datos
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            // Insertar columnas en una tabla
            DataTable Calculo = new DataTable();// Tabla para capturar los valores de la primera tabla obtenida de la base de datos y establecer la tendencia de cuentas del estado de resultados
            //Se crean los encabezados de cada columna
            Calculo.Columns.Add("Cuenta (Anual)");
            Calculo.Columns.Add("PerT");
            Calculo.Columns.Add("PerT-1");
            Calculo.Columns.Add("PerT-2");
            Calculo.Columns.Add("Tendencia");
            //Importa de la tabla input los valores que coincidan con el nomnre de la columna
            for (int cCount = 1; cCount <= 44; cCount++)
            {
                DataRow newRow = Calculo.NewRow();
                {
                    newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();//Nombrede cuenta
                    newRow[1] = inputOrdenar.Rows[0][cCount];//Valor T
                    newRow[2] = inputOrdenar.Rows[1][cCount];//Valor T1
                    newRow[3] = inputOrdenar.Rows[2][cCount];//Valor T2   
                    double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                    double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                    double c = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                    if (a > b && b > c)
                    {
                        newRow[4] = "Creciente";
                    }
                    else
                    {
                        if (a < b && b < c)
                        {
                            newRow[4] = "Decreciente";
                        }
                        else
                        {
                            if (a == b && b == c)
                            {
                                newRow[4] = "Estable";
                            }
                            else { newRow[4] = "Sin tendencia"; }
                        }
                    }
                    Calculo.Rows.Add(newRow);
                }
            }

            DataTable Comentarios = new DataTable();
            Comentarios.Columns.Add("Venta");
            Comentarios.Columns.Add("Costos");
            Comentarios.Columns.Add("UtilidadBruta");
            Comentarios.Columns.Add("Ebitda");
            Comentarios.Columns.Add("CFinanciero");
            Comentarios.Columns.Add("UtilidadNeta");
            Comentarios.Columns.Add("PasivosCirculantes");
            Comentarios.Rows.Add();

            object venta = Calculo.Rows[28]["Tendencia"];
            object uNeta = Calculo.Rows[43]["Tendencia"];
            object uBruta = Calculo.Rows[30]["Tendencia"];
            object actCir = Calculo.Rows[5]["Tendencia"];
            object pasCir = Calculo.Rows[20]["Tendencia"];
            object costos = Calculo.Rows[29]["Tendencia"];
            object ebitda = Calculo.Rows[34]["Tendencia"];
            object cFin = Calculo.Rows[39]["Tendencia"];
            string X1 = Convert.ToString(venta);
            string X2 = Convert.ToString(uNeta);
            string X3 = Convert.ToString(uBruta);
            string X4 = Convert.ToString(actCir);
            string X5 = Convert.ToString(pasCir);
            string X6 = Convert.ToString(costos);
            string X7 = Convert.ToString(ebitda);
            string X8 = Convert.ToString(cFin);
            string ventaCom;
            string costosCom;
            string uBrutaCom;
            string ebitdaCom;
            string cFinCom;
            string uNetaCom;
            string pasCirCom;

            //Comentarios a mostrar
            //Ventas
            txtComentario00.Height = double.NaN;
            if (X1 == "Decreciente")
            {
                ventaCom = "          ●  Ventas: el resultado anual refleja tendencia decreciente por lo que se deben analizar las causas que condujerón a esta situación" +
                    " y adoptar las medidas necesarias para revertir la tendencia.";
            }
            else
            {
                if (X1 == "Sin tendencia")
                {
                    ventaCom = "          ●  Ventas: el resultado anual no refleja tendencia por lo que deben adoptarse las medidas necesarias para generar una tendencia " +
                        "creciente y sostenida.";
                }
                else
                {
                    ventaCom = "--";
                    txtComentario00.Height = 0;
                }
            }

            // Costos
            txtComentario04.Height = double.NaN;
            if (X6 == "Creciente" && X1 == "Decreciente")//1
            {
                costosCom = "          ●  Costos: la tendencia anual creciente de los costos en contraste a la decreciente de las ventas, representan la peor " +
                    "combinación para los objetivos de la empresa. Es necesario tomar medidas para revertir estas tendencias en favor de los objetivos del negocio.";
            }
            else
            {
                if (X6 == "Creciente" && X1 == "Sin tendencia")//2
                {
                    costosCom = "          ●  Costos: el resultado anual refleja tendencia creciente en los costos mientras que las ventas no muestran una tendencia" +
                        " definida. Se deben tomar acciones tacticas generar en los costos una tendencia que acompañe favorablemente la tendencia en las ventas.";
                }
                else
                {
                    if (X6 == "Sin tendencia" && X1 == "Decreciente")//3
                    {
                        costosCom = "          ●  Costos: se observa que no existe una tendencia anual definida en los costos, sin embargo, las ventas muestran tendencia" +
                            " negativa. Es necesario emprender acciones tacticas para que los costos se estabilicen en una tendencia que sea favorable a los objetivos del negocio.";
                    }
                    else
                    {
                        costosCom = "--";
                        txtComentario04.Height = 0;
                    }
                }
            }

            //Utilidad bruta
            txtComentario02.Height = double.NaN;
            if (X3 == "Decreciente" && X1 == "Creciente")//1
            {
                uBrutaCom = "          ●  Utilidad bruta: aunque las ventas anuales presentarón tendencia creciente la utilidad bruta disminuyó. Revisar costos.";
            }
            else
            {
                if (X3 == "Decreciente" && X1 == "Sin tendencia")//2
                {
                    uBrutaCom = "          ●  Utilidad bruta: se observa tendencia negativa en la utilidad bruta anual, posiblemente sea consecuencia de que las " +
                        "ventas no reflejan una tendecia favorable. Emprender acciones tacticas para revertir la situación.";
                }
                else
                {
                    if (X3 == "Decreciente" && X1 == "Decreciente")//3
                    {
                        uBrutaCom = "          ●  Utilidad bruta: se observa que la tendencia de la utilidad bruta anual esta siguiendo la tendencia negativa de las" +
                            " ventas.";
                    }
                    else
                    {
                        if (X3 == "Sin tendencia" && X1 == "Creciente")//4
                        {
                            uBrutaCom = "          ●  Utilidad bruta: aunque las ventas anuales presentarón tendencia creciente su efecto no se reflejó en la utilidad bruta. Revisar costos.";
                        }
                        else
                        {
                            uBrutaCom = "--";
                            txtComentario02.Height = 0;
                        }
                    }
                }
            }

            //EBITDA
            txtComentario05.Height = double.NaN;
            if (X7 == "Decreciente" && X3 == "Creciente")//1
            {
                ebitdaCom = "          ●  Ebitda: aunque la utilidad bruta anual presentó tendencia creciente el ebitda reflejó una tendencia negativa. Revisar gastos operativos.";
            }
            else
            {
                if (X7 == "Sin tendencia" && X3 == "Creciente")//2
                {
                    ebitdaCom = "          ●  Ebitda: aunque la utilidad bruta anual presentó tendencia creciente su efecto no se reflejó en el ebitda. Revisar gastos operativos.";
                }
                else
                {
                    if (X7 == "Decreciente" && X3 == "Decreciente")//3
                    {
                        ebitdaCom = "          ●  Ebitda: se observa tendencia decreciente en el ebitda anual consecuencia directa de la utilidad bruta con tendencia negativa.";
                    }
                    else
                    {
                        ebitdaCom = "--";
                        txtComentario05.Height = 0;
                    }

                }
            }

            //Costos Financieros
            txtComentario06.Height = double.NaN;
            if (X8 == "Creciente")
            {
                cFinCom = "          ●  Costos financieros: se observa una tendencia mensual creciente. Revisar fuentes y formas de financiemiento para evitar" +
                    " situaciones de estres financiero.";
            }
            else
            {
                cFinCom = "--";
                txtComentario06.Height = 0;
            }

            //Utilidad neta
            txtComentario01.Height = double.NaN;
            if (X2 == "Decreciente" && X1 == "Creciente")//1
            {
                uNetaCom = "          ●  Utilidad neta: aunque las ventas anuales presentarón tendencia creciente la utilidad neta disminuyó."; //Indica que las ventas crecieron, pero la UN disminuyó. 
            }
            else
            {
                if (X2 == "Decreciente" && X1 == "Sin tendencia")//2
                {
                    uNetaCom = "          ●  Utilidad neta: se observa tendencia negativa en la utilidad neta anual, posiblemente sea consecuencia de que las " +
                        "ventas no reflejan una tendecia favorable. Revisar costos y gastos operativos.";
                }
                else
                {
                    if (X2 == "Decreciente" && X1 == "Decreciente")//3
                    {
                        uNetaCom = "          ●  Utilidad neta: se observa que la tendencia de la utilidad neta anual esta siguiendo la tendencia negativa de las" +
                            " ventas.";
                    }
                    else
                    {
                        if (X2 == "Sin tendencia" && X1 == "Creciente")//4
                        {
                            uNetaCom = "          ●  Utilidad neta: aunque las ventas anuales presentarón tendencia creciente su efecto no se reflejó en la utilidad neta.";
                        }
                        else
                        {
                            uNetaCom = "--";
                            txtComentario01.Height = 0;
                        }
                    }
                }
            }

            //Pasivos circulantes
            txtComentario03.Height = double.NaN;
            if (X5 == "Creciente" && X4 == "Decreciente")//1
            {
                pasCirCom = "          ●  Capital de trabajo: los pasivos circulantes anuales reflejan una tendencia creciente en contraste a los activos circulantes " +
                    "que muestran tendencia decreciente. Analizar para mantener el nivel satisfactorio de capital de trabajo.";
            }
            else
            {
                if (X5 == "Creciente" && X4 == "Sin tendencia")//2
                {
                    pasCirCom = "          ●  Capital de trabajo: los pasivos circulantes anuales reflejan una tendencia creciente en contraste a los activos circulantes " +
                    "que no muestran tendencia definida. Analizar para mantener el nivel satisfactorio de capital de trabajo.";
                }
                else
                {
                    pasCirCom = "--";
                    txtComentario03.Height = 0;
                }
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------

            Comentarios.Rows[0][0] = ventaCom;
            Comentarios.Rows[0][1] = costosCom;
            Comentarios.Rows[0][2] = uBrutaCom;
            Comentarios.Rows[0][3] = ebitdaCom;
            Comentarios.Rows[0][4] = cFinCom;
            Comentarios.Rows[0][5] = uNetaCom;
            Comentarios.Rows[0][6] = pasCirCom;
            return Comentarios;
        }

        public DataTable ComentariosLoadMensual() //Comentarios para frecuencia mensual
        {
            SqlCeConnection _con = new SqlCeConnection("DataSource=\"bdRegistros.sdf\"");
            DataTable inputOrdenar = new DataTable();//Tabla para obtener valores de base de datos
            BL_Instancia.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
            operario.Fill(inputOrdenar);
            BL_Instancia.CloseConnection();
            // Insertar columnas en una tabla
            DataTable Calculo = new DataTable();// Tabla para capturar los valores de la primera tabla obtenida de la base de datos y establecer la tendencia de cuentas del estado de resultados
            //Se crean los encabezados de cada columna
            Calculo.Columns.Add("Cuenta (Mensual)");
            Calculo.Columns.Add("PerT");
            Calculo.Columns.Add("PerT-1");
            Calculo.Columns.Add("PerT-2");
            Calculo.Columns.Add("Tendencia");
            //Importa de la tabla input los valores que coincidan con el nomnre de la columna
            for (int cCount = 1; cCount <= 44; cCount++)
            {
                DataRow newRow = Calculo.NewRow();
                {
                    newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();//Nombrede cuenta
                    newRow[1] = inputOrdenar.Rows[0][cCount];//Valor T
                    newRow[2] = inputOrdenar.Rows[1][cCount];//Valor T1
                    newRow[3] = inputOrdenar.Rows[2][cCount];//Valor T2   
                    double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                    double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                    double c = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                    if (a > b && b > c)
                    {
                        newRow[4] = "Creciente";
                    }
                    else
                    {
                        if (a < b && b < c)
                        {
                            newRow[4] = "Decreciente";
                        }
                        else
                        {
                            if (a == b && b == c)
                            {
                                newRow[4] = "Estable";
                            }
                            else { newRow[4] = "Sin tendencia"; }
                        }
                    }
                    Calculo.Rows.Add(newRow);
                }
            }

            DataTable Comentarios = new DataTable();
            Comentarios.Columns.Add("Venta");
            Comentarios.Columns.Add("Costos");
            Comentarios.Columns.Add("UtilidadBruta");
            Comentarios.Columns.Add("Ebitda");
            Comentarios.Columns.Add("CFinanciero");
            Comentarios.Columns.Add("UtilidadNeta");
            Comentarios.Columns.Add("PasivosCirculantes");
            Comentarios.Rows.Add();

            object venta = Calculo.Rows[28]["Tendencia"];
            object uNeta = Calculo.Rows[43]["Tendencia"];
            object uBruta = Calculo.Rows[30]["Tendencia"];
            object actCir = Calculo.Rows[5]["Tendencia"];
            object pasCir = Calculo.Rows[20]["Tendencia"];
            object costos = Calculo.Rows[29]["Tendencia"];
            object ebitda = Calculo.Rows[34]["Tendencia"];
            object cFin = Calculo.Rows[39]["Tendencia"];
            string X1 = Convert.ToString(venta);
            string X2 = Convert.ToString(uNeta);
            string X3 = Convert.ToString(uBruta);
            string X4 = Convert.ToString(actCir);
            string X5 = Convert.ToString(pasCir);
            string X6 = Convert.ToString(costos);
            string X7 = Convert.ToString(ebitda);
            string X8 = Convert.ToString(cFin);
            string ventaCom;
            string costosCom;
            string uBrutaCom;
            string ebitdaCom;
            string cFinCom;
            string uNetaCom;
            string pasCirCom;

            //-----------------------------------------------------------------------------------------------------------------------------------------
            //Comentarios a mostrar
            //Ventas
            txtComentario00.Height = double.NaN;
            if (X1 == "Decreciente")
            {
                ventaCom = "          ●  Ventas: el resultado mensual refleja tendencia decreciente por lo que se deben analizar las causas que condujerón a esta situación" +
                    " y adoptar las medidas necesarias para revertir la tendencia.";
            }
            else
            {
                if (X1 == "Sin tendencia")
                {
                    ventaCom = "          ●  Ventas: el resultado mensual no refleja tendencia por lo que deben adoptarse las medidas necesarias para generar una tendencia " +
                        "creciente y sostenida.";
                }
                else
                {
                    ventaCom = "--";
                    txtComentario00.Height = 0;
                }
            }

            // Costos
            txtComentario04.Height = double.NaN;
            if (X6 == "Creciente" && X1 == "Decreciente")//1
            {
                costosCom = "          ●  Costos: la tendencia mensual creciente de los costos en contraste a la decreciente de las ventas, representan la peor " +
                    "combinación para los objetivos de la empresa. Es necesario tomar medidas para revertir estas tendencias en favor de los objetivos del negocio.";
            }
            else
            {
                if (X6 == "Creciente" && X1 == "Sin tendencia")//2
                {
                    costosCom = "          ●  Costos: el resultado mensual refleja tendencia creciente en los costos mientras que las ventas no muestran una tendencia" +
                        " definida. Se deben tomar acciones tacticas generar en los costos una tendencia que acompañe favorablemente la tendencia en las ventas.";
                }
                else
                {
                    if (X6 == "Sin tendencia" && X1 == "Decreciente")//3
                    {
                        costosCom = "          ●  Costos: se observa que no existe una tendencia mensual definida en los costos, sin embargo, las ventas muestran tendencia" +
                            " negativa. Es necesario emprender acciones tacticas para que los costos se estabilicen en una tendencia que sea favorable a los objetivos del negocio.";
                    }
                    else
                    {
                        costosCom = "--";
                        txtComentario04.Height = 0;
                    }
                }
            }

            //Utilidad bruta
            txtComentario02.Height = double.NaN;
            if (X3 == "Decreciente" && X1 == "Creciente")//1
            {
                uBrutaCom = "          ●  Utilidad bruta: aunque las ventas mensuales presentarón tendencia creciente la utilidad bruta disminuyó. Revisar costos.";
            }
            else
            {
                if (X3 == "Decreciente" && X1 == "Sin tendencia")//2
                {
                    uBrutaCom = "          ●  Utilidad bruta: se observa tendencia negativa en la utilidad bruta mensual, posiblemente sea consecuencia de que las " +
                        "ventas no reflejan una tendecia favorable. Emprender acciones tacticas para revertir la situación.";
                }
                else
                {
                    if (X3 == "Decreciente" && X1 == "Decreciente")//3
                    {
                        uBrutaCom = "          ●  Utilidad bruta: se observa que la tendencia de la utilidad bruta mensual esta siguiendo la tendencia negativa de las" +
                            " ventas.";
                    }
                    else
                    {
                        if (X3 == "Sin tendencia" && X1 == "Creciente")//4
                        {
                            uBrutaCom = "          ●  Utilidad bruta: aunque las ventas mensuales presentarón tendencia creciente su efecto no se reflejó en la utilidad bruta. Revisar costos.";
                        }
                        else
                        {
                            uBrutaCom = "--";
                            txtComentario02.Height = 0;
                        }
                    }
                }
            }

            //EBITDA
            txtComentario05.Height = double.NaN;
            if (X7 == "Decreciente" && X3=="Creciente")//1
            {
                ebitdaCom = "          ●  Ebitda: aunque la utilidad bruta mensual presentó tendencia creciente el ebitda reflejó una tendencia negativa. Revisar gastos operativos.";
            }
            else
            {
                if (X7 == "Sin tendencia" && X3 == "Creciente")//2
                {
                    ebitdaCom = "          ●  Ebitda: aunque la utilidad bruta mensual presentó tendencia creciente su efecto no se reflejó en el ebitda. Revisar gastos operativos.";
                }
                else
                {
                    if (X7 == "Decreciente" && X3 == "Decreciente")//3
                    {
                        ebitdaCom = "          ●  Ebitda: se observa tendencia decreciente en el ebitda mensual consecuencia directa de la utilidad bruta con tendencia negativa.";
                    }
                    else
                    {
                        ebitdaCom = "--";
                        txtComentario05.Height = 0;
                    }
                    
                }
            }

            //Costos Financieros
            txtComentario06.Height = double.NaN;
            if (X8 == "Creciente")
            {
                cFinCom = "          ●  Costos financieros: se observa una tendencia mensual creciente. Revisar fuentes y formas de financiemiento para evitar" +
                    " situaciones de estres financiero.";
            }
            else
            {
                cFinCom = "--";
                txtComentario06.Height = 0;
            }

            //Utilidad neta
            txtComentario01.Height = double.NaN;
            if (X2 == "Decreciente" && X1 == "Creciente")//1
            {
                uNetaCom = "          ●  Utilidad neta: aunque las ventas mensuales presentarón tendencia creciente la utilidad neta disminuyó."; //Indica que las ventas crecieron, pero la UN disminuyó. 
            }
            else
            {
                if (X2 == "Decreciente" && X1 == "Sin tendencia")//2
                {
                    uNetaCom = "          ●  Utilidad neta: se observa tendencia negativa en la utilidad neta mensual, posiblemente sea consecuencia de que las " +
                        "ventas no reflejan una tendecia favorable. Revisar costos y gastos operativos.";
                }
                else
                {
                    if (X2 == "Decreciente" && X1 == "Decreciente")//3
                    {
                        uNetaCom = "          ●  Utilidad neta: se observa que la tendencia de la utilidad neta mensual esta siguiendo la tendencia negativa de las" +
                            " ventas.";
                    }
                    else
                    {
                        if (X2 == "Sin tendencia" && X1 == "Creciente")//4
                        {
                            uNetaCom = "          ●  Utilidad neta: aunque las ventas mensuales presentarón tendencia creciente su efecto no se reflejó en la utilidad neta.";
                        }
                        else
                        {
                            uNetaCom = "--";
                            txtComentario01.Height = 0;
                        }                        
                    }                    
                }                
            }

            //Pasivos circulantes
            txtComentario03.Height = double.NaN;
            if (X5 == "Creciente" && X4=="Decreciente")//1
            {
                pasCirCom = "          ●  Capital de trabajo: los pasivos circulantes mensuales reflejan una tendencia creciente en contraste a los activos circulantes " +
                    "que muestran tendencia decreciente. Analizar para mantener el nivel satisfactorio de capital de trabajo.";
            }
            else
            {
                if (X5 == "Creciente" && X4 == "Sin tendencia")//2
                {
                    pasCirCom = "          ●  Capital de trabajo: los pasivos circulantes mensuales reflejan una tendencia creciente en contraste a los activos circulantes " +
                    "que no muestran tendencia definida. Analizar para mantener el nivel satisfactorio de capital de trabajo.";
                }
                else
                {
                    pasCirCom = "--";
                    txtComentario03.Height = 0;
                }                
            }

            //-----------------------------------------------------------------------------------------------------------------------------------------
            Comentarios.Rows[0][0] = ventaCom;
            Comentarios.Rows[0][1] = costosCom;
            Comentarios.Rows[0][2] = uBrutaCom;
            Comentarios.Rows[0][3] = ebitdaCom;
            Comentarios.Rows[0][4] = cFinCom;
            Comentarios.Rows[0][5] = uNetaCom;
            Comentarios.Rows[0][6] = pasCirCom;
            return Comentarios;
        }

        private void txtFechaEmision_Loaded(object sender, RoutedEventArgs e)
        {
            txtFechaEmision.Text = DateTime.Now.ToShortDateString();
        }

        private void txtPeriodo_Loaded(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                BL_Instancia.OpenConnection();
                String _c = ("DataSource=\"bdRegistros.sdf\"");
                SqlCeConnection _con = new SqlCeConnection(_c);
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                BL_Instancia.CloseConnection();
                string a;
                a = inputOrdenar.Rows[0][0].ToString();
                DateTime b = DateTime.Parse(a);
                txtPeriodo.Text = b.ToString("MMM-yyyy");
            }
            else
            {
                DataTable inputOrdenar = new DataTable();
                BL_Instancia.OpenConnection();
                String _c = ("DataSource=\"bdRegistros.sdf\"");
                SqlCeConnection _con = new SqlCeConnection(_c);
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                BL_Instancia.CloseConnection();
                string a;
                a = inputOrdenar.Rows[0][0].ToString();
                DateTime b = DateTime.Parse(a);
                txtPeriodo.Text = b.ToString("MMM-yyyy");
            }
        }

        private void txtPeriodoLoad()
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                BL_Instancia.OpenConnection();
                String _c = ("DataSource=\"bdRegistros.sdf\"");
                SqlCeConnection _con = new SqlCeConnection(_c);
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                BL_Instancia.CloseConnection();
                string a;
                a = inputOrdenar.Rows[0][0].ToString();
                DateTime b = DateTime.Parse(a);
                txtPeriodo.Text = b.ToString("MMM-yyyy");
            }
            else
            {
                DataTable inputOrdenar = new DataTable();
                BL_Instancia.OpenConnection();
                String _c = ("DataSource=\"bdRegistros.sdf\"");
                SqlCeConnection _con = new SqlCeConnection(_c);
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                BL_Instancia.CloseConnection();
                string a;
                a = inputOrdenar.Rows[0][0].ToString();
                DateTime b = DateTime.Parse(a);
                txtPeriodo.Text = b.ToString("MMM-yyyy");
            }
        }

        private void btnActualizarRepo_Click(object sender, RoutedEventArgs e)
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            if (tipoSerie == "Anual")
            {
                //Cuentas que mas cambiaron
                dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
                string CH1 = ((DataRowView)dgEFChanges.Items[1]).Row["Cuenta"].ToString();
                txt1stChange.Text = CH1;

                string CH2 = ((DataRowView)dgEFChanges.Items[2]).Row["Cuenta"].ToString();
                txt2ndChange.Text = CH2;

                string CH3 = ((DataRowView)dgEFChanges.Items[3]).Row["Cuenta"].ToString();
                txt3rdChange.Text = CH3;

                string CH4 = ((DataRowView)dgEFChanges.Items[4]).Row["Cuenta"].ToString();
                txt4thChange.Text = CH4;

                string CH5 = ((DataRowView)dgEFChanges.Items[5]).Row["Cuenta"].ToString();
                txt5thChange.Text = CH5;

                //Tendencias
                dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
                string TV = ((DataRowView)dgEFChangesI.Items[0]).Row["Tendencia"].ToString();
                txtTenVent.Text = TV;

                string TC = ((DataRowView)dgEFChangesI.Items[1]).Row["Tendencia"].ToString();
                txtTenCos.Text = TC;

                string TUB = ((DataRowView)dgEFChangesI.Items[2]).Row["Tendencia"].ToString();
                txtTenUtiBru.Text = TUB;

                string TGA = ((DataRowView)dgEFChangesI.Items[3]).Row["Tendencia"].ToString();
                txtTenGAdm.Text = TGA;

                string TGV = ((DataRowView)dgEFChangesI.Items[4]).Row["Tendencia"].ToString();
                txtTenGVen.Text = TGV;

                string TEB = ((DataRowView)dgEFChangesI.Items[6]).Row["Tendencia"].ToString();
                txtTenEBITDA.Text = TEB;

                string TCI = ((DataRowView)dgEFChangesI.Items[8]).Row["Tendencia"].ToString();
                txtTenCostInv.Text = TCI;

                string TCFn = ((DataRowView)dgEFChangesI.Items[11]).Row["Tendencia"].ToString();
                txtTenCostFin.Text = TCFn;

                string TCFs = ((DataRowView)dgEFChangesI.Items[14]).Row["Tendencia"].ToString();
                txtTenCostFisc.Text = TCFs;

                string TUN = ((DataRowView)dgEFChangesI.Items[15]).Row["Tendencia"].ToString();
                txtTenUtiNet.Text = TUN;

                //Tendencias fin

                //Comentarios
                dgEFComentarios.ItemsSource = ComentariosLoad().DefaultView;
                string a = ((DataRowView)dgEFComentarios.Items[0]).Row["Venta"].ToString();
                txtComentario00.Text = a;
                string b = ((DataRowView)dgEFComentarios.Items[0]).Row["UtilidadNeta"].ToString();
                txtComentario01.Text = b;
                string c = ((DataRowView)dgEFComentarios.Items[0]).Row["UtilidadBruta"].ToString();
                txtComentario02.Text = c;
                string d = ((DataRowView)dgEFComentarios.Items[0]).Row["PasivosCirculantes"].ToString();
                txtComentario03.Text = d;
                string f = ((DataRowView)dgEFComentarios.Items[0]).Row["Costos"].ToString();
                txtComentario04.Text = f;
                string g = ((DataRowView)dgEFComentarios.Items[0]).Row["Ebitda"].ToString();
                txtComentario05.Text = g;
                string h = ((DataRowView)dgEFComentarios.Items[0]).Row["CFinanciero"].ToString();
                txtComentario06.Text = h;
            }
            else
            {
                if (tipoSerie == "Mensual")
                {
                    //Cuentas que mas cambiaron
                    dgEFChanges.ItemsSource = BL_Instancia.EFChanges().DefaultView;
                    string CH1 = ((DataRowView)dgEFChanges.Items[1]).Row["Cuenta"].ToString();
                    txt1stChange.Text = CH1;

                    string CH2 = ((DataRowView)dgEFChanges.Items[2]).Row["Cuenta"].ToString();
                    txt2ndChange.Text = CH2;

                    string CH3 = ((DataRowView)dgEFChanges.Items[3]).Row["Cuenta"].ToString();
                    txt3rdChange.Text = CH3;

                    string CH4 = ((DataRowView)dgEFChanges.Items[4]).Row["Cuenta"].ToString();
                    txt4thChange.Text = CH4;

                    string CH5 = ((DataRowView)dgEFChanges.Items[5]).Row["Cuenta"].ToString();
                    txt5thChange.Text = CH5;

                    //Tendencias
                    dgEFChangesII.ItemsSource = BL_Instancia.EFChangesImensual().DefaultView;
                    string TV = ((DataRowView)dgEFChangesII.Items[0]).Row["Tendencia"].ToString();
                    txtTenVent.Text = TV;

                    string TC = ((DataRowView)dgEFChangesII.Items[1]).Row["Tendencia"].ToString();
                    txtTenCos.Text = TC;

                    string TUB = ((DataRowView)dgEFChangesII.Items[2]).Row["Tendencia"].ToString();
                    txtTenUtiBru.Text = TUB;

                    string TGA = ((DataRowView)dgEFChangesII.Items[3]).Row["Tendencia"].ToString();
                    txtTenGAdm.Text = TGA;

                    string TGV = ((DataRowView)dgEFChangesII.Items[4]).Row["Tendencia"].ToString();
                    txtTenGVen.Text = TGV;

                    string TEB = ((DataRowView)dgEFChangesII.Items[6]).Row["Tendencia"].ToString();
                    txtTenEBITDA.Text = TEB;

                    string TCI = ((DataRowView)dgEFChangesII.Items[8]).Row["Tendencia"].ToString();
                    txtTenCostInv.Text = TCI;

                    string TCFn = ((DataRowView)dgEFChangesII.Items[11]).Row["Tendencia"].ToString();
                    txtTenCostFin.Text = TCFn;

                    string TCFs = ((DataRowView)dgEFChangesII.Items[14]).Row["Tendencia"].ToString();
                    txtTenCostFisc.Text = TCFs;

                    string TUN = ((DataRowView)dgEFChangesII.Items[15]).Row["Tendencia"].ToString();
                    txtTenUtiNet.Text = TUN;
                    //Tendencias fin 

                    // Comentarios
                    dgEFComentariosI.ItemsSource = ComentariosLoadMensual().DefaultView;
                    string a = ((DataRowView)dgEFComentariosI.Items[0]).Row["Venta"].ToString();
                    txtComentario00.Text = a;
                    string b = ((DataRowView)dgEFComentariosI.Items[0]).Row["UtilidadNeta"].ToString();
                    txtComentario01.Text = b;
                    string c = ((DataRowView)dgEFComentariosI.Items[0]).Row["UtilidadBruta"].ToString();
                    txtComentario02.Text = c;
                    string d = ((DataRowView)dgEFComentariosI.Items[0]).Row["PasivosCirculantes"].ToString();
                    txtComentario03.Text = d;
                    string f = ((DataRowView)dgEFComentariosI.Items[0]).Row["Costos"].ToString();
                    txtComentario04.Text = f;
                    string g = ((DataRowView)dgEFComentariosI.Items[0]).Row["Ebitda"].ToString();
                    txtComentario05.Text = g;
                    string h = ((DataRowView)dgEFComentariosI.Items[0]).Row["CFinanciero"].ToString();
                    txtComentario06.Text = h;
                }
            }            
            txtPeriodoLoad();
        }

        private void dgEFComentarios_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFComentarios.ItemsSource = ComentariosLoad().DefaultView;
        }

        private void dgEFComentariosI_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFComentariosI.ItemsSource = ComentariosLoadMensual().DefaultView;
        }

        private void dgEFChangesI_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChangesI.ItemsSource = BL_Instancia.EFChangesI().DefaultView;
        }

        private void dgEFChangesII_Loaded(object sender, RoutedEventArgs e)
        {
            dgEFChangesII.ItemsSource= BL_Instancia.EFChangesImensual().DefaultView;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtAppPatch_Loaded(object sender, RoutedEventArgs e)
        {
            string a = AppDomain.CurrentDomain.BaseDirectory;
            txtAppPatch.Text =a+ "Icon.png";
        }

        private void txtAppPatch1_Loaded(object sender, RoutedEventArgs e)
        {
            string a = AppDomain.CurrentDomain.BaseDirectory;
            txtAppPatch1.Text = a + "exit.png";
        }
    }

    //Binding datos
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            double _Sum = 0;
            if (values == null)
                return _Sum;
            foreach (var item in values)
            {
                double _Value;
                if (double.TryParse(item.ToString(), out _Value))
                    _Sum += _Value;
            }
            return _Sum.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Databinding: enlace de textboxes
    public class TotalConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            string ventas = values[0] as string;
            string costos = values[1] as string;
            string utilidad;
            double varcontrol = 0;
            // if(!decimal.TryParse(ventas, out cxc))
            if (!string.IsNullOrEmpty(ventas) && !string.IsNullOrEmpty(costos) && double.TryParse(ventas,out varcontrol) && double.TryParse(costos, out varcontrol))
            {
                utilidad = (double.Parse(ventas) - double.Parse(costos)).ToString();
                return utilidad;
            }
            return "0";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Databinding: enlace de textboxes
    public class EbitdaConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ventas = values[0] as string;
            string costos = values[1] as string;
            string GAdmin = values[2] as string;
            string GVentas = values[3] as string;
            string Ebitda;
            double varcontrol = 0;
            if (!string.IsNullOrEmpty(ventas) && !string.IsNullOrEmpty(costos) && !string.IsNullOrEmpty(GAdmin) && !string.IsNullOrEmpty(GVentas) && double.TryParse(ventas, out varcontrol) 
                && double.TryParse(costos, out varcontrol) && double.TryParse(GAdmin, out varcontrol) && double.TryParse(GVentas, out varcontrol))//Verifica que el campo se encuentre en el formato correcto
            {
                Ebitda = (double.Parse(ventas) - double.Parse(costos) - double.Parse(GAdmin) - double.Parse(GVentas)).ToString();
                return Ebitda;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Databinding: enlace de textboxes
    public class EbitConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ventas = values[0] as string;
            string costos = values[1] as string;
            string GAdmin = values[2] as string;
            string GVentas = values[3] as string;
            string Depreciacion = values[4] as string;
            string Ebit;
            double varcontrol = 0;
            if (!string.IsNullOrEmpty(ventas) && !string.IsNullOrEmpty(costos) && !string.IsNullOrEmpty(GAdmin) && !string.IsNullOrEmpty(GVentas) && !string.IsNullOrEmpty(Depreciacion) 
                && double.TryParse(ventas, out varcontrol) && double.TryParse(costos, out varcontrol) && double.TryParse(GAdmin, out varcontrol) && double.TryParse(GVentas, out varcontrol) && double.TryParse(Depreciacion, out varcontrol))
            {
                Ebit = (double.Parse(ventas) - double.Parse(costos) - double.Parse(GAdmin) - double.Parse(GVentas) - double.Parse(Depreciacion)).ToString();
                return Ebit;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Databinding: enlace de textboxes
    public class UtilidadAntesImpuestoConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ventas = values[0] as string;
            string costos = values[1] as string;
            string GAdmin = values[2] as string;
            string GVentas = values[3] as string;
            string Depreciacion = values[4] as string;
            string Intereses = values[5] as string;
            string UtilidadAntesImpuesto;
            double varcontrol = 0;
            if (!string.IsNullOrEmpty(ventas) && !string.IsNullOrEmpty(costos) && !string.IsNullOrEmpty(GAdmin) && !string.IsNullOrEmpty(GVentas) && !string.IsNullOrEmpty(Depreciacion) && !string.IsNullOrEmpty(Intereses) 
                && double.TryParse(ventas, out varcontrol) && double.TryParse(costos, out varcontrol) && double.TryParse(GAdmin, out varcontrol) && double.TryParse(GVentas, out varcontrol) && double.TryParse(Depreciacion, out varcontrol) && double.TryParse(Intereses, out varcontrol))
            {
                UtilidadAntesImpuesto = (double.Parse(ventas) - double.Parse(costos) - double.Parse(GAdmin) - double.Parse(GVentas) - double.Parse(Depreciacion) - double.Parse(Intereses)).ToString();
                return UtilidadAntesImpuesto;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    //Databinding: enlace de textboxes
    public class UtilidadNeta : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ventas = values[0] as string;
            string costos = values[1] as string;
            string GAdmin = values[2] as string;
            string GVentas = values[3] as string;
            string Depreciacion = values[4] as string;
            string Intereses = values[5] as string;
            string Impuestos = values[6] as string;
            string UtilidadNeta;
            double varcontrol = 0;
            if (!string.IsNullOrEmpty(ventas) && !string.IsNullOrEmpty(costos) && !string.IsNullOrEmpty(GAdmin) && !string.IsNullOrEmpty(GVentas) && !string.IsNullOrEmpty(Depreciacion) && !string.IsNullOrEmpty(Intereses) 
                && !string.IsNullOrEmpty(Impuestos) && double.TryParse(ventas, out varcontrol) && double.TryParse(costos, out varcontrol) && double.TryParse(GAdmin, out varcontrol) && double.TryParse(GVentas, out varcontrol) 
                && double.TryParse(Depreciacion, out varcontrol) && double.TryParse(Intereses, out varcontrol) && double.TryParse(Impuestos, out varcontrol))
            {
                UtilidadNeta = (double.Parse(ventas) - double.Parse(costos) - double.Parse(GAdmin) - double.Parse(GVentas) - double.Parse(Depreciacion) - double.Parse(Intereses) - double.Parse(Impuestos)).ToString();
                return UtilidadNeta;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }   
}