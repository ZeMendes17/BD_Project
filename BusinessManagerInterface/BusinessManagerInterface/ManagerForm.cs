﻿using System;
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

            // items in stock
            cmd = new SqlCommand("SELECT ID, ItemDescription AS Product, Quantity AS InStock, Price FROM Project.ITEM WHERE StoreURL=@store", cn);
            cmd.Parameters.AddWithValue("@store", St.Url);
            adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);
            ItemsDataGridView.DataSource = dt;

            // items gridView
            dataGridItems.Hide();
        }

        private void ManagerForm_Adjust(object sender, EventArgs e)
        {
            this.tabControl1.ItemSize = new Size((tabControl1.Width / tabControl1.TabCount) - 4
                , tabControl1.ItemSize.Height);

            this.tabControl2.Width = this.Width / 2;

            this.panel1.Width = this.Width / 2;
            this.panel1.Location = new Point(Width / 2, 69);
            this.tabControl2.Location = new Point(0, 69 - 28);

            this.ItemsDataGridView.Height = this.tabControl1.Height - 100;
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
                CarregarDadosDaTabela();
                CarregarSendMessage();
                tabPage8Loaded = true;
            }
        }

        private void CarregarDadosDaTabela()
        {
            // Criação de um painel para agrupar o título e o DataGridView
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;

            // Criar um Label com o título "Histórico"
            Label labelTitulo = new Label();
            labelTitulo.Text = "Histórico";
            labelTitulo.Font = new Font(labelTitulo.Font, FontStyle.Bold);
            labelTitulo.AutoSize = true;

            // Criação e configuração de um DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            // Configurar as colunas do DataGridView com base nas colunas do DataTable
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

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
            tableLayoutPanel.Controls.Add(panel, 0, 0);
        }


        private TextBox textBox; // Variável para armazenar a referência da TextBox
        private Button salvarButton; // Variável para armazenar a referência do botão
        private string defaultText = "Conversar com Transport"; // Texto padrão da TextBox
        private string defaultTextSup = "Conversar com Supplier"; // Texto padrão da TextBox
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

            // Faça algo com a variável "mensagem" (por exemplo, armazená-la em uma variável global ou fazer alguma operação com ela)
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {

            if (!tabPage9Loaded)
            {
                CarregarDadosSup();
                CarregarSendMessageSup();
                tabPage9Loaded = true;
            }
        }

        private void CarregarDadosSup()
        {
            // Criação de um painel para agrupar o título e o DataGridView
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;

            // Criar um Label com o título "Histórico"
            Label labelTitulo = new Label();
            labelTitulo.Text = "Histórico";
            labelTitulo.Font = new Font(labelTitulo.Font, FontStyle.Bold);
            labelTitulo.AutoSize = true;

            // Criação e configuração de um DataGridView
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;

            // Configurar as colunas do DataGridView com base nas colunas do DataTable
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

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
                    cmd = new SqlCommand("SELECT * FROM Project.TRANSPORT", cn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["OrderNumber"].ToString() == orderNum)
                        {
                            labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                            labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                            labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                        }
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
                    cmd = new SqlCommand("SELECT * FROM Project.TRANSPORT", cn);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["OrderNumber"].ToString() == orderNum)
                        {
                            labelDetails.Text += "Delivery Company: " + rdr["CompanyName"] + ", " + rdr["CompanyEmail"] + "\n\n";
                            labelDetails.Text += "Transportation Method: " + rdr["Method"] + "\n\n";
                            labelDetails.Text += "Transport Number: " + rdr["TransportNumber"] + "\n\n";
                        }
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

        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            dataGridItems.Height = panel1.Height - labelDetails.Height - 20;
        }
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab == tabPage4)
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
            // fazer query com o orderID que vai buscar os items da order e os mete no array
            // po-lo publico
            // de seguida comparar com o stock do produto a quantidade, se puder aparece aproved
            // se nao aparece no stock
            // bloquear os botoes ou assim
            // depois alterar o estado do pedido "shipping, canceled"
            // e ta, depois é so a personal area

        }
    }
}