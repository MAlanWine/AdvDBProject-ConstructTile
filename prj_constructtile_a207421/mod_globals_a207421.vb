Imports System.Data.OleDb

Module mod_globals_a207421
    ' Database connection variables
    Public dbConnection As OleDbConnection
    Public dbCommand As OleDbCommand
    Public dbDataAdapter As OleDbDataAdapter
    Public dbDataSet As DataSet
    Public dbDataReader As OleDbDataReader

    ' Database file path (relative to bin\Debug directory)
    Public Const DB_PATH As String = ".\DB_CONSTRUCTTILE_A207421.accdb"
    Public dbConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & DB_PATH

    ' Global function to initialize database connection
    Public Function InitializeDatabase() As Boolean
        Try
            dbConnection = New OleDbConnection(dbConnectionString)
            dbConnection.Open()
            dbConnection.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Database connection error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Function to execute SELECT queries and return DataTable
    Public Function ExecuteQuery(query As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            dbConnection = New OleDbConnection(dbConnectionString)
            dbDataAdapter = New OleDbDataAdapter(query, dbConnection)
            dbDataAdapter.Fill(dataTable)
        Catch ex As Exception
            MessageBox.Show("Query execution error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If dbConnection IsNot Nothing AndAlso dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
        Return dataTable
    End Function

    ' Function to execute INSERT, UPDATE, DELETE queries
    Public Function ExecuteNonQuery(query As String) As Boolean
        Try
            dbConnection = New OleDbConnection(dbConnectionString)
            dbConnection.Open()
            dbCommand = New OleDbCommand(query, dbConnection)
            dbCommand.ExecuteNonQuery()
            dbConnection.Close()
            Return True
        Catch ex As Exception
            MessageBox.Show("Query execution error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            If dbConnection IsNot Nothing AndAlso dbConnection.State = ConnectionState.Open Then
                dbConnection.Close()
            End If
        End Try
    End Function

    ' Function to load data into DataGridView
    Public Sub LoadDataIntoGrid(gridView As DataGridView, tableName As String)
        Try
            Dim query As String = "SELECT * FROM " & tableName
            Dim dataTable As DataTable = ExecuteQuery(query)
            gridView.DataSource = dataTable
            gridView.AutoResizeColumns()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Light blue theme colors
    Public Const THEME_PRIMARY As Integer = &HFFE0B2 ' Light blue
    Public Const THEME_SECONDARY As Integer = &HFFCC80 ' Lighter blue
    Public Const THEME_ACCENT As Integer = &HFF9800 ' Orange accent
    Public Const THEME_TEXT As Integer = &H333333 ' Dark text

    ' Function to apply theme to form
    Public Sub ApplyTheme(frm As Form)
        frm.BackColor = Color.FromArgb(THEME_PRIMARY)
    End Sub

    ' Function to apply theme to button
    Public Sub ApplyButtonTheme(btn As Button)
        btn.BackColor = Color.FromArgb(&H81D4FA) ' Light blue
        btn.ForeColor = Color.FromArgb(&H01579B) ' Dark blue text
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = Color.FromArgb(&H0288D1)
        btn.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
    End Sub
End Module
