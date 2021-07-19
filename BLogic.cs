using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace GFC_V0
{
    class BLogic
    {
        SqlCeConnection _con;
        String _c = ("DataSource=\"bdRegistros.sdf\"");
        private SqlCeCommand _cmd;
        private SqlCeCommand _cmd1;
        private SqlCeCommand _cmd2;
        public void OpenConnection()
        {
            _con = new SqlCeConnection(_c);
            try
            {
                _con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexión", ex.Message);
            }
        }

        public void CloseConnection()
        {
            _con.Close();
        }

        public void CrearBaseDatos()
        {
            if (File.Exists("bdRegistros.sdf") == false)
            {
                SqlCeEngine en = new SqlCeEngine(_c);
                en.CreateDatabase();
                this.OpenConnection();
                _cmd = new SqlCeCommand(@"Create table Periodos(" +
                "Periodo                    datetime not null," +
                "Efectivo                   money not null," +
                "InversionesTemporales      money not null," +
                "CuentasPorCobrar           money not null," +
                "Inventarios                money not null," +
                "OtrosActivosCirculantes    money not null," +
                "TotalActivosCirculantes    money not null," +
                "EquiposYMaquinarias        money not null," +
                "BienesInmuebles            money not null," +
                "Terrenos                   money not null," +
                "ActivosIntangibles         money not null," +
                "DepreciacionAcumulada      money not null," +
                "OtrosActivosLargoPlazo     money not null," +
                "TotalActivosFijos          money not null," +
                "TotalActivos               money not null," +
                "CuentasPorPagar            money not null," +
                "EfectosPorPagar            money not null," +
                "ObligacionesLaborales      money not null," +
                "ObligacionesFiscales       money not null," +
                "ProvisionesYContingencia   money not null," +
                "OtrosPasivosCirculantes    money not null," +
                "TotalPasivosCirculantes    money not null," +
                "Bonos                      money not null," +
                "OtrosPasivosLargoPlazo     money not null," +
                "TotalPasivosLargoPlazo     money not null," +
                "Capital                    money not null," +
                "UtilidadesRetenidas        money not null," +
                "TotalPatrimonio            money not null," +
                "TotalPasivoYPatrimonio     money not null," +
                "Ventas                     money not null," +
                "Costos                     money not null," +
                "UtilidadBruta              money not null," +
                "GastosAdministrativos      money not null," +
                "GastosVentas               money not null," +
                "CostosOperativos           money not null," +
                "EBITDA                     money not null," +
                "Depreciacion               money not null," +
                "CostosInversion            money not null," +
                "EBIT                       money not null," +
                "GastosInteres              money not null," +
                "CostosFinancieros          money not null," +
                "UtilidadAntesImpuesto      money not null," +
                "Impuestos                  money not null," +
                "CostosFiscales             money not null," +
                "UtilidadNeta               money not null," +
                "DummyMes                   nvarchar(20) not null" +
                ")", _con);

                _cmd1 = new SqlCeCommand(@"Create table Info(" +
                "Name                       nvarchar(50) not null," +
                "Address                    nvarchar(120) not null," +
                "Type                       nvarchar(15) not null," +
                "NumEmploy                  int not null," +
                "FiscalMonth                nvarchar(15) not null," +
                "Wacc                       money not null," +
                "Tax                        money not null," +
                "Strategy                   nvarchar(25) not null," +
                "Objetives                  nvarchar(3) not null," +
                "Data                       datetime not null" +
                ")", _con);

                _cmd2 = new SqlCeCommand(@"Create table Mensual(" +
                "Periodo                    datetime not null," +
                "Efectivo                   money not null," +
                "InversionesTemporales      money not null," +
                "CuentasPorCobrar           money not null," +
                "Inventarios                money not null," +
                "OtrosActivosCirculantes    money not null," +
                "TotalActivosCirculantes    money not null," +
                "EquiposYMaquinarias        money not null," +
                "BienesInmuebles            money not null," +
                "Terrenos                   money not null," +
                "ActivosIntangibles         money not null," +
                "DepreciacionAcumulada      money not null," +
                "OtrosActivosLargoPlazo     money not null," +
                "TotalActivosFijos          money not null," +
                "TotalActivos               money not null," +
                "CuentasPorPagar            money not null," +
                "EfectosPorPagar            money not null," +
                "ObligacionesLaborales      money not null," +
                "ObligacionesFiscales       money not null," +
                "ProvisionesYContingencia   money not null," +
                "OtrosPasivosCirculantes    money not null," +
                "TotalPasivosCirculantes    money not null," +
                "Bonos                      money not null," +
                "OtrosPasivosLargoPlazo     money not null," +
                "TotalPasivosLargoPlazo     money not null," +
                "Capital                    money not null," +
                "UtilidadesRetenidas        money not null," +
                "TotalPatrimonio            money not null," +
                "TotalPasivoYPatrimonio     money not null," +
                "Ventas                     money not null," +
                "Costos                     money not null," +
                "UtilidadBruta              money not null," +
                "GastosAdministrativos      money not null," +
                "GastosVentas               money not null," +
                "CostosOperativos           money not null," +
                "EBITDA                     money not null," +
                "Depreciacion               money not null," +
                "CostosInversion            money not null," +
                "EBIT                       money not null," +
                "GastosInteres              money not null," +
                "CostosFinancieros          money not null," +
                "UtilidadAntesImpuesto      money not null," +
                "Impuestos                  money not null," +
                "CostosFiscales             money not null," +
                "UtilidadNeta               money not null," +
                "DummyMes                   nvarchar(20) not null" +
                ")", _con);

                try
                {
                    _cmd.ExecuteNonQuery();
                    _cmd1.ExecuteNonQuery();
                    _cmd2.ExecuteNonQuery();
                    MessageBox.Show("Base de datos creada con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la base de datos", ex.Message);
                }

                this.CloseConnection();
            }
            else
            {
                MessageBox.Show("Bienvenido de vuelta a GFC");
            }
        }

        public DataTable UpdateDatagrid()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            try
            {
                if (((MainWindow)System.Windows.Application.Current.MainWindow).rbtAnual.IsChecked == true)
                {
                    String comando = "Select * From Periodos order by Periodo desc";
                    SqlCeDataAdapter sqliteadapter = new SqlCeDataAdapter(comando, _con);
                    sqliteadapter.Fill(dt);
                    this.CloseConnection();
                }
                if (((MainWindow)System.Windows.Application.Current.MainWindow).rbtMensual.IsChecked == true)
                {
                    String comando = "Select * From Mensual order by Periodo desc";
                    SqlCeDataAdapter sqliteadapter = new SqlCeDataAdapter(comando, _con);
                    sqliteadapter.Fill(dt);
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar la base de datos", ex.Message);
            }
            return dt;
        }

        public void AD(String sql_stm, int state)
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
                    _cmd.Parameters.AddWithValue("@Periodo", ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.SelectedDate);
                    _cmd.Parameters.AddWithValue("@Efectivo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectivo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@InversionesTemporales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtInversionesTemporales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorCobrar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxC.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Inventarios", ((MainWindow)System.Windows.Application.Current.MainWindow).txtInventarios.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EquiposYMaquinarias", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEquiposYMaquinarias.Text.Trim());
                    _cmd.Parameters.AddWithValue("@BienesInmuebles", ((MainWindow)System.Windows.Application.Current.MainWindow).txtBienesInmuebles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Terrenos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTerrenos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ActivosIntangibles", ((MainWindow)System.Windows.Application.Current.MainWindow).txtActivosIntangibles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DepreciacionAcumulada", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacionAcumulada.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosFijos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosFijos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorPagar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxP.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EfectosPorPagar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectosxPagar.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesLaborales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesLaborales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesFiscales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesFiscales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ProvisionesYContingencia", ((MainWindow)System.Windows.Application.Current.MainWindow).txtPrevisionesYContingencia.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Bonos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtBonos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Capital", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCapital.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadesRetenidas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadRetenida.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPatrimonio", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivoYPatrimonio", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivoYPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Ventas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Costos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadBruta", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadBruta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosAdministrativos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosAdmin.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosVentas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosOperativos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosOperacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBITDA", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbitda.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Depreciacion", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosInversion", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosInversion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBIT", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbit.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosInteres", ((MainWindow)System.Windows.Application.Current.MainWindow).txtIntereses.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFinancieros", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFinancieros.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadAntesImpuesto", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadAntesImpuesto.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Impuestos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtImpuestos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFiscales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFisales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadNeta", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadNeta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DummyMes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDummyMes.Text.Trim());
                    msg = "Registro guardado con exito";
                    break;
                case 1:
                    msg = "Registro borrado con exito";
                    break;
            }
            try
            {
                int n = _cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    //dgPeriodos.ItemsSource = UpdateDatagrid().DefaultView;
                    _con.Close();
                    MessageBox.Show(msg);
                    ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoInfo.SelectedIndex = 0;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.SelectedDate = null;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.Background = Brushes.White;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectivo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtInversionesTemporales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxC.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtInventarios.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEquiposYMaquinarias.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtBienesInmuebles.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTerrenos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtActivosIntangibles.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacionAcumulada.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosFijos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxP.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectosxPagar.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesLaborales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesFiscales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtPrevisionesYContingencia.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtBonos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCapital.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadRetenida.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPatrimonio.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivoYPatrimonio.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtVentas.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadBruta.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosAdmin.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosVentas.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosOperacion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbitda.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosInversion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbit.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtIntereses.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFinancieros.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadAntesImpuesto.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtImpuestos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFisales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadNeta.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDummyMes.Text = "0";
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void AD2(String sql_stm, int state)
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
                    _cmd.Parameters.AddWithValue("@Periodo", ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.SelectedDate);
                    _cmd.Parameters.AddWithValue("@Efectivo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectivo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@InversionesTemporales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtInversionesTemporales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorCobrar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxC.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Inventarios", ((MainWindow)System.Windows.Application.Current.MainWindow).txtInventarios.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EquiposYMaquinarias", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEquiposYMaquinarias.Text.Trim());
                    _cmd.Parameters.AddWithValue("@BienesInmuebles", ((MainWindow)System.Windows.Application.Current.MainWindow).txtBienesInmuebles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Terrenos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTerrenos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ActivosIntangibles", ((MainWindow)System.Windows.Application.Current.MainWindow).txtActivosIntangibles.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DepreciacionAcumulada", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacionAcumulada.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosActivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivosFijos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosFijos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalActivos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CuentasPorPagar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxP.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EfectosPorPagar", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectosxPagar.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesLaborales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesLaborales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ObligacionesFiscales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesFiscales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@ProvisionesYContingencia", ((MainWindow)System.Windows.Application.Current.MainWindow).txtPrevisionesYContingencia.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosCirculantes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosCirculantes.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Bonos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtBonos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@OtrosPasivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivosLargoPlazo", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosLargoPlazo.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Capital", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCapital.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadesRetenidas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadRetenida.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPatrimonio", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@TotalPasivoYPatrimonio", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivoYPatrimonio.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Ventas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Costos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadBruta", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadBruta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosAdministrativos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosAdmin.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosVentas", ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosVentas.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosOperativos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosOperacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBITDA", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbitda.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Depreciacion", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosInversion", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosInversion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@EBIT", ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbit.Text.Trim());
                    _cmd.Parameters.AddWithValue("@GastosInteres", ((MainWindow)System.Windows.Application.Current.MainWindow).txtIntereses.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFinancieros", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFinancieros.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadAntesImpuesto", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadAntesImpuesto.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Impuestos", ((MainWindow)System.Windows.Application.Current.MainWindow).txtImpuestos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@CostosFiscales", ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFisales.Text.Trim());
                    _cmd.Parameters.AddWithValue("@UtilidadNeta", ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadNeta.Text.Trim());
                    _cmd.Parameters.AddWithValue("@DummyMes", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDummyMes.Text.Trim());
                    msg = "Registro guardado con exito";
                    break;
                case 1:
                    msg = "Registro borrado con exito";
                    break;
            }
            try
            {
                int n = _cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    //dgPeriodos.ItemsSource = UpdateDatagrid().DefaultView;
                    _con.Close();
                    MessageBox.Show(msg);
                    ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoInfo.SelectedIndex = 0;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.SelectedDate = null;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dprFecha.Background = Brushes.White;
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectivo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtInversionesTemporales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxC.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtInventarios.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEquiposYMaquinarias.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtBienesInmuebles.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTerrenos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtActivosIntangibles.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacionAcumulada.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosActivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivosFijos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalActivos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCxP.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEfectosxPagar.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesLaborales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtObligacionesFiscales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtPrevisionesYContingencia.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosCirculantes.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtBonos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtOtrosPasivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivosLargoPlazo.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCapital.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadRetenida.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPatrimonio.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtTotalPasivoYPatrimonio.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtVentas.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadBruta.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosAdmin.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtGastosVentas.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosOperacion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbitda.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDepreciacion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosInversion.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtEbit.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtIntereses.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFinancieros.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadAntesImpuesto.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtImpuestos.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtCostosFisales.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtUtilidadNeta.Text = "0";
                    ((MainWindow)System.Windows.Application.Current.MainWindow).txtDummyMes.Text = "0";
                }
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable UpdateInfoGeneral()
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            try
            {
                String comando = "Select * From Info order by Data desc";
                SqlCeDataAdapter sqliteadapter = new SqlCeDataAdapter(comando, _con);
                sqliteadapter.Fill(dt);
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar la base de datos", ex.Message);
            }
            return dt;
        }

        public void AD1(String sql_stm, int state)
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
                    _cmd.Parameters.AddWithValue("@Name", ((MainWindow)System.Windows.Application.Current.MainWindow).txtNombre.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Address", ((MainWindow)System.Windows.Application.Current.MainWindow).txtDireccion.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Type", ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoEmpresa.Text.Trim());
                    _cmd.Parameters.AddWithValue("@NumEmploy", ((MainWindow)System.Windows.Application.Current.MainWindow).txtNumeroEmpleados.Text.Trim());
                    _cmd.Parameters.AddWithValue("@FiscalMonth", ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Wacc", ((MainWindow)System.Windows.Application.Current.MainWindow).txtWACC.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Tax", ((MainWindow)System.Windows.Application.Current.MainWindow).txtTax.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Strategy", ((MainWindow)System.Windows.Application.Current.MainWindow).cbxEstrategia.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Objetives", ((MainWindow)System.Windows.Application.Current.MainWindow).cbxObjetivos.Text.Trim());
                    _cmd.Parameters.AddWithValue("@Data", ((MainWindow)System.Windows.Application.Current.MainWindow).dprInfo.SelectedDate);
                    msg = "Registro guardado con exito";
                    break;
                case 1:
                    msg = "Registro borrado con exito";
                    break;
            }
            try
            {
                int n = _cmd.ExecuteNonQuery();
                _con.Close();
                MessageBox.Show(msg);
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string ObtenerNumeroMes(string NombreMes)
        {
            string NumeroMes;
            switch (NombreMes)
            {
                case ("January"):
                    NumeroMes = "1";
                    return NumeroMes;
                case ("February"):
                    NumeroMes = "2";
                    return NumeroMes;
                case ("March"):
                    NumeroMes = "3";
                    return NumeroMes;
                case ("April"):
                    NumeroMes = "4";
                    return NumeroMes;
                case ("May"):
                    NumeroMes = "5";
                    return NumeroMes;
                case ("June"):
                    NumeroMes = "6";
                    return NumeroMes;
                case ("July"):
                    NumeroMes = "7";
                    return NumeroMes;
                case ("August"):
                    NumeroMes = "8";
                    return NumeroMes;
                case ("September"):
                    NumeroMes = "9";
                    return NumeroMes;
                case ("October"):
                    NumeroMes = "10";
                    return NumeroMes;
                case ("November"):
                    NumeroMes = "11";
                    return NumeroMes;
                case ("December"):
                    NumeroMes = "12";
                    return NumeroMes;
                default:
                    return "ERROR";
            }
        }/////////

        public DataTable BGAH()//Balance General-Análisis Horizontal
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerie.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 10; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                //Agregar el min que es el limite de las columnas
                for (int i = 0; i < min; i++)
                {
                    string newColName = InputOrdenar.Rows[i][0].ToString();
                    tablaOrdenada.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= 28; rCount++)// Este valor corresponde al numero de linea de la tabla donde esta la cuenta Total Pasivo&Patrimonio           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                for (int k = 0; k < min; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < (min); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        if ((c) < min)
                        {
                            double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                            double valor2 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c) + 1]);
                            double resultado;
                            if (valor2 != 0)
                            {
                                resultado = ((valor1 - valor2) / valor2);
                                Calculo.Rows[fila][c] = resultado.ToString("P");
                                fila++;
                            }
                            if (valor2 == 0)
                            {
                                Calculo.Rows[fila][c] = "-";
                                fila++;
                            }
                        }
                        if (c == min)
                        {
                            Calculo.Rows[fila][c] = "-";
                            fila++;
                        }
                    }
                }
                Output = Calculo;
            }
            else //tipoSerie = "Mensual"
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                string fecha = InputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-366);
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 12; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                int counter1;
                //int counter2 = 0;
                //Agregar el min que es el limite de las columnas. 
                for (int i = 0; i < min; i++)//Define el nombre de la columna, especificamente la fecha que es el nombre de la columna
                {

                    DateTime control = DateTime.Parse(InputOrdenar.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = InputOrdenar.Rows[i][0].ToString();// "Columna #" + i;
                        tablaOrdenada.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= 28; rCount++)// Agregar el nombre de la fila. El valor corresponde al numero de linea de la tabla donde esta la cuenta Total Pasivo&Patrimonio           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();// "Nombre de columna rCount:" + rCount;// //Define el nombre de la fila
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][0].ToString(); //"Valor [cCount][rCount]" + cCount + ",/," + rCount; //
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][rCount].ToString();// "Valor [cCount][rCount]" + cCount + ",/," + rCount; // 
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                counter1 = tablaOrdenada.Columns.Count - 1;
                //Se crean los encabezados de cada columna
                for (int k = 0; k < counter1; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < (counter1); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        if ((c) < counter1)
                        {
                            double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                            double valor2 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c) + 1]);
                            double resultado;
                            if (valor2 != 0)
                            {
                                resultado = ((valor1 - valor2) / valor2);
                                Calculo.Rows[fila][c] = resultado.ToString("P");
                                fila++;
                            }
                            if (valor2 == 0)
                            {
                                Calculo.Rows[fila][c] = "-";
                                fila++;
                            }
                        }
                        if (c == counter1)
                        {
                            Calculo.Rows[fila][c] = "-";
                            fila++;
                        }
                    }
                }
                Output = Calculo;
            }
            return Output;
        }

        public DataTable BGAV()//Balance General-Análisis Vertical
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerie.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 10; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                //Agregar el min que es el limite de las columnas
                for (int i = 0; i < min; i++)
                {
                    string newColName = InputOrdenar.Rows[i][0].ToString();
                    tablaOrdenada.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= 28; rCount++)// Este valor corresponde al numero de linea de la tabla donde esta la cuenta Total Pasivo&Patrimonio           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                for (int k = 0; k <= min; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= (min); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                        double valor2 = Convert.ToDouble(tablaOrdenada.Rows[27][(c)]);
                        double resultado;
                        resultado = (valor1 / valor2);
                        Calculo.Rows[fila][c] = resultado.ToString("P");
                        fila++;
                    }
                }
                Output = Calculo;
            }
            else //tipoSerie = "Mensual"
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                string fecha = InputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-366);
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 12; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                int counter1;
                //Agregar el min que es el limite de las columnas. 
                for (int i = 0; i < min; i++)//Define el nombre de la columna, especificamente la fecha que es el nombre de la columna
                {

                    DateTime control = DateTime.Parse(InputOrdenar.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = InputOrdenar.Rows[i][0].ToString();
                        tablaOrdenada.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= 28; rCount++)// Agregar el nombre de la fila. El valor corresponde al numero de linea de la tabla donde esta la cuenta Total Pasivo&Patrimonio           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][0].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                counter1 = tablaOrdenada.Columns.Count - 1;
                //Se crean los encabezados de cada columna
                for (int k = 0; k <= counter1; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= (counter1); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                        double valor2 = Convert.ToDouble(tablaOrdenada.Rows[27][(c)]);
                        double resultado;
                        resultado = (valor1 / valor2);
                        Calculo.Rows[fila][c] = resultado.ToString("P");
                        fila++;
                    }
                }
                Output = Calculo;
            }
            return Output;
        }

        public DataTable ERAH()//Balance General-Análisis Horizontal
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerie.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 10; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                //Agregar el min que es el limite de las columnas
                for (int i = 0; i < min; i++)
                {
                    string newColName = InputOrdenar.Rows[i][0].ToString();
                    tablaOrdenada.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 29; rCount <= 44; rCount++)// Este valor corresponde al numero de linea de la tabla donde estan las cuentas de ventas y utilidad neta           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                for (int k = 0; k < min; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < (min); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        if ((c) < min)
                        {
                            double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                            double valor2 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c) + 1]);
                            double resultado;
                            if (valor2 != 0)
                            {
                                resultado = ((valor1 - valor2) / valor2);
                                Calculo.Rows[fila][c] = resultado.ToString("P");
                                fila++;
                            }
                            if (valor2 == 0)
                            {
                                Calculo.Rows[fila][c] = "-";
                                fila++;
                            }
                        }
                        if (c == min)
                        {
                            Calculo.Rows[fila][c] = "-";
                            fila++;
                        }
                    }
                }
                Output = Calculo;
            }
            else //tipoSerie = "Mensual"
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                string fecha = InputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-366);
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 12; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                int counter1;
                //Agregar el min que es el limite de las columnas. 
                for (int i = 0; i < min; i++)//Define el nombre de la columna, especificamente la fecha que es el nombre de la columna
                {

                    DateTime control = DateTime.Parse(InputOrdenar.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = InputOrdenar.Rows[i][0].ToString();
                        tablaOrdenada.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 29; rCount <= 44; rCount++)// Agregar el nombre de la fila. El valor corresponde al numero de linea de la tabla donde estan las cuentas de ventas y utilidad neta           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][0].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                counter1 = tablaOrdenada.Columns.Count - 1;
                //Se crean los encabezados de cada columna
                for (int k = 0; k < counter1; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < (counter1); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        if ((c) < counter1)
                        {
                            double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                            double valor2 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c) + 1]);
                            double resultado;
                            if (valor2 != 0)
                            {
                                resultado = ((valor1 - valor2) / valor2);
                                Calculo.Rows[fila][c] = resultado.ToString("P");
                                fila++;
                            }
                            if (valor2 == 0)
                            {
                                Calculo.Rows[fila][c] = "-";
                                fila++;
                            }
                        }
                        if (c == counter1)
                        {
                            Calculo.Rows[fila][c] = "-";
                            fila++;
                        }
                    }
                }
                Output = Calculo;
            }
            return Output;
        }

        public DataTable ERAV()//Balance General-Análisis Vertical
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerie.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 10; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                //Agregar el min que es el limite de las columnas
                for (int i = 0; i < min; i++)
                {
                    string newColName = InputOrdenar.Rows[i][0].ToString();
                    tablaOrdenada.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 29; rCount <= 44; rCount++)// Este valor corresponde al numero de linea de la tabla donde estan las cuentas de ventas y utilidad neta          
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                for (int k = 0; k <= min; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= (min); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                        double valor2 = Convert.ToDouble(tablaOrdenada.Rows[0][(c)]);
                        double resultado;
                        resultado = (valor1 / valor2);
                        Calculo.Rows[fila][c] = resultado.ToString("P");
                        fila++;
                    }
                }
                Output = Calculo;
            }
            else //tipoSerie = "Mensual"
            {
                DataTable InputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(InputOrdenar);
                this.CloseConnection();
                string fecha = InputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-366);
                DataTable tablaOrdenada = new DataTable();
                //Encabezado Primera columna
                tablaOrdenada.Columns.Add(InputOrdenar.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas                
                int num = 12; // num: numero de columnas a mostrar
                int tam = InputOrdenar.Rows.Count;
                int min = Math.Min(num, tam);
                int counter1;
                //Agregar el min que es el limite de las columnas. 
                for (int i = 0; i < min; i++)//Define el nombre de la columna, especificamente la fecha que es el nombre de la columna
                {

                    DateTime control = DateTime.Parse(InputOrdenar.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = InputOrdenar.Rows[i][0].ToString();
                        tablaOrdenada.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 29; rCount <= 44; rCount++)// Agregar el nombre de la fila. El valor corresponde al numero de linea de la tabla donde estan las cuentas de ventas y utilidad neta           
                {
                    DataRow newRow = tablaOrdenada.NewRow();
                    newRow[0] = InputOrdenar.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (InputOrdenar.Rows.Count < min)
                    {
                        for (int cCount = 0; cCount <= InputOrdenar.Rows.Count - 1; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][0].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < min; cCount++)
                        {
                            DateTime control = DateTime.Parse(InputOrdenar.Rows[cCount][0].ToString());
                            if (control > limite)
                            {
                                string colValue = InputOrdenar.Rows[cCount][rCount].ToString();
                                newRow[cCount + 1] = colValue;
                            }
                        }
                        tablaOrdenada.Rows.Add(newRow);
                    }
                }
                //Metodo para insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                counter1 = tablaOrdenada.Columns.Count - 1;
                //Se crean los encabezados de cada columna
                for (int k = 0; k <= counter1; k++)
                {
                    Calculo.Columns.Add(tablaOrdenada.Columns[k].ColumnName.ToString());
                }
                //Se introducen los datos de las columnas input
                foreach (DataRow dc in tablaOrdenada.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= (counter1); c++)
                {
                    int fila = 0;
                    foreach (DataRow dc in tablaOrdenada.Rows)
                    {
                        double valor1 = Convert.ToDouble(tablaOrdenada.Rows[fila][(c)]);
                        double valor2 = Convert.ToDouble(tablaOrdenada.Rows[0][(c)]);
                        double resultado;
                        resultado = (valor1 / valor2);
                        Calculo.Rows[fila][c] = resultado.ToString("P");
                        fila++;
                    }
                }
                Output = Calculo;
            }
            return Output;
        }

        //Indices de liquidez
        public DataTable CalcularIndicesI()
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(inputOrdenar.Columns[0].ColumnName);
                Calculo.Columns.Add("1.1. Razón corriente");
                Calculo.Columns.Add("1.2. Prueba ácida");
                Calculo.Columns.Add("1.3. Índice de liquidez");
                Calculo.Columns.Add("1.4. Ciclo de conversión de caja (días)");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                foreach (DataRow dc in inputOrdenar.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= Calculo.Columns.Count; c++)
                {
                    switch (c)
                    {
                        //Current ratio
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double CurrentAsset = Convert.ToDouble(inputOrdenar.Rows[fila][(6)]);
                                double CurrentLiability = Convert.ToDouble(inputOrdenar.Rows[fila][(21)]);
                                double r;
                                r = (CurrentAsset / CurrentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila][c] = R.ToString();
                                fila++;
                            }
                            break;
                        //Quick ratio
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double efectivo = Convert.ToDouble(inputOrdenar.Rows[fila1][(1)]);
                                double invtemp = Convert.ToDouble(inputOrdenar.Rows[fila1][(2)]);
                                double cxc = Convert.ToDouble(inputOrdenar.Rows[fila1][(3)]);
                                double currentLiability = Convert.ToDouble(inputOrdenar.Rows[fila1][(21)]);
                                double r;
                                r = ((efectivo + invtemp + cxc) / currentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila1][c] = R.ToString();
                                fila1++;
                            }
                            break;
                        //Cash ratio
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double efectivo = Convert.ToDouble(inputOrdenar.Rows[fila2][(1)]);
                                double invtemp = Convert.ToDouble(inputOrdenar.Rows[fila2][(2)]);
                                double currentLiability = Convert.ToDouble(inputOrdenar.Rows[fila2][(21)]);
                                double r;
                                r = ((efectivo + invtemp) / currentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila2][c] = R.ToString();
                                fila2++;
                            }
                            break;
                        //Cash conversion cycle
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila3 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(inputOrdenar.Rows[fila3][(30)]);
                                    double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila3 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila3][(4)]);
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias
                                    double venta = Convert.ToDouble(inputOrdenar.Rows[fila3][(29)]);
                                    double cxc0 = Convert.ToDouble(inputOrdenar.Rows[fila3 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(inputOrdenar.Rows[fila3][(3)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double cxp0 = Convert.ToDouble(inputOrdenar.Rows[fila3 + 1][(15)]);
                                    double cxp1 = Convert.ToDouble(inputOrdenar.Rows[fila3][(15)]);
                                    double r = 0;
                                    r = ((dias / (costos / ((Inv0 + Inv1) / 2))) + (dias / (venta / ((cxc0 + cxc1) / 2))) - (dias / (compras / ((cxp0 + cxp1) / 2))));
                                    Calculo.Rows[fila3][c] = string.Format("{0:####.##}", r);
                                    fila3++;
                                }
                            }
                            break;
                    }
                }
                //Transponer los valores para la presentación final
                DataTable tablaIndices = new DataTable();
                //Encabezado Primera columna
                tablaIndices.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                // num: numero de columnas a mostrar
                int num = 10; //Caso Anual
                int tam = Calculo.Rows.Count;
                int min = Math.Min(num, tam);
                if (tam < num)
                {
                    foreach (DataRow inRow in Calculo.Rows)
                    {
                        string newColName = inRow[0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        string newColName = Calculo.Rows[i][0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = tablaIndices.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (Calculo.Rows.Count < num)
                    {
                        for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < num; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                }
                return tablaIndices;
            }
            else //tipoSerie == "mes"
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                string fecha = inputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-320);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
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
                int counter1 = 0;
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(Transition.Columns[0].ColumnName);
                Calculo.Columns.Add("1.1. Razón corriente");
                Calculo.Columns.Add("1.2. Prueba ácida");
                Calculo.Columns.Add("1.3. Índice de liquidez");
                Calculo.Columns.Add("1.4. Ciclo de conversión de caja (días)");
                // se importan las fechas de los ultimos 12 meses               
                for (int i = 0; i < Transition.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(Transition.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = Transition.Rows[i][0].ToString();
                        Calculo.Rows.Add(newColName);
                    }
                }
                counter1 = Calculo.Columns.Count;
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < counter1; c++)
                {
                    switch (c)
                    {
                        //Current ratio
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double CurrentAsset = Convert.ToDouble(Transition.Rows[fila][(6)]);
                                double CurrentLiability = Convert.ToDouble(Transition.Rows[fila][(21)]);
                                double r;
                                r = (CurrentAsset / CurrentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila][c] = R.ToString();
                                fila++;
                            }
                            break;
                        //Quick ratio
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double efectivo = Convert.ToDouble(Transition.Rows[fila1][(1)]);
                                double invtemp = Convert.ToDouble(Transition.Rows[fila1][(2)]);
                                double cxc = Convert.ToDouble(Transition.Rows[fila1][(3)]);
                                double currentLiability = Convert.ToDouble(Transition.Rows[fila1][(21)]);
                                double r;
                                r = ((efectivo + invtemp + cxc) / currentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila1][c] = R.ToString();
                                fila1++;
                            }
                            break;
                        //Cash ratio
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double efectivo = Convert.ToDouble(Transition.Rows[fila2][(1)]);
                                double invtemp = Convert.ToDouble(Transition.Rows[fila2][(2)]);
                                double currentLiability = Convert.ToDouble(Transition.Rows[fila2][(21)]);
                                double r;
                                r = ((efectivo + invtemp) / currentLiability);
                                double R = Math.Round(r, 2);
                                Calculo.Rows[fila2][c] = R.ToString();
                                fila2++;
                            }
                            break;
                        //Cash conversion cycle
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila3 + 1 < Transition.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(Transition.Rows[fila3][(30)]);
                                    double Inv0 = Convert.ToDouble(Transition.Rows[fila3 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(Transition.Rows[fila3][(4)]);
                                    double dias = 30; // Dias durante el periodo. Este caso -> Periodo mensual = 30 dias
                                    double venta = Convert.ToDouble(Transition.Rows[fila3][(29)]);
                                    double cxc0 = Convert.ToDouble(Transition.Rows[fila3 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(Transition.Rows[fila3][(3)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double cxp0 = Convert.ToDouble(Transition.Rows[fila3 + 1][(15)]);
                                    double cxp1 = Convert.ToDouble(Transition.Rows[fila3][(15)]);
                                    double r = 0;
                                    r = ((dias / (costos / ((Inv0 + Inv1) / 2))) + (dias / (venta / ((cxc0 + cxc1) / 2))) - (dias / (compras / ((cxp0 + cxp1) / 2)))) * (365 / dias);
                                    Calculo.Rows[fila3][c] = string.Format("{0:####.##}", r);
                                    fila3++;
                                }
                            }
                            break;
                    }
                }
                //Tansponer tabla para la presentación final
                DataTable CalculoTranspose = new DataTable();
                //Encabezado Primera columna
                CalculoTranspose.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                foreach (DataRow inRow in Calculo.Rows)
                {
                    string newColName = inRow[0].ToString();
                    CalculoTranspose.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = CalculoTranspose.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                    {
                        string colValue = Calculo.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    CalculoTranspose.Rows.Add(newRow);
                }
                return CalculoTranspose;
            }
        }

        //Indices de actividad
        public DataTable CalcularIndicesII()
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(inputOrdenar.Columns[0].ColumnName);
                Calculo.Columns.Add("2.1. Rotación de inventarios");
                Calculo.Columns.Add("2.2. Días de inventario en mano");
                Calculo.Columns.Add("2.3. Rotación de cuentas por cobrar");
                Calculo.Columns.Add("2.4. Días de cuentas por cobrar");
                Calculo.Columns.Add("2.5. Rotación de cuentas por pagar");
                Calculo.Columns.Add("2.6. Días de cuentas por pagar");
                Calculo.Columns.Add("2.7. Rotación de capital de trabajo");
                Calculo.Columns.Add("2.8. Rotación de activos fijos");
                Calculo.Columns.Add("2.9. Rotación de activos totales");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                foreach (DataRow dc in inputOrdenar.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= Calculo.Columns.Count; c++)
                {
                    switch (c)
                    {
                        //Rotacion de inventarios
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila + 1 < inputOrdenar.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(inputOrdenar.Rows[fila][(30)]);
                                    double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila][(4)]);
                                    double r = 0;
                                    r = Math.Round(((costos / ((Inv0 + Inv1) / 2))), 2); //((costos / ((Inv0 + Inv1) / 2)));
                                    Calculo.Rows[fila][c] = r; //string.Format("{0:####.##}", r);
                                    fila++;
                                }
                            }
                            break;
                        //Dias de inventario en mano
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila1 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(inputOrdenar.Rows[fila1][(30)]);
                                    double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila1 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila1][(4)]);
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias                                
                                    double r = 0;
                                    r = Math.Round((dias / ((costos / ((Inv0 + Inv1) / 2)))), 2);
                                    Calculo.Rows[fila1][c] = r;
                                    fila1++;
                                }
                            }
                            break;
                        //rotacion de cuentas por cobrar
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila2 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(inputOrdenar.Rows[fila2][(29)]);
                                    double cxc0 = Convert.ToDouble(inputOrdenar.Rows[fila2 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(inputOrdenar.Rows[fila2][(3)]);
                                    double r = 0;
                                    r = Math.Round(((ventas / ((cxc0 + cxc1) / 2))), 2);
                                    Calculo.Rows[fila2][c] = r;
                                    fila2++;
                                }
                            }
                            break;
                        //Dias de cuentas por cobrar
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila3 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(inputOrdenar.Rows[fila3][(29)]);
                                    double cxc0 = Convert.ToDouble(inputOrdenar.Rows[fila3 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(inputOrdenar.Rows[fila3][(3)]);
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias        
                                    double r = 0;
                                    r = Math.Round((dias / ((ventas / ((cxc0 + cxc1) / 2)))), 2);
                                    Calculo.Rows[fila3][c] = r;
                                    fila3++;
                                }
                            }
                            break;
                        //Rotacion de cuentas por pagar
                        case 5:
                            int fila4 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila4 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double cxp0 = Convert.ToDouble(inputOrdenar.Rows[fila4 + 1][(3)]);
                                    double cxp1 = Convert.ToDouble(inputOrdenar.Rows[fila4][(3)]);
                                    double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila4 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila4][(4)]);
                                    double costos = Convert.ToDouble(inputOrdenar.Rows[fila4][(30)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double r = 0;
                                    r = Math.Round(((compras / ((cxp0 + cxp1) / 2))), 2);
                                    Calculo.Rows[fila4][c] = r;
                                    fila4++;
                                }
                            }
                            break;
                        //Dias de cuentas por pagar
                        case 6:
                            int fila5 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila5 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double cxp0 = Convert.ToDouble(inputOrdenar.Rows[fila5 + 1][(3)]);
                                    double cxp1 = Convert.ToDouble(inputOrdenar.Rows[fila5][(3)]);
                                    double Inv0 = Convert.ToDouble(inputOrdenar.Rows[fila5 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(inputOrdenar.Rows[fila5][(4)]);
                                    double costos = Convert.ToDouble(inputOrdenar.Rows[fila5][(30)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias        
                                    double r = 0;
                                    r = Math.Round((dias / ((compras / ((cxp0 + cxp1) / 2)))), 2);
                                    Calculo.Rows[fila5][c] = r;
                                    fila5++;
                                }
                            }
                            break;
                        //Rotacion de capital de trabajo
                        case 7:
                            int fila6 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila6 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(inputOrdenar.Rows[fila6][(29)]);
                                    double activosCirculantes0 = Convert.ToDouble(inputOrdenar.Rows[fila6 + 1][(6)]);
                                    double activosCirculantes1 = Convert.ToDouble(inputOrdenar.Rows[fila6][(6)]);
                                    double pasivosCirculantes0 = Convert.ToDouble(inputOrdenar.Rows[fila6 + 1][(21)]);
                                    double pasivosCirculantes1 = Convert.ToDouble(inputOrdenar.Rows[fila6][(21)]);
                                    double promedio = (((activosCirculantes0 - pasivosCirculantes0) + (activosCirculantes1 - pasivosCirculantes1)) / 2);
                                    double r = 0;
                                    r = Math.Round((ventas / promedio), 2);
                                    Calculo.Rows[fila6][c] = r;
                                    fila6++;
                                }
                            }
                            break;
                        //Rotacion de activos fijos
                        case 8:
                            int fila7 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila7 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(inputOrdenar.Rows[fila7][(29)]);
                                    double activosFijos0 = Convert.ToDouble(inputOrdenar.Rows[fila7 + 1][(13)]);
                                    double activosFijos1 = Convert.ToDouble(inputOrdenar.Rows[fila7][(13)]);
                                    double r = 0;
                                    r = Math.Round((ventas / ((activosFijos0 + activosFijos1) / 2)), 2);
                                    Calculo.Rows[fila7][c] = r;
                                    fila7++;
                                }
                            }
                            break;
                        //Rotacion de activos totales
                        case 9:
                            int fila8 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila8 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(inputOrdenar.Rows[fila8][(29)]);
                                    double activosTotal0 = Convert.ToDouble(inputOrdenar.Rows[fila8 + 1][(14)]);
                                    double activosTotal1 = Convert.ToDouble(inputOrdenar.Rows[fila8][(14)]);
                                    double r = 0;
                                    r = Math.Round((ventas / ((activosTotal0 + activosTotal1) / 2)), 2);
                                    Calculo.Rows[fila8][c] = r;
                                    fila8++;
                                }
                            }
                            break;
                    }
                }
                //Transponer los valores para la presentación final
                DataTable tablaIndices = new DataTable();
                //Encabezado Primera columna
                tablaIndices.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                // num: numero de columnas a mostrar
                int num = 10; //Caso Anual
                int tam = Calculo.Rows.Count;
                int min = Math.Min(num, tam);
                if (tam < num)
                {
                    foreach (DataRow inRow in Calculo.Rows)
                    {
                        string newColName = inRow[0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        string newColName = Calculo.Rows[i][0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = tablaIndices.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (Calculo.Rows.Count < num)
                    {
                        for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < num; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                }
                return tablaIndices;
            }
            else //tipoSerie == "mes"
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                string fecha = inputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-360);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
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
                int counter1 = 0;
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(Transition.Columns[0].ColumnName);
                Calculo.Columns.Add("2.1. Rotación de inventarios");
                Calculo.Columns.Add("2.2. Días de inventario en mano");
                Calculo.Columns.Add("2.3. Rotación de cuentas por cobrar");
                Calculo.Columns.Add("2.4. Días de cuentas por cobrar");
                Calculo.Columns.Add("2.5. Rotación de cuentas por pagar");
                Calculo.Columns.Add("2.6. Días de cuentas por pagar");
                Calculo.Columns.Add("2.7. Rotación de capital de trabajo");
                Calculo.Columns.Add("2.8. Rotación de activos fijos");
                Calculo.Columns.Add("2.9. Rotación de activos totales");
                // se importan las fechas de los ultimos 12 meses               
                for (int i = 0; i < Transition.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(Transition.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = Transition.Rows[i][0].ToString();
                        Calculo.Rows.Add(newColName);
                    }
                }
                counter1 = Calculo.Columns.Count;
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < counter1; c++)
                {
                    switch (c)
                    {
                        //Rotacion de inventarios
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila + 1 < Transition.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(Transition.Rows[fila][(30)]);
                                    double Inv0 = Convert.ToDouble(Transition.Rows[fila + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(Transition.Rows[fila][(4)]);
                                    double r = 0;
                                    r = Math.Round(((costos / ((Inv0 + Inv1) / 2))), 2);
                                    Calculo.Rows[fila][c] = r;
                                    fila++;
                                }
                            }
                            break;
                        //Dias de inventario en mano
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila1 + 1 < Transition.Rows.Count)
                                {
                                    double costos = Convert.ToDouble(Transition.Rows[fila1][(30)]);
                                    double Inv0 = Convert.ToDouble(Transition.Rows[fila1 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(Transition.Rows[fila1][(4)]);
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias                                
                                    double r = 0;
                                    r = Math.Round((dias / ((costos / ((Inv0 + Inv1) / 2)))), 2);
                                    Calculo.Rows[fila1][c] = r;
                                    fila1++;
                                }
                            }
                            break;
                        //rotacion de cuentas por cobrar
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila2 + 1 < Transition.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(Transition.Rows[fila2][(29)]);
                                    double cxc0 = Convert.ToDouble(Transition.Rows[fila2 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(Transition.Rows[fila2][(3)]);
                                    double r = 0;
                                    r = Math.Round(((ventas / ((cxc0 + cxc1) / 2))), 2);
                                    Calculo.Rows[fila2][c] = r;
                                    fila2++;
                                }
                            }
                            break;
                        //Dias de cuentas por cobrar
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila3 + 1 < Transition.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(Transition.Rows[fila3][(29)]);
                                    double cxc0 = Convert.ToDouble(Transition.Rows[fila3 + 1][(3)]);
                                    double cxc1 = Convert.ToDouble(Transition.Rows[fila3][(3)]);
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias        
                                    double r = 0;
                                    r = Math.Round((dias / ((ventas / ((cxc0 + cxc1) / 2)))), 2);
                                    Calculo.Rows[fila3][c] = r;
                                    fila3++;
                                }
                            }
                            break;
                        //Rotacion de cuentas por pagar
                        case 5:
                            int fila4 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila4 + 1 < Transition.Rows.Count)
                                {
                                    double cxp0 = Convert.ToDouble(Transition.Rows[fila4 + 1][(3)]);
                                    double cxp1 = Convert.ToDouble(Transition.Rows[fila4][(3)]);
                                    double Inv0 = Convert.ToDouble(Transition.Rows[fila4 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(Transition.Rows[fila4][(4)]);
                                    double costos = Convert.ToDouble(Transition.Rows[fila4][(30)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double r = 0;
                                    r = Math.Round(((compras / ((cxp0 + cxp1) / 2))), 2);
                                    Calculo.Rows[fila4][c] = r;
                                    fila4++;
                                }
                            }
                            break;
                        //Dias de cuentas por pagar
                        case 6:
                            int fila5 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila5 + 1 < Transition.Rows.Count)
                                {
                                    double cxp0 = Convert.ToDouble(Transition.Rows[fila5 + 1][(3)]);
                                    double cxp1 = Convert.ToDouble(Transition.Rows[fila5][(3)]);
                                    double Inv0 = Convert.ToDouble(Transition.Rows[fila5 + 1][(4)]);
                                    double Inv1 = Convert.ToDouble(Transition.Rows[fila5][(4)]);
                                    double costos = Convert.ToDouble(Transition.Rows[fila5][(30)]);
                                    double compras = Inv1 + costos - Inv0;
                                    double dias = 365; // Dias durante el periodo. Este caso -> Periodo anual = 365 dias        
                                    double r = 0;
                                    r = Math.Round((dias / ((compras / ((cxp0 + cxp1) / 2)))), 2);
                                    Calculo.Rows[fila5][c] = r;
                                    fila5++;
                                }
                            }
                            break;
                        //Rotacion de capital de trabajo
                        case 7:
                            int fila6 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila6 + 1 < Transition.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(Transition.Rows[fila6][(29)]);
                                    double activosCirculantes0 = Convert.ToDouble(Transition.Rows[fila6 + 1][(6)]);
                                    double activosCirculantes1 = Convert.ToDouble(Transition.Rows[fila6][(6)]);
                                    double pasivosCirculantes0 = Convert.ToDouble(Transition.Rows[fila6 + 1][(21)]);
                                    double pasivosCirculantes1 = Convert.ToDouble(Transition.Rows[fila6][(21)]);
                                    double promedio = (((activosCirculantes0 - pasivosCirculantes0) + (activosCirculantes1 - pasivosCirculantes1)) / 2);
                                    double r = 0;
                                    r = Math.Round((ventas / promedio), 2);
                                    Calculo.Rows[fila6][c] = r;
                                    fila6++;
                                }
                            }
                            break;
                        //Rotacion de capital de trabajo
                        case 8:
                            int fila7 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila7 + 1 < Transition.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(Transition.Rows[fila7][(29)]);
                                    double activosFijos0 = Convert.ToDouble(Transition.Rows[fila7 + 1][(13)]);
                                    double activosFijos1 = Convert.ToDouble(Transition.Rows[fila7][(13)]);
                                    double r = 0;
                                    r = Math.Round((ventas / ((activosFijos0 + activosFijos1) / 2)), 2);
                                    Calculo.Rows[fila7][c] = r;
                                    fila7++;
                                }
                            }
                            break;
                        //Rotacion de capital de trabajo
                        case 9:
                            int fila8 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila8 + 1 < Transition.Rows.Count)
                                {
                                    double ventas = Convert.ToDouble(Transition.Rows[fila8][(29)]);
                                    double activosTotal0 = Convert.ToDouble(Transition.Rows[fila8 + 1][(14)]);
                                    double activosTotal1 = Convert.ToDouble(Transition.Rows[fila8][(14)]);
                                    double r = 0;
                                    r = Math.Round((ventas / ((activosTotal0 + activosTotal1) / 2)), 2);
                                    Calculo.Rows[fila8][c] = r;
                                    fila8++;
                                }
                            }
                            break;
                    }
                }
                //Tansponer tabla para la presentación final
                DataTable CalculoTranspose = new DataTable();
                //Encabezado Primera columna
                CalculoTranspose.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                foreach (DataRow inRow in Calculo.Rows)
                {
                    string newColName = inRow[0].ToString();
                    CalculoTranspose.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = CalculoTranspose.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                    {
                        string colValue = Calculo.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    CalculoTranspose.Rows.Add(newRow);
                }
                return CalculoTranspose;
            }
        }

        //Indices de solvencia
        public DataTable CalcularIndicesIII()
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(inputOrdenar.Columns[0].ColumnName);
                Calculo.Columns.Add("3.1. Razón de endeudamiento");
                Calculo.Columns.Add("3.2. Razón deuda/patrimonio");
                Calculo.Columns.Add("3.3. Razón de apalancamiento financiero");
                Calculo.Columns.Add("3.4. Cobertura de intereses");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                foreach (DataRow dc in inputOrdenar.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= Calculo.Columns.Count; c++)
                {
                    switch (c)
                    {
                        //Razon de endeudamiento
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double totalDebt = Convert.ToDouble(inputOrdenar.Rows[fila][(24)]);// + Convert.ToDouble(inputOrdenar.Rows[fila][(24)]);
                                double totalAsset = Convert.ToDouble(inputOrdenar.Rows[fila][(14)]);
                                double r;
                                r = Math.Round((totalDebt / totalAsset), 2);
                                Calculo.Rows[fila][c] = r;//r.ToString("P");
                                fila++;
                            }
                            break;
                        //Razon deuda/patrimonio
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double totalDebt = Convert.ToDouble(inputOrdenar.Rows[fila1][(24)]);
                                double totalEquity = Convert.ToDouble(inputOrdenar.Rows[fila1][(27)]);
                                double r;
                                r = Math.Round((totalDebt / totalEquity), 2);
                                Calculo.Rows[fila1][c] = r;
                                fila1++;
                            }
                            break;
                        //Razon de apalancamiento
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila2 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double totAsset0 = Convert.ToDouble(inputOrdenar.Rows[fila2 + 1][(14)]);
                                    double totAsset1 = Convert.ToDouble(inputOrdenar.Rows[fila2][(14)]);
                                    double totEquity0 = Convert.ToDouble(inputOrdenar.Rows[fila2 + 1][(27)]);
                                    double totEquity1 = Convert.ToDouble(inputOrdenar.Rows[fila2][(27)]);
                                    double r;
                                    r = Math.Round((((totAsset0 + totAsset1) / 2) / ((totEquity0 + totEquity1) / 2)), 2);
                                    Calculo.Rows[fila2][c] = r;
                                    fila2++;
                                }
                            }
                            break;
                        //Cobertura de intereses
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila3 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double ebitda = Convert.ToDouble(inputOrdenar.Rows[fila3][(35)]);
                                    double interest = Convert.ToDouble(inputOrdenar.Rows[fila3][(39)]);
                                    double r;
                                    if (interest > 0)
                                    {
                                        r = Math.Round((ebitda / interest), 2);
                                        Calculo.Rows[fila3][c] = r;
                                    }
                                    else
                                    {
                                        Calculo.Rows[fila3][c] = "   -    ";
                                    }

                                    fila3++;
                                }
                            }
                            break;
                    }
                }
                //Transponer los valores para la presentación final
                DataTable tablaIndices = new DataTable();
                //Encabezado Primera columna
                tablaIndices.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                // num: numero de columnas a mostrar
                int num = 10; //Caso Anual
                int tam = Calculo.Rows.Count;
                int min = Math.Min(num, tam);
                if (tam < num)
                {
                    foreach (DataRow inRow in Calculo.Rows)
                    {
                        string newColName = inRow[0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        string newColName = Calculo.Rows[i][0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = tablaIndices.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (Calculo.Rows.Count < num)
                    {
                        for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < num; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                }
                return tablaIndices;
            }
            else //tipoSerie == "mes"
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                string fecha = inputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-330);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
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
                int counter1 = 0;
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(Transition.Columns[0].ColumnName);
                Calculo.Columns.Add("3.1. Razón de endeudamiento");
                Calculo.Columns.Add("3.2. Razón deuda/patrimonio");
                Calculo.Columns.Add("3.3. Razón de apalancamiento financiero");
                Calculo.Columns.Add("3.4. Cobertura de intereses");
                // se importan las fechas de los ultimos 12 meses               
                for (int i = 0; i < Transition.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(Transition.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = Transition.Rows[i][0].ToString();
                        Calculo.Rows.Add(newColName);
                    }
                }
                counter1 = Calculo.Columns.Count;
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < counter1; c++)
                {
                    switch (c)
                    {
                        //Razon de endeudamiento
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double totalDebt = Convert.ToDouble(Transition.Rows[fila][(24)]);
                                double totalAsset = Convert.ToDouble(Transition.Rows[fila][(14)]);
                                double r;
                                r = Math.Round((totalDebt / totalAsset), 2);
                                Calculo.Rows[fila][c] = r;
                                fila++;
                            }
                            break;
                        //Razon deuda/patrimonio
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double totalDebt = Convert.ToDouble(Transition.Rows[fila1][(24)]);
                                double totalEquity = Convert.ToDouble(Transition.Rows[fila1][(27)]);
                                double r;
                                r = Math.Round((totalDebt / totalEquity), 2);
                                Calculo.Rows[fila1][c] = r;
                                fila1++;
                            }
                            break;
                        //Razon de apalancamiento
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila2 + 1 < Transition.Rows.Count)
                                {
                                    double totAsset0 = Convert.ToDouble(Transition.Rows[fila2 + 1][(14)]);
                                    double totAsset1 = Convert.ToDouble(Transition.Rows[fila2][(14)]);
                                    double totEquity0 = Convert.ToDouble(Transition.Rows[fila2 + 1][(27)]);
                                    double totEquity1 = Convert.ToDouble(Transition.Rows[fila2][(27)]);
                                    double r;
                                    r = Math.Round((((totAsset0 + totAsset1) / 2) / ((totEquity0 + totEquity1) / 2)), 2);
                                    Calculo.Rows[fila2][c] = r;
                                    fila2++;
                                }
                            }
                            break;
                        //Cobertura de intereses
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila3 + 1 < Transition.Rows.Count)
                                {
                                    double ebitda = Convert.ToDouble(Transition.Rows[fila3][(35)]);
                                    double interest = Convert.ToDouble(Transition.Rows[fila3][(39)]);
                                    double r;
                                    if (interest > 0)
                                    {
                                        r = Math.Round((ebitda / interest), 2);
                                        Calculo.Rows[fila3][c] = r;
                                    }
                                    else
                                    {
                                        Calculo.Rows[fila3][c] = "   -    ";
                                    }

                                    fila3++;
                                }
                            }
                            break;
                    }
                }
                //Tansponer tabla para la presentación final
                DataTable CalculoTranspose = new DataTable();
                //Encabezado Primera columna
                CalculoTranspose.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                foreach (DataRow inRow in Calculo.Rows)
                {
                    string newColName = inRow[0].ToString();
                    CalculoTranspose.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = CalculoTranspose.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                    {
                        string colValue = Calculo.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    CalculoTranspose.Rows.Add(newRow);
                }
                return CalculoTranspose;
            }
        }

        //Indices de rentabilidad
        public DataTable CalcularIndicesIV()
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieIF.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos where DummyMes= " + month + " order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(inputOrdenar.Columns[0].ColumnName);
                Calculo.Columns.Add("4.1. Margen bruto");
                Calculo.Columns.Add("4.2. Margen operativo");
                Calculo.Columns.Add("4.3. Margen antes de impuesto");
                Calculo.Columns.Add("4.4. ROA");
                Calculo.Columns.Add("4.5. ROE");
                Calculo.Columns.Add("4.6. Margen neto");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                foreach (DataRow dc in inputOrdenar.Rows)
                {
                    Calculo.ImportRow(dc);
                }
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c <= Calculo.Columns.Count; c++)
                {
                    switch (c)
                    {
                        //Margen bruto
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double grossProfit = Convert.ToDouble(inputOrdenar.Rows[fila][(31)]);
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila][(29)]);
                                double r;
                                r = (grossProfit / ventas);
                                Calculo.Rows[fila][c] = r.ToString("P");
                                fila++;
                            }
                            break;
                        //Margen operativo
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double ebitda = Convert.ToDouble(inputOrdenar.Rows[fila1][(35)]);
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila1][(29)]);
                                double r;
                                r = (ebitda / ventas);
                                Calculo.Rows[fila1][c] = r.ToString("P");
                                fila1++;
                            }
                            break;
                        //Margen antes de impuesto
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double ebit = Convert.ToDouble(inputOrdenar.Rows[fila2][(38)]);
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila2][(29)]);
                                double r;
                                r = (ebit / ventas);
                                Calculo.Rows[fila2][c] = r.ToString("P");
                                fila2++;
                            }
                            break;
                        //ROA
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila3 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double netIncome = Convert.ToDouble(inputOrdenar.Rows[fila3][(44)]);
                                    double totAsset0 = Convert.ToDouble(inputOrdenar.Rows[fila3 + 1][(14)]);
                                    double totAsset1 = Convert.ToDouble(inputOrdenar.Rows[fila3][(14)]);
                                    double r;
                                    r = (netIncome / ((totAsset0 + totAsset1) / 2));
                                    Calculo.Rows[fila3][c] = r.ToString("P");
                                    fila3++;
                                }
                            }
                            break;
                        //ROE
                        case 5:
                            int fila4 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                if (fila4 + 1 < inputOrdenar.Rows.Count)
                                {
                                    double netIncome = Convert.ToDouble(inputOrdenar.Rows[fila4][(44)]);
                                    double equity0 = Convert.ToDouble(inputOrdenar.Rows[fila4 + 1][(27)]);
                                    double equity1 = Convert.ToDouble(inputOrdenar.Rows[fila4][(27)]);
                                    double r;
                                    r = (netIncome / ((equity0 + equity1) / 2));
                                    Calculo.Rows[fila4][c] = r.ToString("P");
                                    fila4++;
                                }
                            }
                            break;
                        //MARGEN NETO
                        case 6:
                            int fila5 = 0;
                            foreach (DataRow dc in inputOrdenar.Rows)
                            {
                                double ventas = Convert.ToDouble(inputOrdenar.Rows[fila5][(29)]);
                                double netIncome = Convert.ToDouble(inputOrdenar.Rows[fila5][(44)]);
                                double r;
                                r = netIncome / ventas;
                                Calculo.Rows[fila5][c] = r.ToString("P");
                                fila5++;
                            }
                            break;
                    }
                }
                //Transponer los valores para la presentación final
                DataTable tablaIndices = new DataTable();
                //Encabezado Primera columna
                tablaIndices.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                // num: numero de columnas a mostrar
                int num = 10; //Caso Anual
                int tam = Calculo.Rows.Count;
                int min = Math.Min(num, tam);
                if (tam < num)
                {
                    foreach (DataRow inRow in Calculo.Rows)
                    {
                        string newColName = inRow[0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        string newColName = Calculo.Rows[i][0].ToString();
                        tablaIndices.Columns.Add(newColName);
                    }
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = tablaIndices.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    //Limitar el numero de periodos mostrados en la tabla                     
                    if (Calculo.Rows.Count < num)
                    {
                        for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                    else
                    {
                        for (int cCount = 0; cCount < num; cCount++)
                        {
                            string colValue = Calculo.Rows[cCount][rCount].ToString();
                            newRow[cCount + 1] = colValue;
                        }
                        tablaIndices.Rows.Add(newRow);
                    }
                }
                return tablaIndices;
            }
            else //tipoSerie == "mes"
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                string fecha = inputOrdenar.Rows[1]["Periodo"].ToString();
                DateTime LastDate = DateTime.Parse(fecha);
                DateTime limite = LastDate.AddDays(-340);
                // Tabla de transición para limitar los registro a los ultimos 12 meses 
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
                int counter1 = 0;
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add(inputOrdenar.Columns[0].ColumnName);
                Calculo.Columns.Add("4.1. Margen bruto");
                Calculo.Columns.Add("4.2. Margen operativo");
                Calculo.Columns.Add("4.3. Margen antes de impuesto");
                Calculo.Columns.Add("4.4. ROA");
                Calculo.Columns.Add("4.5. ROE");
                Calculo.Columns.Add("4.6. Margen neto");
                // se importan las fechas de los ultimos 12 meses               
                for (int i = 0; i < Transition.Rows.Count; i++)
                {
                    DateTime control = DateTime.Parse(Transition.Rows[i][0].ToString());
                    if (control > limite)
                    {
                        string newColName = Transition.Rows[i][0].ToString();
                        Calculo.Rows.Add(newColName);
                    }
                }
                counter1 = Calculo.Columns.Count;
                //Calcular los valores de las columnas insertadas
                for (int c = 1; c < counter1; c++)
                {
                    switch (c)
                    {
                        //Margen bruto
                        case 1:
                            int fila = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double grossProfit = Convert.ToDouble(Transition.Rows[fila][(31)]);
                                double ventas = Convert.ToDouble(Transition.Rows[fila][(29)]);
                                double r;
                                r = (grossProfit / ventas);
                                Calculo.Rows[fila][c] = r.ToString("P");
                                fila++;
                            }
                            break;
                        //Margen operativo
                        case 2:
                            int fila1 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double ebitda = Convert.ToDouble(Transition.Rows[fila1][(35)]);
                                double ventas = Convert.ToDouble(Transition.Rows[fila1][(29)]);
                                double r;
                                r = (ebitda / ventas);
                                Calculo.Rows[fila1][c] = r.ToString("P");
                                fila1++;
                            }
                            break;
                        //Margen antes de impuesto
                        case 3:
                            int fila2 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double ebit = Convert.ToDouble(Transition.Rows[fila2][(38)]);
                                double ventas = Convert.ToDouble(Transition.Rows[fila2][(29)]);
                                double r;
                                r = (ebit / ventas);
                                Calculo.Rows[fila2][c] = r.ToString("P");
                                fila2++;
                            }
                            break;
                        //ROA
                        case 4:
                            int fila3 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila3 + 1 < Transition.Rows.Count)
                                {
                                    double netIncome = Convert.ToDouble(Transition.Rows[fila3][(44)]);
                                    double totAsset0 = Convert.ToDouble(Transition.Rows[fila3 + 1][(14)]);
                                    double totAsset1 = Convert.ToDouble(Transition.Rows[fila3][(14)]);
                                    double r;
                                    r = (netIncome / ((totAsset0 + totAsset1) / 2));
                                    Calculo.Rows[fila3][c] = r.ToString("P");
                                    fila3++;
                                }
                            }
                            break;
                        //ROE
                        case 5:
                            int fila4 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                if (fila4 + 1 < Transition.Rows.Count)
                                {
                                    double netIncome = Convert.ToDouble(Transition.Rows[fila4][(44)]);
                                    double equity0 = Convert.ToDouble(Transition.Rows[fila4 + 1][(27)]);
                                    double equity1 = Convert.ToDouble(Transition.Rows[fila4][(27)]);
                                    double r;
                                    r = (netIncome / ((equity0 + equity1) / 2));
                                    Calculo.Rows[fila4][c] = r.ToString("P");
                                    fila4++;
                                }
                            }
                            break;
                        //MARGEN NETO
                        case 6:
                            int fila5 = 0;
                            foreach (DataRow dc in Transition.Rows)
                            {
                                double ventas = Convert.ToDouble(Transition.Rows[fila5][(29)]);
                                double netIncome = Convert.ToDouble(Transition.Rows[fila5][(44)]);
                                double r;
                                r = netIncome / ventas;
                                Calculo.Rows[fila5][c] = r.ToString("P");
                                fila5++;
                            }
                            break;
                    }
                }
                //Tansponer tabla para la presentación final
                DataTable CalculoTranspose = new DataTable();
                //Encabezado Primera columna
                CalculoTranspose.Columns.Add(Calculo.Columns[0].ColumnName.ToString());
                // El encabezado de las otras columnas
                foreach (DataRow inRow in Calculo.Rows)
                {
                    string newColName = inRow[0].ToString();
                    CalculoTranspose.Columns.Add(newColName);
                }
                // Se agregan las columnas por cada renglón
                for (int rCount = 1; rCount <= Calculo.Columns.Count - 1; rCount++)
                {
                    DataRow newRow = CalculoTranspose.NewRow();
                    newRow[0] = Calculo.Columns[rCount].ColumnName.ToString();
                    for (int cCount = 0; cCount <= Calculo.Rows.Count - 1; cCount++)
                    {
                        string colValue = Calculo.Rows[cCount][rCount].ToString();
                        newRow[cCount + 1] = colValue;
                    }
                    CalculoTranspose.Rows.Add(newRow);
                }
                return CalculoTranspose;
            }
        }

        public DataTable EFChanges()// Determina cuales fueron las cuentas que mas cambiaron en el Balance general
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                int n = inputOrdenar.Rows.Count;
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add("Cuenta");
                Calculo.Columns.Add("PerT");
                Calculo.Columns.Add("PerT-1");
                Calculo.Columns.Add("PerT-2");
                Calculo.Columns.Add("Var");
                Calculo.Columns.Add("PorcCam");
                Calculo.Columns.Add("Tendencia");
                if (n >= 3)
                {
                    //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                    double c = Convert.ToDouble(inputOrdenar.Rows[0][28]);
                    double d = Convert.ToDouble(inputOrdenar.Rows[1][28]);
                    double e = c - d;
                    for (int cCount = 1; cCount <= 28; cCount++)
                    {
                        double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                        double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                        double r = a - b;
                        double s = r / e;
                        DataRow newRow = Calculo.NewRow();
                        if (cCount != 6 && cCount != 13 && cCount != 14 && cCount != 21 && cCount != 24 && cCount != 27)
                        {
                            newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                            newRow[1] = inputOrdenar.Rows[0][cCount];
                            newRow[2] = inputOrdenar.Rows[1][cCount];
                            newRow[3] = inputOrdenar.Rows[2][cCount];
                            newRow[4] = r;
                            newRow[5] = s;
                            double a1 = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                            double b1 = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                            double c1 = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                            if (a1 > b1 && b1 > c1)
                            {
                                newRow[6] = "Creciente";
                            }

                            else
                            {
                                if (a1 < b1 && b1 < c1)
                                {
                                    newRow[6] = "Decreciente";
                                }
                                else
                                {
                                    if (a1 == b1 && b1 == c1)
                                    {
                                        newRow[6] = "Estable";
                                    }
                                    else { newRow[6] = "Sin tendencia"; }
                                }
                            }
                            Calculo.Rows.Add(newRow);
                        }
                    }
                    Calculo.DefaultView.Sort = "PorcCam desc";
                    Calculo = Calculo.DefaultView.ToTable();
                    return Calculo;
                }
                else
                {
                    for (int cCount = 1; cCount <= 28; cCount++)
                    {
                        DataRow newRow = Calculo.NewRow();
                        newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                        newRow[1] = 1;
                        newRow[2] = 1;
                        newRow[3] = 1;
                        newRow[4] = 1;
                        newRow[5] = 1;
                        newRow[6] = "Estable";
                    }
                    return Calculo;
                }
                    
            }
            else
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                int n = inputOrdenar.Rows.Count;                
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add("Cuenta");
                Calculo.Columns.Add("PerT");
                Calculo.Columns.Add("PerT-1");
                Calculo.Columns.Add("PerT-2");
                Calculo.Columns.Add("Var");
                Calculo.Columns.Add("PorcCam");
                Calculo.Columns.Add("Tendencia");
                if (n >= 3)
                {
                    //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                    double c = Convert.ToDouble(inputOrdenar.Rows[0][28]);
                    double d = Convert.ToDouble(inputOrdenar.Rows[1][28]);
                    double e = c - d;
                    for (int cCount = 1; cCount <= 28; cCount++)
                    {
                        double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                        double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                        double r = a - b;
                        double s = r / e;
                        DataRow newRow = Calculo.NewRow();
                        if (cCount != 6 && cCount != 13 && cCount != 14 && cCount != 21 && cCount != 24 && cCount != 27)
                        {
                            newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                            newRow[1] = inputOrdenar.Rows[0][cCount];
                            newRow[2] = inputOrdenar.Rows[1][cCount];
                            newRow[3] = inputOrdenar.Rows[2][cCount];
                            newRow[4] = r;
                            newRow[5] = s;
                            double a1 = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                            double b1 = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                            double c1 = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                            if (a1 > b1 && b1 > c1)
                            {
                                newRow[6] = "Creciente";
                            }

                            else
                            {
                                if (a1 < b1 && b1 < c1)
                                {
                                    newRow[6] = "Decreciente";
                                }
                                else
                                {
                                    if (a1 == b1 && b1 == c1)
                                    {
                                        newRow[6] = "Estable";
                                    }
                                    else { newRow[6] = "Sin tendencia"; }
                                }
                            }
                            Calculo.Rows.Add(newRow);
                        }
                    }
                    Calculo.DefaultView.Sort = "PorcCam desc";
                    Calculo = Calculo.DefaultView.ToTable();
                    return Calculo;
                }
                else
                {
                    for (int cCount = 1; cCount <= 28; cCount++)
                    {
                        DataRow newRow = Calculo.NewRow();
                        newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                        newRow[1] = 1;
                        newRow[2] = 1;
                        newRow[3] = 1;
                        newRow[4] = 1;
                        newRow[5] = 1;
                        newRow[6] = "Estable";
                    }
                        return Calculo;
                }
            }
            
        }

        public DataTable EFChangesI() //Calcula la tendencia de las cuentas del estado de resultados para frecuencia anual
        {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add("Cuenta (Anual)");
                Calculo.Columns.Add("PerT");
                Calculo.Columns.Add("PerT-1");
                Calculo.Columns.Add("PerT-2");
                Calculo.Columns.Add("Tendencia");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                for (int cCount = 29; cCount <= 44; cCount++)
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
                        if(a>b && b > c)
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
                                else {newRow[4] = "Sin tendencia"; }
                            }                                                        
                        }
                        Calculo.Rows.Add(newRow);
                    }
                }
                return Calculo;
            }

        public DataTable EFChangesImensual() //Calcula la tendencia de las cuentas del estado de resultados para frecuencia mensual
        {
            DataTable inputOrdenar = new DataTable();
            this.OpenConnection();
            SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
            operario.Fill(inputOrdenar);
            this.CloseConnection();
            // Insertar columnas en una tabla
            DataTable Calculo = new DataTable();
            //Se crean los encabezados de cada columna
            Calculo.Columns.Add("Cuenta (Mensual)");
            Calculo.Columns.Add("PerT");
            Calculo.Columns.Add("PerT-1");
            Calculo.Columns.Add("PerT-2");
            Calculo.Columns.Add("Tendencia");
            //Importa de la tabla input los valores que coincidan con el nomnre de la columna
            for (int cCount = 29; cCount <= 44; cCount++)
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
            return Calculo;
        }

        public DataTable EFChangesII() //Establece las tendencias de las cuentas del balance general
        {
            string tipoSerie;
            tipoSerie = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxTipoSerieRepo.Text;
            string mesCorte = ((MainWindow)System.Windows.Application.Current.MainWindow).cbxMesCorte.Text;
            string month = ObtenerNumeroMes(mesCorte);
            DataTable Output = new DataTable();
            if (tipoSerie == "Anual")
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Periodos order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add("Cuenta");
                Calculo.Columns.Add("PerT");
                Calculo.Columns.Add("PerT-1");
                Calculo.Columns.Add("PerT-2");
                Calculo.Columns.Add("Var");
                Calculo.Columns.Add("PorcCam");
                Calculo.Columns.Add("Tendencia");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                double c = Convert.ToDouble(inputOrdenar.Rows[0][28]);
                double d = Convert.ToDouble(inputOrdenar.Rows[1][28]);
                double e = c - d;
                for (int cCount = 1; cCount <= 28; cCount++)
                {
                    double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                    double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                    double r = a - b;
                    double s = r / e;
                    DataRow newRow = Calculo.NewRow();
                    //if (cCount != 6 && cCount != 13 && cCount != 14 && cCount != 21 && cCount != 24 && cCount != 27)
                    {
                        newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                        newRow[1] = inputOrdenar.Rows[0][cCount];
                        newRow[2] = inputOrdenar.Rows[1][cCount];
                        newRow[3] = inputOrdenar.Rows[2][cCount];
                        newRow[4] = r;
                        newRow[5] = s;
                        double a1 = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                        double b1 = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                        double c1 = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                        if (a1 > b1 && b1 > c1)
                        {
                            newRow[6] = "Creciente";
                        }
                        else
                        {
                            if (a1 < b1 && b1 < c1)
                            {
                                newRow[6] = "Decreciente";
                            }
                            else
                            {
                                if (a1 == b1 && b1 == c1)
                                {
                                    newRow[6] = "Estable";
                                }
                                else { newRow[6] = "Sin tendencia"; }
                            }
                        }
                        Calculo.Rows.Add(newRow);
                    }
                }
                //Calculo.DefaultView.Sort = "PorcCam desc";
                Calculo = Calculo.DefaultView.ToTable();
                return Calculo;
            }
            else
            {
                DataTable inputOrdenar = new DataTable();
                this.OpenConnection();
                SqlCeDataAdapter operario = new SqlCeDataAdapter("Select * from Mensual order by Periodo desc", _con);
                operario.Fill(inputOrdenar);
                this.CloseConnection();
                // Insertar columnas en una tabla
                DataTable Calculo = new DataTable();
                //Se crean los encabezados de cada columna
                Calculo.Columns.Add("Cuenta");
                Calculo.Columns.Add("PerT");
                Calculo.Columns.Add("PerT-1");
                Calculo.Columns.Add("PerT-2");
                Calculo.Columns.Add("Var");
                Calculo.Columns.Add("PorcCam");
                Calculo.Columns.Add("Tendencia");
                //Importa de la tabla input los valores que coincidan con el nomnre de la columna
                double c = Convert.ToDouble(inputOrdenar.Rows[0][28]);
                double d = Convert.ToDouble(inputOrdenar.Rows[1][28]);
                double e = c - d;
                for (int cCount = 1; cCount <= 28; cCount++)
                {
                    double a = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                    double b = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                    double r = a - b;
                    double s = r / e;
                    DataRow newRow = Calculo.NewRow();
                    //if (cCount != 6 && cCount != 13 && cCount != 14 && cCount != 21 && cCount != 24 && cCount != 27)
                    {
                        newRow[0] = inputOrdenar.Columns[cCount].ColumnName.ToString();
                        newRow[1] = inputOrdenar.Rows[0][cCount];
                        newRow[2] = inputOrdenar.Rows[1][cCount];
                        newRow[3] = inputOrdenar.Rows[2][cCount];
                        newRow[4] = r;
                        newRow[5] = s;
                        double a1 = Convert.ToDouble(inputOrdenar.Rows[0][cCount]);
                        double b1 = Convert.ToDouble(inputOrdenar.Rows[1][cCount]);
                        double c1 = Convert.ToDouble(inputOrdenar.Rows[2][cCount]);
                        if (a1 > b1 && b1 > c1)
                        {
                            newRow[6] = "Creciente";
                        }
                        else
                        {
                            if (a1 < b1 && b1 < c1)
                            {
                                newRow[6] = "Decreciente";
                            }
                            else
                            {
                                if (a1 == b1 && b1 == c1)
                                {
                                    newRow[6] = "Estable";
                                }
                                else { newRow[6] = "Sin tendencia"; }
                            }
                        }
                        Calculo.Rows.Add(newRow);
                    }
                }
                //Calculo.DefaultView.Sort = "PorcCam desc";
                Calculo = Calculo.DefaultView.ToTable();
                return Calculo;
            }
        }
    }
}
