using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessManagerInterface
{
    public partial class ManagerForm : Form
    {
        bool tabPage8Loaded = false;
        bool tabPage9Loaded = false;
        private SqlConnection cn;
        String dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        String dbName = "p5g4";
        String userName = "p5g4";
        String userPass = "Bz105107!";

        int orderID;

        public Manager St { get; set; }
        public ManagerForm()
        {
            InitializeComponent();
            // hide manageButton
            manageButton.Hide();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data Source = " + dbServer + " ;" + "initial Catalog = " + dbName + ";" + "uid = " + userName + ";" + "password = " + userPass);
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // fullscreen
            this.WindowState = FormWindowState.Maximized;
            cn = getSGBDConnection();
            verifySGBDConnection();
            SqlCommand cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Pending");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridPending.DataSource = dt;

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Shipped");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridShipped.DataSource = dt;

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Delivered");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridDelivered.DataSource = dt;

            cmd = new SqlCommand("Project.getOrdersFromStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@store", St.Url);
            cmd.Parameters.AddWithValue("@state", "Canceled");
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            canceledDataView.DataSource = dt;

            // items in stock
            cmd = new SqlCommand("SELECT ID, ItemDescription AS Product, Quantity AS InStock, Price FROM Project.ITEM WHERE StoreURL=@store", cn);
            cmd.Parameters.AddWithValue("@store", St.Url);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            ItemsDataGridView.DataSource = dt;

            // items gridView
            dataGridItems.Hide();

            // personl page
            this.name.Text = "Welcome, " + St.Name + " (" + St.Username + ")";
            this.info.Text = "ID: " + St.ID + "\n\n";
            this.info.Text += "NIF: " + St.NIF + "\n\n";
            this.info.Text += "Email: " + St.Email + "\n\n";
            this.info.Text += "Phone Number: " + St.Phone + "\n\n";
            this.info.Text += "Address: " + St.Address + "\n\n";
            this.info.Text += "Salary: " + St.Salary + " euros" + "\n\n";
            this.info.Text += "Register Date: " + St.RegisterDate + "\n\n";
            this.info.Text += "Birth Date: " + St.Birthdate + "\n\n";

            cmd = new SqlCommand("SELECT * FROM Project.getStoreRevenue(@param)", cn);
            cmd.Parameters.AddWithValue("@param", St.Url);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.info.Text += "Store: " + reader["StoreName"] + " (" + St.Url + ")" + "\n\n\n";
                this.info.Text += "STATS: " + "\n\n";

                this.info.Text += "Total Revenue: " + reader["TotalSales"].ToString() + " euros" + "\n\n";
            }
            reader.Close();
            cmd = new SqlCommand("SELECT COUNT(*) AS numOrders FROM Project.[ORDER] WHERE StoreURL=@param", cn);
            cmd.Parameters.AddWithValue("@param", St.Url);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                this.info.Text += "Number of Orders: " + reader["numOrders"].ToString() + "\n\n";
            }
            reader.Close();
            cmd = new SqlCommand("SELECT * FROM Project.getItemRevenue(@param)", cn);
            cmd.Parameters.AddWithValue("@param", St.Url);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void ManagerForm_Adjust(object sender, EventArgs e)
        {
            try {
                this.tabControl1.ItemSize = new Size((tabControl1.Width / tabControl1.TabCount) - 4
                                       , tabControl1.ItemSize.Height);

                this.tabControl2.Width = this.Width / 2;

                this.panel1.Width = this.Width / 2;
                this.panel1.Location = new Point(Width / 2, 69);
                this.tabControl2.Location = new Point(0, 69 - 28);

                this.ItemsDataGridView.Height = this.tabControl1.Height - 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.tabControl1.ItemSize = new Size((tabControl1.Width / tabControl1.TabCount) - 4
            //    , tabControl1.ItemSize.Height);

            //this.tabControl2.Width = this.Width / 2;

            //this.panel1.Width = this.Width / 2;
            //this.panel1.Location = new Point(Width / 2, 69);
            //this.tabControl2.Location = new Point(0, 69 - 28);

            //this.ItemsDataGridView.Height = this.tabControl1.Height - 100;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridPending.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                orderID = int.Parse(orderNum);
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    labelDetails.Text += "\n" + "Ordered Items (click on product to check availability):";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void tabPage8_Enter(object sender, EventArgs e)
        {

            if (!tabPage8Loaded)
            {
                CarregarDadosDaTabela(true);
                CarregarSendMessage();
                tabPage8Loaded = true;
            }
        }

        Panel panelTransport;
        Label labelTituloTransport;
        DataGridView dataGridViewTransport;
        private void CarregarDadosDaTabela(bool flag)
        {
            // Criação de um painel para agrupar o título e o DataGridView
            if(flag)
            {
                panelTransport = new Panel();
                panelTransport.Dock = DockStyle.Fill;

                // Criar um Label com o título "Histórico"
                labelTituloTransport = new Label();
                labelTituloTransport.Text = "Histórico";
                labelTituloTransport.Font = new Font(labelTituloTransport.Font, FontStyle.Bold);
                labelTituloTransport.AutoSize = true;

                // Criação e configuração de um DataGridView
                dataGridViewTransport = new DataGridView();
                dataGridViewTransport.Dock = DockStyle.Fill;
                dataGridViewTransport.ReadOnly = true;

                // Configurar as colunas do DataGridView com base nas colunas do DataTable
                dataGridViewTransport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewTransport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridViewTransport.AllowDrop = false;
                dataGridViewTransport.AllowUserToAddRows = false;
                dataGridViewTransport.AllowUserToDeleteRows = false;
                dataGridViewTransport.AllowUserToResizeRows = false;
                dataGridViewTransport.AllowUserToResizeColumns = false;
            }

            dataGridViewTransport.Rows.Clear();
            dataGridViewTransport.Columns.Clear();

            // Conexão com o banco de dados
            cn = getSGBDConnection();
            using (cn)
            {
                // Comando SQL para selecionar os dados da tabela com a condição WHERE managerNIF = NIF do Manager St
                string sqlQuery = $"SELECT * FROM Project.CONTACT_TRANSPORT WHERE managerNIF = '{St.NIF}'";

                // Criação do comando e associação com a conexão
                using (SqlCommand command = new SqlCommand(sqlQuery, cn))
                {
                    // Abertura da conexão
                    cn.Open();

                    // Criação de um DataTable para armazenar os resultados
                    DataTable dataTable = new DataTable();

                    // Preenchimento do DataTable com os dados do comando SQL
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Adicionar as colunas do DataTable ao DataGridView
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        dataGridViewTransport.Columns.Add(column.ColumnName, column.ColumnName);
                    }

                    // Adicionar as linhas do DataTable ao DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridViewTransport.Rows.Add(row.ItemArray);
                    }
                }
            }

            // Configurar a posição e tamanho dos controles dentro do painel
            labelTituloTransport.Location = new Point(0, 0);
            dataGridViewTransport.Location = new Point(0, labelTituloTransport.Bottom);

            // Definir o tamanho do painel com base no tamanho dos controles
            panelTransport.Size = new Size(Math.Max(labelTituloTransport.Width, dataGridViewTransport.Width), labelTituloTransport.Height + dataGridViewTransport.Height);

            // Adicionar o Label e o DataGridView ao painel
            panelTransport.Controls.Add(labelTituloTransport);
            panelTransport.Controls.Add(dataGridViewTransport);

            // Adicionar o painel ao tableLayoutPanel
            tableLayoutPanel.Controls.Add(panelTransport, 0, 0);
        }


        private TextBox textBox; // Variável para armazenar a referência da TextBox
        private Button salvarButton; // Variável para armazenar a referência do botão
        private string defaultText = "Message Transport"; // Texto padrão da TextBox
        private string defaultTextSup = "Message Supplier"; // Texto padrão da TextBox
        private string selectedSupplierID;
        private string selectedTransportID;

        private void CarregarSendMessage()
        {
            // Criação e configuração de um rótulo (Label) para o título
            Label titleLabel = new Label();
            titleLabel.Text = "Send Message to:";
            titleLabel.AutoSize = true;

            // Criação de uma ComboBox
            ComboBox comboBox = new ComboBox();
            //  comboBox.Dock = DockStyle.Fill;
            comboBox.Text = "Transport ID"; // Texto padrão da ComboBox

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                selectedTransportID = comboBox.SelectedItem.ToString();
            };


            // Conexão com o banco de dados
            cn = getSGBDConnection();
            using (cn)
            {
                // Comando SQL para selecionar os TransportNumbers disponíveis na tabela de contatos de transporte
                string sqlQuery = $"SELECT DISTINCT TransportNumber FROM Project.transport";

                // Criação do comando e associação com a conexão
                using (SqlCommand command = new SqlCommand(sqlQuery, cn))
                {
                    // Abertura da conexão
                    cn.Open();

                    // Execução do comando e leitura dos resultados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Limpar as opções anteriores do ComboBox
                        comboBox.Items.Clear();

                        // HashSet para armazenar os TransportNumbers únicos
                        HashSet<int> transportNumbers = new HashSet<int>();

                        // Adicionar os TransportNumbers como opções na ComboBox
                        while (reader.Read())
                        {
                            int transportNumber = reader.GetInt32(0);
                            if (!transportNumbers.Contains(transportNumber))
                            {
                                comboBox.Items.Add(transportNumber);
                                transportNumbers.Add(transportNumber);
                            }
                        }
                    }
                }
            }


            // Criação e configuração de uma TextBox
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.Text = defaultText;
            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;

            // Criação de um TableLayoutPanel com duas linhas e duas colunas
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.RowCount = 2;
            panel.ColumnCount = 2;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panel.Controls.Add(titleLabel, 0, 0);
            panel.Controls.Add(comboBox, 1, 0);
            panel.Controls.Add(textBox, 0, 1);
            panel.SetColumnSpan(textBox, 2);

            // Criação de um botão para salvar e limpar a TextBox
            salvarButton = new Button();
            salvarButton.Text = "Enviar";
            salvarButton.AutoSize = true;
            salvarButton.Dock = DockStyle.Bottom;
            salvarButton.Click += SalvarButton_Click;

            // Adicionar o TableLayoutPanel e o botão ao tableLayoutPanel
            tableLayoutPanel.Controls.Add(panel, 0, 1);
            tableLayoutPanel.Controls.Add(salvarButton, 0, 2);
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (textBox.Text == defaultText)
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = defaultText;
            }
        }

        private void SalvarButton_Click(object sender, EventArgs e)
        {
            string mensagem = textBox.Text; // Obter o conteúdo da TextBox

            if (mensagem == defaultText)
            {
                mensagem = string.Empty;
            }


            // Verifica se a variável selectedSupplierID está vazia
            if (string.IsNullOrEmpty(selectedTransportID) || string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show("Selecione um transport válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém a data atual
            DateTime currentDate = DateTime.Now;

            // Obtém a descrição do contato da TextBox


            // Criação do comando SQL para inserção dos dados
            string sqlQuery = $"INSERT INTO Project.CONTACT_TRANSPORT ( ManagerNIF, ManagerID, TransportNumber, ContactDate, ContactDescription) " +
                              $"VALUES (@ManagerNIF, @ManagerID, @TransportNumber, @ContactDate, @ContactDescription)";
            cn = getSGBDConnection();
            // Criação do comando e associação com a conexão
            using (SqlCommand command = new SqlCommand(sqlQuery, cn))
            {

                // Definição dos parâmetros do comando SQL

                command.Parameters.AddWithValue("@ManagerNIF", St.NIF);
                command.Parameters.AddWithValue("@ManagerID", St.ID);
                command.Parameters.AddWithValue("@TransportNumber", selectedTransportID);
                command.Parameters.AddWithValue("@ContactDate", currentDate);
                command.Parameters.AddWithValue("@ContactDescription", mensagem);

                // Abertura da conexão
                cn.Open();

                // Execução do comando SQL
                command.ExecuteNonQuery();

                // Exibição de uma mensagem de sucesso
                MessageBox.Show("Contato salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            // Limpar a TextBox
            textBox.Text = defaultTextSup;
            CarregarDadosDaTabela(false);
            // Faça algo com a variável "mensagem" (por exemplo, armazená-la em uma variável global ou fazer alguma operação com ela)
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {

            if (!tabPage9Loaded)
            {
                CarregarDadosSup(true);
                CarregarSendMessageSup();
                tabPage9Loaded = true;
            }
        }

        Panel panel;
        Label labelTitulo;
        DataGridView dataGridView;
        private void CarregarDadosSup(bool flag)
        {
            if (flag)
            {
                // Criação de um painel para agrupar o título e o DataGridView
                panel = new Panel();
                panel.Dock = DockStyle.Fill;

                // Criar um Label com o título "Histórico"
                labelTitulo = new Label();
                labelTitulo.Text = "Histórico";
                labelTitulo.Font = new Font(labelTitulo.Font, FontStyle.Bold);
                labelTitulo.AutoSize = true;

                // Criação e configuração de um DataGridView
                dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.ReadOnly = true;
                dataGridView.AllowDrop = false;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.AllowUserToResizeRows = false;
                dataGridView.AllowUserToResizeColumns = false;

                // Configurar as colunas do DataGridView com base nas colunas do DataTable
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            // Conexão com o banco de dados
            cn = getSGBDConnection();
            using (cn)
            {
                // Comando SQL para selecionar os dados da tabela com a condição WHERE managerNIF = NIF do Manager St
                string sqlQuery = $"SELECT * FROM Project.CONTACT_SUPPLIER WHERE managerNIF = '{St.NIF}'";

                // Criação do comando e associação com a conexão
                using (SqlCommand command = new SqlCommand(sqlQuery, cn))
                {
                    // Abertura da conexão
                    cn.Open();

                    // Criação de um DataTable para armazenar os resultados
                    DataTable dataTable = new DataTable();

                    // Preenchimento do DataTable com os dados do comando SQL
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Adicionar as colunas do DataTable ao DataGridView
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        dataGridView.Columns.Add(column.ColumnName, column.ColumnName);
                    }

                    // Adicionar as linhas do DataTable ao DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dataGridView.Rows.Add(row.ItemArray);
                    }
                }
            }

            // Configurar a posição e tamanho dos controles dentro do painel
            labelTitulo.Location = new Point(0, 0);
            dataGridView.Location = new Point(0, labelTitulo.Bottom);

            // Definir o tamanho do painel com base no tamanho dos controles
            panel.Size = new Size(Math.Max(labelTitulo.Width, dataGridView.Width), labelTitulo.Height + dataGridView.Height);

            // Adicionar o Label e o DataGridView ao painel
            panel.Controls.Add(labelTitulo);
            panel.Controls.Add(dataGridView);

            // Adicionar o painel ao tableLayoutPanel
            tableLayoutSup.Controls.Add(panel, 0, 0);
        }

        private void CarregarSendMessageSup()
        {
            // Criação e configuração de um rótulo (Label) para o título
            Label titleLabel = new Label();
            titleLabel.Text = "Send Message to:";
            titleLabel.AutoSize = true;

            // Criação de uma ComboBox
            ComboBox comboBox = new ComboBox();
            //  comboBox.Dock = DockStyle.Fill;
            comboBox.Text = "Supplier ID"; // Texto padrão da ComboBox

            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                selectedSupplierID = comboBox.SelectedItem.ToString();
            };


            // Conexão com o banco de dados
            cn = getSGBDConnection();
            using (cn)
            {
                // Comando SQL para selecionar os SupplierID dos fornecedores associados ao gerente atual
                string sqlQuery = $@"SELECT DISTINCT S.ID AS SupplierID
                        FROM Project.SUPPLIER AS S
                        INNER JOIN Project.SUPPLIES AS SP ON S.ID = SP.SupplierID
                        INNER JOIN Project.ITEM AS I ON SP.ItemID = I.ID
                        INNER JOIN Project.MANAGER AS M ON M.StoreURL = I.StoreURL
                        WHERE M.ManagerNIF = '{St.NIF}'
                        ORDER BY S.ID";

                // Criação do comando e associação com a conexão
                using (SqlCommand command = new SqlCommand(sqlQuery, cn))
                {
                    // Abertura da conexão
                    cn.Open();

                    // Execução do comando e leitura dos resultados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Limpar as opções anteriores do ComboBox
                        comboBox.Items.Clear();

                        // HashSet para armazenar os SupplierID únicos
                        HashSet<int> supplierIDs = new HashSet<int>();

                        // Adicionar os SupplierID como opções na ComboBox
                        while (reader.Read())
                        {
                            int supplierID = reader.GetInt32(0);
                            if (!supplierIDs.Contains(supplierID))
                            {
                                comboBox.Items.Add(supplierID);
                                supplierIDs.Add(supplierID);
                            }
                        }
                    }
                }
            }


            // Criação e configuração de uma TextBox
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.Text = defaultTextSup;
            textBox.Enter += TextBox_EnterSup;
            textBox.Leave += TextBox_LeaveSup;

            // Criação de um TableLayoutPanel com duas linhas e duas colunas
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.Dock = DockStyle.Fill;
            panel.RowCount = 2;
            panel.ColumnCount = 2;
            panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panel.Controls.Add(titleLabel, 0, 0);
            panel.Controls.Add(comboBox, 1, 0);
            panel.Controls.Add(textBox, 0, 1);
            panel.SetColumnSpan(textBox, 2);

            // Criação de um botão para salvar e limpar a TextBox
            salvarButton = new Button();
            salvarButton.Text = "Enviar";
            salvarButton.AutoSize = true;
            salvarButton.Dock = DockStyle.Bottom;
            salvarButton.Click += SalvarButton_ClickSup;

            // Adicionar o TableLayoutPanel e o botão ao tableLayoutPanel
            tableLayoutSup.Controls.Add(panel, 0, 1);
            tableLayoutSup.Controls.Add(salvarButton, 0, 2);
        }


        private void TextBox_EnterSup(object sender, EventArgs e)
        {
            if (textBox.Text == defaultTextSup)
            {
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LeaveSup(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = defaultTextSup;
            }
        }

        private void SalvarButton_ClickSup(object sender, EventArgs e)
        {
            string mensagem = textBox.Text; // Obter o conteúdo da TextBox

            if (mensagem == defaultTextSup)
            {
                mensagem = string.Empty;
            }


            // Verifica se a variável selectedSupplierID está vazia
            if (string.IsNullOrEmpty(selectedSupplierID) || string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show("Selecione um fornecedor válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtém a data atual
            DateTime currentDate = DateTime.Now;

            // Obtém a descrição do contato da TextBox


            // Criação do comando SQL para inserção dos dados
            string sqlQuery = $"INSERT INTO Project.CONTACT_SUPPLIER ( ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) " +
                              $"VALUES (@ManagerNIF, @ManagerID, @SupplierID, @ContactDate, @ContactDescription)";
            cn = getSGBDConnection();
            // Criação do comando e associação com a conexão
            using (SqlCommand command = new SqlCommand(sqlQuery, cn))
            {

                // Definição dos parâmetros do comando SQL

                command.Parameters.AddWithValue("@ManagerNIF", St.NIF);
                command.Parameters.AddWithValue("@ManagerID", St.ID);
                command.Parameters.AddWithValue("@SupplierID", selectedSupplierID);
                command.Parameters.AddWithValue("@ContactDate", currentDate);
                command.Parameters.AddWithValue("@ContactDescription", mensagem);

                // Abertura da conexão
                cn.Open();

                // Execução do comando SQL
                command.ExecuteNonQuery();

                // Exibição de uma mensagem de sucesso
                MessageBox.Show("Contato salvo com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            // Limpar a TextBox
            textBox.Text = defaultTextSup;
            CarregarDadosSup(false);

            // Faça algo com a variável "mensagem" (por exemplo, armazená-la em uma variável global ou fazer alguma operação com ela)
        }






        private void dataGridShipped_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridShipped.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    cmd = new SqlCommand("SELECT * FROM Project.getOrderTransportInfo(@param)", cn);
                    cmd.Parameters.AddWithValue("@param", orderNum);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                        labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                        labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                    }
                    rdr.Close();


                    labelDetails.Text += "\n" + "Ordered Items:";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void dataGridDelivered_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridDelivered.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    cmd = new SqlCommand("SELECT * FROM Project.getOrderTransportInfo(@param)", cn);
                    cmd.Parameters.AddWithValue("@param", int.Parse(orderNum));
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                        labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                        labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                    }
                    rdr.Close();
                    rdr.Close();


                    labelDetails.Text += "\n" + "Ordered Items:";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            dataGridItems.Height = panel1.Height - labelDetails.Height - 20;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabPage10)
            {
                manageButton.Visible = true;
            }
            else
            {
                manageButton.Visible = false;
            }
        }


        // for stock items display
        private void itemDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ItemForm form = new ItemForm();
                DataGridViewRow selectedRow = ItemsDataGridView.Rows[e.RowIndex];
                int itemID = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                Console.WriteLine(itemID);
                Item i = new Item(itemID);
                i.Name = selectedRow.Cells["Product"].Value.ToString();
                i.Price = double.Parse(selectedRow.Cells["Price"].Value.ToString());
                i.Quantity = int.Parse(selectedRow.Cells["InStock"].Value.ToString());
                form.item = i;
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void itemSearchChange(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ItemsDataGridView.Rows)
            {
                row.Visible = true;
            }

            string searchTerm = itemSearch.Text.ToLower();
            string selected = itemFilter.Text;
            int colIndex;

            if (selected == null)
            {
                return;
            }
            else
            {
                if (selected.Equals("ID"))
                {
                    colIndex = 0;
                }
                else
                {
                    colIndex = 1;
                }
            }
            foreach (DataGridViewRow row in ItemsDataGridView.Rows)
            {
                bool rowVisible = false;
                if (row.Cells[colIndex].Value.ToString().ToLower().Contains(searchTerm))
                {
                    Console.WriteLine(searchTerm + " --> " + row.Cells[colIndex].Value.ToString());
                    rowVisible = true;
                }

                if (!rowVisible)
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[ItemsDataGridView.DataSource];
                    currencyManager1.SuspendBinding();

                    row.Visible = rowVisible;
                }
            }
        }

        private void dataGridItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ItemForm form = new ItemForm();
                DataGridViewRow selectedRow = dataGridItems.Rows[e.RowIndex];
                int itemID = int.Parse(selectedRow.Cells["ItemID"].Value.ToString());
                Console.WriteLine(itemID);
                Item i = new Item(itemID);
                i.Name = selectedRow.Cells["ItemDescription"].Value.ToString();
                i.Price = double.Parse(selectedRow.Cells["Price"].Value.ToString());
                i.Quantity = int.Parse(selectedRow.Cells["Quantity"].Value.ToString());
                form.item = i;
                form.Show();
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }

        private void manageButton_Click(object sender, EventArgs e)
        {
            String managerNIF = St.NIF;

            SqlCommand cmd = new SqlCommand("Project.deleteCanceledOrders", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nif", managerNIF);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Canceled orders deleted successfully!");
                ManagerForm_Load(sender, e);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error deleting canceled orders: " + ex.Message);
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("There are no Orders in the canceled state right now");
            }

        }

        private void canceledDataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = canceledDataView.Rows[e.RowIndex];
                String costumerNIF = selectedRow.Cells["CostumerNIF"].Value.ToString();
                String orderNum = selectedRow.Cells["OrderNumber"].Value.ToString();
                bool flag = false;

                SqlCommand cmd = new SqlCommand("SELECT * FROM Project.PERSON", cn);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["NIF"].ToString() == costumerNIF)
                    {
                        labelDetails.AutoSize = true;
                        labelDetails.Text = "Name: " + rdr["Pname"].ToString() + "\n\n";
                        labelDetails.Text += "NIF: " + costumerNIF + "\n\n";
                        labelDetails.Text += "Address: " + rdr["Address"].ToString() + "\n\n";
                        labelDetails.Text += "Phone Number: " + rdr["PhoneNumb"].ToString() + "\n\n";
                        labelDetails.Text += "Email: " + rdr["Email"].ToString() + "\n\n\n";
                        flag = true;
                    }
                }
                rdr.Close();

                if (flag)
                {
                    cmd = new SqlCommand("SELECT * FROM Project.getOrderTransportInfo(@param)", cn);
                    cmd.Parameters.AddWithValue("@param", int.Parse(orderNum));
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                        labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                        labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                    }
                    rdr.Close();
                    rdr.Close();


                    labelDetails.Text += "\n" + "Ordered Items:";
                    panel1.Controls.Add(labelDetails);

                    dataGridItems.Show();
                    dataGridItems.Height = panel1.Height - labelDetails.Height - 20;

                    cmd = new SqlCommand("SELECT ItemID, ItemDescription, Quantity, Price FROM Project.ItemsInOrderView WHERE OrderNumber=@order", cn);
                    cmd.Parameters.AddWithValue("@order", int.Parse(orderNum));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridItems.DataSource = dt;

                    flag = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {

            }
        }
    }
}
