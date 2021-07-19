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
using System.Data;
using System.Data.SqlServerCe;

namespace GFC_V0
{
    /// <summary>
    /// Lógica interna para EditeDelete.xaml
    /// </summary>
    public partial class EditeDelete : Window
    {
        BLogic BL_Instancia = new BLogic();

        public EditeDelete()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgPeriodos.ItemsSource = BL_Instancia.UpdateDatagrid().DefaultView;
        }

        private void dgPeriodos_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Periodo")
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                Binding binding = column.Binding as Binding;
                binding.StringFormat = "dd-MM-yyyy";
            }
            else
            {
                DataGridTextColumn column = e.Column as DataGridTextColumn;
                Binding binding = column.Binding as Binding;
                binding.StringFormat = "{0:0,0.00}";
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (dprFecha.SelectedDate != null)
            {
                if (DummyDelete.Text == "Anual")
                {
                    string sql = "Delete from Periodos where Periodo=@Periodo";
                    this.Actualizar(sql, 1);
                    ResetAll();
                }
                else
                {
                    string sql = "Delete from Mensual where Periodo=@Periodo";
                    this.Actualizar(sql, 1);
                    ResetAll();
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            //////////////////////
            if (dprFecha.SelectedDate == null)
            {
                MessageBox.Show("Debe ingresar una fecha");
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
                MessageBox.Show("El campo 'Efectivo' no puede estar vacio");
                txtEfectivo.Focus();
                return;
            }
            
            if (!decimal.TryParse(txtEfectivo.Text, out decimal efectivo))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtEfectivo.Focus();
                return;
            }
            //////////////////////
            if (txtInversionesTemporales.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Inversiones temporales' no puede estar vacio");
                txtInversionesTemporales.Focus();
                return;
            }
            
            if (!decimal.TryParse(txtInversionesTemporales.Text, out decimal itemp))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtInversionesTemporales.Focus();
                return;
            }
            //////////////////////
            if (txtCxC.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Cuentas p/Cobrar' no puede estar vacio");
                txtCxC.Focus();
                return;
            }
            
            if (!decimal.TryParse(txtCxC.Text, out decimal cxc))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtCxC.Focus();
                return;
            }
            //////////////////////
            if (txtInventarios.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Inventarios' no puede estar vacio");
                txtInventarios.Focus();
                return;
            }
            
            if (!decimal.TryParse(txtInventarios.Text, out decimal inventario))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtInventarios.Focus();
                return;
            }
            //////////////////////
            if (txtOtrosActivosCirculantes.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Otros activos circulantes' no puede estar vacio");
                txtOtrosActivosCirculantes.Focus();
                return;
            }
            if (!decimal.TryParse(txtOtrosActivosCirculantes.Text, out decimal varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtOtrosActivosCirculantes.Focus();
                return;
            }
            //////////////////////
            if (txtTotalActivosCirculantes.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Total Activos Circulantes' no puede estar vacio");
                txtTotalActivosCirculantes.Focus();
                return;
            }

            if (!decimal.TryParse(txtTotalActivosCirculantes.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtTotalActivosCirculantes.Focus();
                return;
            }
            //////////////////////
            if (txtEquiposYMaquinarias.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Equipos y maquinarias' no puede estar vacio");
                txtEquiposYMaquinarias.Focus();
                return;
            }

            if (!decimal.TryParse(txtEquiposYMaquinarias.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtEquiposYMaquinarias.Focus();
                return;
            }
            //////////////////////
            if (txtBienesInmuebles.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Bienes inmuebles' no puede estar vacio");
                txtBienesInmuebles.Focus();
                return;
            }

            if (!decimal.TryParse(txtBienesInmuebles.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtBienesInmuebles.Focus();
                return;
            }
            //////////////////////
            if (txtTerrenos.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Terrenos' no puede estar vacio");
                txtTerrenos.Focus();
                return;
            }

            if (!decimal.TryParse(txtTerrenos.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtTerrenos.Focus();
                return;
            }
            //////////////////////
            if (txtActivosIntangibles.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Activos intangibles' no puede estar vacio");
                txtActivosIntangibles.Focus();
                return;
            }

            if (!decimal.TryParse(txtActivosIntangibles.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtActivosIntangibles.Focus();
                return;
            }
            //////////////////////
            if (txtDepreciacionAcumulada.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Depreciación acumulada' no puede estar vacio");
                txtDepreciacionAcumulada.Focus();
                return;
            }

            if (!decimal.TryParse(txtDepreciacionAcumulada.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtDepreciacionAcumulada.Focus();
                return;
            }
            //////////////////////
            if (txtOtrosActivosLargoPlazo.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Otros activos largo plazo' no puede estar vacio");
                txtOtrosActivosLargoPlazo.Focus();
                return;
            }

            if (!decimal.TryParse(txtOtrosActivosLargoPlazo.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtOtrosActivosLargoPlazo.Focus();
                return;
            }
            //////////////////////
            if (txtCxP.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Cuentas p/Pagar' no puede estar vacio");
                txtCxP.Focus();
                return;
            }

            if (!decimal.TryParse(txtCxP.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtCxP.Focus();
                return;
            }
            //////////////////////
            if (txtEfectosxPagar.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Efectos p/Pagar' no puede estar vacio");
                txtEfectosxPagar.Focus();
                return;
            }

            if (!decimal.TryParse(txtEfectosxPagar.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtEfectosxPagar.Focus();
                return;
            }
            //////////////////////
            if (txtObligacionesLaborales.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Obligaciones laborales' no puede estar vacio");
                txtObligacionesLaborales.Focus();
                return;
            }

            if (!decimal.TryParse(txtObligacionesLaborales.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtObligacionesLaborales.Focus();
                return;
            }
            //////////////////////
            if (txtObligacionesFiscales.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Obligaciones fiscales' no puede estar vacio");
                txtObligacionesFiscales.Focus();
                return;
            }

            if (!decimal.TryParse(txtObligacionesFiscales.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtObligacionesFiscales.Focus();
                return;
            }
            //////////////////////
            if (txtPrevisionesYContingencia.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Provisiones y contingencia' no puede estar vacio");
                txtPrevisionesYContingencia.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrevisionesYContingencia.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtPrevisionesYContingencia.Focus();
                return;
            }
            //////////////////////
            if (txtOtrosPasivosCirculantes.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Otros pasivos circulantes' no puede estar vacio");
                txtOtrosPasivosCirculantes.Focus();
                return;
            }

            if (!decimal.TryParse(txtOtrosPasivosCirculantes.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtOtrosPasivosCirculantes.Focus();
                return;
            }
            //////////////////////
            if (txtBonos.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Bonos' no puede estar vacio");
                txtBonos.Focus();
                return;
            }

            if (!decimal.TryParse(txtBonos.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtBonos.Focus();
                return;
            }
            //////////////////////
            if (txtOtrosPasivosLargoPlazo.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Otros pasivos a largo plazo' no puede estar vacio");
                txtOtrosPasivosLargoPlazo.Focus();
                return;
            }

            if (!decimal.TryParse(txtOtrosPasivosLargoPlazo.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtOtrosPasivosLargoPlazo.Focus();
                return;
            }
            //////////////////////
            if (txtCapital.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Capital' no puede estar vacio");
                txtCapital.Focus();
                return;
            }

            if (!decimal.TryParse(txtCapital.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtCapital.Focus();
                return;
            }
            //////////////////////
            if (txtUtilidadRetenida.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Utilidades retenidas' no puede estar vacio");
                txtUtilidadRetenida.Focus();
                return;
            }

            if (!decimal.TryParse(txtUtilidadRetenida.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtUtilidadRetenida.Focus();
                return;
            }
            //////////////////////
            if (txtVentas.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Ventas' no puede estar vacio");
                txtVentas.Focus();
                return;
            }

            if (!decimal.TryParse(txtVentas.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtVentas.Focus();
                return;
            }
            //////////////////////
            if (txtCostos.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Costos' no puede estar vacio");
                txtCostos.Focus();
                return;
            }

            if (!decimal.TryParse(txtCostos.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtCostos.Focus();
                return;
            }
            //////////////////////
            if (txtGastosAdmin.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Gastos administrativos' no puede estar vacio");
                txtGastosAdmin.Focus();
                return;
            }

            if (!decimal.TryParse(txtGastosAdmin.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtGastosAdmin.Focus();
                return;
            }
            //////////////////////
            if (txtGastosVentas.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Gastos de ventas' no puede estar vacio");
                txtGastosVentas.Focus();
                return;
            }

            if (!decimal.TryParse(txtGastosVentas.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtGastosVentas.Focus();
                return;
            }
            //////////////////////
            if (txtDepreciacion.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Depreciacion' no puede estar vacio");
                txtDepreciacion.Focus();
                return;
            }

            if (!decimal.TryParse(txtDepreciacion.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtDepreciacion.Focus();
                return;
            }
            //////////////////////
            if (txtIntereses.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Gastos por intereses' no puede estar vacio");
                txtIntereses.Focus();
                return;
            }

            if (!decimal.TryParse(txtIntereses.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtIntereses.Focus();
                return;
            }
            //////////////////////
            if (txtImpuestos.Text == string.Empty)
            {
                MessageBox.Show("El campo 'Impuestos' no puede estar vacio");
                txtImpuestos.Focus();
                return;
            }

            if (!decimal.TryParse(txtImpuestos.Text, out varControl))
            {
                MessageBox.Show("Debe ingresar un monto en el formato valido");
                txtImpuestos.Focus();
                return;
            }
            //////////////////////

            if (dprFecha.SelectedDate != null)
            {
                if (DummyDelete.Text == "Anual")
                {
                    string sql = "UPDATE Periodos set Efectivo=@Efectivo,InversionesTemporales=@InversionesTemporales,CuentasPorCobrar=@CuentasPorCobrar,Inventarios=@Inventarios," +
                                        "OtrosActivosCirculantes=@OtrosActivosCirculantes,TotalActivosCirculantes=@TotalActivosCirculantes,EquiposYMaquinarias=@EquiposYMaquinarias,BienesInmuebles=@BienesInmuebles," +
                                        "Terrenos=@Terrenos,ActivosIntangibles=@ActivosIntangibles,DepreciacionAcumulada=@DepreciacionAcumulada,OtrosActivosLargoPlazo=@OtrosActivosLargoPlazo,TotalActivosFijos=@TotalActivosFijos,TotalActivos=@TotalActivos," +
                                        "CuentasPorPagar=@CuentasPorPagar,EfectosPorPagar=@EfectosPorPagar,ObligacionesLaborales=@ObligacionesLaborales,ObligacionesFiscales=@ObligacionesFiscales,ProvisionesYContingencia=@ProvisionesYContingencia,OtrosPasivosCirculantes=@OtrosPasivosCirculantes,TotalPasivosCirculantes=@TotalPasivosCirculantes, " +
                                        "Bonos=@Bonos,OtrosPasivosLargoPlazo=@OtrosPasivosLargoPlazo,TotalPasivosLargoPlazo=@TotalPasivosLargoPlazo,Capital=@Capital,UtilidadesRetenidas=@UtilidadesRetenidas,TotalPatrimonio=@TotalPatrimonio,TotalPasivoYPatrimonio=@TotalPasivoYPatrimonio," +
                                        "Ventas=@Ventas,Costos=@Costos,UtilidadBruta=@UtilidadBruta,GastosAdministrativos=@GastosAdministrativos,GastosVentas=@GastosVentas,CostosOperativos=@CostosOperativos,EBITDA=@EBITDA,Depreciacion=@Depreciacion,CostosInversion=@CostosInversion,EBIT=@EBIT,GastosInteres=@GastosInteres, " +
                                        "CostosFinancieros=@CostosFinancieros,UtilidadAntesImpuesto=@UtilidadAntesImpuesto,Impuestos=@Impuestos,CostosFiscales=@CostosFiscales,UtilidadNeta=@UtilidadNeta,DummyMes=@DummyMes WHERE Periodo=@Periodo";

                    this.Actualizar(sql, 0);
                }
                else 
                {
                    string sql = "UPDATE Mensual set Efectivo=@Efectivo,InversionesTemporales=@InversionesTemporales,CuentasPorCobrar=@CuentasPorCobrar,Inventarios=@Inventarios," +
                                        "OtrosActivosCirculantes=@OtrosActivosCirculantes,TotalActivosCirculantes=@TotalActivosCirculantes,EquiposYMaquinarias=@EquiposYMaquinarias,BienesInmuebles=@BienesInmuebles," +
                                        "Terrenos=@Terrenos,ActivosIntangibles=@ActivosIntangibles,DepreciacionAcumulada=@DepreciacionAcumulada,OtrosActivosLargoPlazo=@OtrosActivosLargoPlazo,TotalActivosFijos=@TotalActivosFijos,TotalActivos=@TotalActivos," +
                                        "CuentasPorPagar=@CuentasPorPagar,EfectosPorPagar=@EfectosPorPagar,ObligacionesLaborales=@ObligacionesLaborales,ObligacionesFiscales=@ObligacionesFiscales,ProvisionesYContingencia=@ProvisionesYContingencia,OtrosPasivosCirculantes=@OtrosPasivosCirculantes,TotalPasivosCirculantes=@TotalPasivosCirculantes, " +
                                        "Bonos=@Bonos,OtrosPasivosLargoPlazo=@OtrosPasivosLargoPlazo,TotalPasivosLargoPlazo=@TotalPasivosLargoPlazo,Capital=@Capital,UtilidadesRetenidas=@UtilidadesRetenidas,TotalPatrimonio=@TotalPatrimonio,TotalPasivoYPatrimonio=@TotalPasivoYPatrimonio," +
                                        "Ventas=@Ventas,Costos=@Costos,UtilidadBruta=@UtilidadBruta,GastosAdministrativos=@GastosAdministrativos,GastosVentas=@GastosVentas,CostosOperativos=@CostosOperativos,EBITDA=@EBITDA,Depreciacion=@Depreciacion,CostosInversion=@CostosInversion,EBIT=@EBIT,GastosInteres=@GastosInteres, " +
                                        "CostosFinancieros=@CostosFinancieros,UtilidadAntesImpuesto=@UtilidadAntesImpuesto,Impuestos=@Impuestos,CostosFiscales=@CostosFiscales,UtilidadNeta=@UtilidadNeta,DummyMes=@DummyMes WHERE Periodo=@Periodo";

                    this.Actualizar(sql, 0);
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila");
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void dgPeriodos_Loaded(object sender, RoutedEventArgs e)
        {
            dgPeriodos.ItemsSource = BL_Instancia.UpdateDatagrid().DefaultView;
        }

        private void dgPeriodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                dprFecha.SelectedDate = DateTime.Parse(dr["Periodo"].ToString());
                txtEfectivo.Text = dr["Efectivo"].ToString();
                txtInversionesTemporales.Text = dr["InversionesTemporales"].ToString();
                txtCxC.Text = dr["CuentasPorCobrar"].ToString();
                txtInventarios.Text = dr["Inventarios"].ToString();
                txtOtrosActivosCirculantes.Text = dr["OtrosActivosCirculantes"].ToString();
                txtTotalActivosCirculantes.Text = dr["TotalActivosCirculantes"].ToString();
                txtEquiposYMaquinarias.Text = dr["EquiposYMaquinarias"].ToString();
                txtBienesInmuebles.Text = dr["BienesInmuebles"].ToString();
                txtTerrenos.Text = dr["Terrenos"].ToString();
                txtActivosIntangibles.Text = dr["ActivosIntangibles"].ToString();
                txtDepreciacionAcumulada.Text = dr["DepreciacionAcumulada"].ToString();
                txtOtrosActivosLargoPlazo.Text = dr["OtrosActivosLargoPlazo"].ToString();
                txtTotalActivosFijos.Text = dr["TotalActivosFijos"].ToString();
                txtTotalActivos.Text = dr["TotalActivos"].ToString();
                txtCxP.Text = dr["CuentasPorPagar"].ToString();
                txtEfectosxPagar.Text = dr["EfectosPorPagar"].ToString();
                txtObligacionesLaborales.Text = dr["ObligacionesLaborales"].ToString();
                txtObligacionesFiscales.Text = dr["ObligacionesFiscales"].ToString();
                txtPrevisionesYContingencia.Text = dr["ProvisionesYContingencia"].ToString();
                txtOtrosPasivosCirculantes.Text = dr["OtrosPasivosCirculantes"].ToString();
                txtTotalPasivosCirculantes.Text = dr["TotalPasivosCirculantes"].ToString();
                txtBonos.Text = dr["Bonos"].ToString();
                txtOtrosPasivosLargoPlazo.Text = dr["OtrosPasivosLargoPlazo"].ToString();
                txtTotalPasivosLargoPlazo.Text = dr["TotalPasivosLargoPlazo"].ToString();
                txtCapital.Text = dr["Capital"].ToString();
                txtUtilidadRetenida.Text = dr["UtilidadesRetenidas"].ToString();
                txtTotalPatrimonio.Text = dr["TotalPatrimonio"].ToString();
                txtTotalPasivoYPatrimonio.Text = dr["TotalPasivoYPatrimonio"].ToString();
                txtVentas.Text = dr["Ventas"].ToString();
                txtCostos.Text = dr["Costos"].ToString();
                txtUtilidadBruta.Text = dr["UtilidadBruta"].ToString();
                txtGastosAdmin.Text = dr["GastosAdministrativos"].ToString();
                txtGastosVentas.Text = dr["GastosVentas"].ToString();
                txtCostosOperacion.Text = dr["CostosOperativos"].ToString();
                txtEbitda.Text = dr["EBITDA"].ToString();
                txtDepreciacion.Text = dr["Depreciacion"].ToString();
                txtCostosInversion.Text = dr["CostosInversion"].ToString();
                txtEbit.Text = dr["EBIT"].ToString();
                txtIntereses.Text = dr["GastosInteres"].ToString();
                txtCostosFinancieros.Text = dr["CostosFinancieros"].ToString();
                txtUtilidadAntesImpuesto.Text = dr["UtilidadAntesImpuesto"].ToString();
                txtImpuestos.Text = dr["Impuestos"].ToString();
                txtCostosFisales.Text = dr["CostosFiscales"].ToString();
                txtUtilidadNeta.Text = dr["UtilidadNeta"].ToString();
                txtDummyMes.Text = dr["DummyMes"].ToString();
            }
        }

        public void Actualizar(String sql_stm, int state)
        {
            String msg = "";
            SqlCeConnection _con;
            String _c = ("DataSource=\"bdRegistros.sdf\"");
            _con = new SqlCeConnection(_c);
            _con.Open();
            SqlCeCommand _cmd;
            _cmd = _con.CreateCommand();
            _cmd.CommandText = sql_stm;
            _cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    _cmd.Parameters.AddWithValue("@Periodo", dprFecha.SelectedDate);
                    _cmd.Parameters.AddWithValue("@Efectivo", txtEfectivo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@InversionesTemporales", txtInversionesTemporales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorCobrar", txtCxC.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Inventarios", txtInventarios.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosCirculantes", txtOtrosActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosCirculantes", txtTotalActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EquiposYMaquinarias", txtEquiposYMaquinarias.Text.Trim());
                    _cmd.Parameters.AddWithValue("@BienesInmuebles", txtBienesInmuebles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Terrenos", txtTerrenos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ActivosIntangibles", txtActivosIntangibles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DepreciacionAcumulada", txtDepreciacionAcumulada.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosLargoPlazo", txtOtrosActivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosFijos", txtTotalActivosFijos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivos", txtTotalActivos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorPagar", txtCxP.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EfectosPorPagar", txtEfectosxPagar.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesLaborales", txtObligacionesLaborales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesFiscales", txtObligacionesFiscales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ProvisionesYContingencia", txtPrevisionesYContingencia.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosCirculantes", txtOtrosPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosCirculantes", txtTotalPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Bonos", txtBonos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosLargoPlazo", txtOtrosPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosLargoPlazo", txtTotalPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Capital", txtCapital.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadesRetenidas", txtUtilidadRetenida.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPatrimonio", txtTotalPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivoYPatrimonio", txtTotalPasivoYPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Ventas", txtVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Costos", txtCostos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadBruta", txtUtilidadBruta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosAdministrativos", txtGastosAdmin.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosVentas", txtGastosVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosOperativos", txtCostosOperacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBITDA", txtEbitda.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Depreciacion", txtDepreciacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosInversion", txtCostosInversion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBIT", txtEbit.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosInteres", txtIntereses.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFinancieros", txtCostosFinancieros.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadAntesImpuesto", txtUtilidadAntesImpuesto.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Impuestos", txtImpuestos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFiscales", txtCostosFisales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadNeta", txtUtilidadNeta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DummyMes", txtDummyMes.Text.Trim());
                    msg = "Registro guardado con exito";
                    break;
                case 1:
                    _cmd.Parameters.AddWithValue("@Periodo", dprFecha.SelectedDate);
                    msg = "Registro borrado con exito";
                    break;
            }
            try
            {
                int n = _cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    dgPeriodos.ItemsSource = BL_Instancia.UpdateDatagrid().DefaultView;
                    _con.Close();
                    MessageBox.Show(msg);
                    dprFecha.SelectedDate = null;                   
                    txtEfectivo.Text = "0";
                    txtInversionesTemporales.Text = "0";
                    txtCxC.Text = "0";
                    txtInventarios.Text = "0";
                    txtOtrosActivosCirculantes.Text = "0";
                    txtTotalActivosCirculantes.Text = "0";
                    txtEquiposYMaquinarias.Text = "0";
                    txtBienesInmuebles.Text = "0";
                    txtTerrenos.Text = "0";
                    txtActivosIntangibles.Text = "0";
                    txtDepreciacionAcumulada.Text = "0";
                    txtOtrosActivosLargoPlazo.Text = "0";
                    txtTotalActivosFijos.Text = "0";
                    txtTotalActivos.Text = "0";
                    txtCxP.Text = "0";
                    txtEfectosxPagar.Text = "0";
                    txtObligacionesLaborales.Text = "0";
                    txtObligacionesFiscales.Text = "0";
                    txtPrevisionesYContingencia.Text = "0";
                    txtOtrosPasivosCirculantes.Text = "0";
                    txtTotalPasivosCirculantes.Text = "0";
                    txtBonos.Text = "0";
                    txtOtrosPasivosLargoPlazo.Text = "0";
                    txtTotalPasivosLargoPlazo.Text = "0";
                    txtCapital.Text = "0";
                    txtUtilidadRetenida.Text = "0";
                    txtTotalPatrimonio.Text = "0";
                    txtTotalPasivoYPatrimonio.Text = "0";
                    txtVentas.Text = "0";
                    txtCostos.Text = "0";
                    txtUtilidadBruta.Text = "0";
                    txtGastosAdmin.Text = "0";
                    txtGastosVentas.Text = "0";
                    txtCostosOperacion.Text = "0";
                    txtEbitda.Text = "0";
                    txtDepreciacion.Text = "0";
                    txtCostosInversion.Text = "0";
                    txtEbit.Text = "0";
                    txtIntereses.Text = "0";
                    txtCostosFinancieros.Text = "0";
                    txtUtilidadAntesImpuesto.Text = "0";
                    txtImpuestos.Text = "0";
                    txtCostosFisales.Text = "0";
                    txtUtilidadNeta.Text = "0";
                    txtDummyMes.Text = "0";
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ResetAll()
        {
            dprFecha.SelectedDate = null;
            txtEfectivo.Text = "0";
            txtInversionesTemporales.Text = "0";
            txtCxC.Text = "0";
            txtInventarios.Text = "0";
            txtOtrosActivosCirculantes.Text = "0";
            txtTotalActivosCirculantes.Text = "0";
            txtEquiposYMaquinarias.Text = "0";
            txtBienesInmuebles.Text = "0";
            txtTerrenos.Text = "0";
            txtActivosIntangibles.Text = "0";
            txtDepreciacionAcumulada.Text = "0";
            txtOtrosActivosLargoPlazo.Text = "0";
            txtTotalActivosFijos.Text = "0";
            txtTotalActivos.Text = "0";
            txtCxP.Text = "0";
            txtEfectosxPagar.Text = "0";
            txtObligacionesLaborales.Text = "0";
            txtObligacionesFiscales.Text = "0";
            txtPrevisionesYContingencia.Text = "0";
            txtOtrosPasivosCirculantes.Text = "0";
            txtTotalPasivosCirculantes.Text = "0";
            txtBonos.Text = "0";
            txtOtrosPasivosLargoPlazo.Text = "0";
            txtTotalPasivosLargoPlazo.Text = "0";
            txtCapital.Text = "0";
            txtUtilidadRetenida.Text = "0";
            txtTotalPatrimonio.Text = "0";
            txtTotalPasivoYPatrimonio.Text = "0";
            txtVentas.Text = "0";
            txtCostos.Text = "0";
            txtUtilidadBruta.Text = "0";
            txtGastosAdmin.Text = "0";
            txtGastosVentas.Text = "0";
            txtCostosOperacion.Text = "0";
            txtEbitda.Text = "0";
            txtDepreciacion.Text = "0";
            txtCostosInversion.Text = "0";
            txtEbit.Text = "0";
            txtIntereses.Text = "0";
            txtCostosFinancieros.Text = "0";
            txtUtilidadAntesImpuesto.Text = "0";
            txtImpuestos.Text = "0";
            txtCostosFisales.Text = "0";
            txtUtilidadNeta.Text = "0";
            txtDummyMes.Text = "0";
        }

        private void DummyDelete_Loaded(object sender, RoutedEventArgs e)
        {
            DummyDelete.Text = ((MainWindow)System.Windows.Application.Current.MainWindow).DummySerie.Text;
        }
    }
}
