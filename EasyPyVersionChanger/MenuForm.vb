''' <summary>
''' Main form that contains all of the application's code.
''' </summary>
Public Class MenuForm

#Region "Declarations"

    Private mLoaded As Boolean = False
    Private mApplyCheck As Boolean = False

#End Region

#Region "Events"

    ''' <summary>
    ''' Form load event
    ''' </summary>
    Private Sub OnFormLoad(sender As Object, e As EventArgs) Handles Me.Load
        Me.LoadState()
    End Sub

    ''' <summary>
    ''' Event that fires when the user wants to add a path.
    ''' </summary>
    Private Sub OnAddPath(sender As Object, e As EventArgs) Handles AddButton.Click
        Dim FBD As New FolderBrowserDialog()
        If Not FBD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Dim Directory As String = FBD.SelectedPath
            If IO.Directory.Exists(Directory) Then
                Me.SystemPathCheckList.Items.Add(Directory, True)
                Me.SaveState()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Event that fires when the state is changed by the user.
    ''' </summary>
    Private Sub OnStateChanged(sender As Object, e As ItemCheckEventArgs) Handles SystemPathCheckList.ItemCheck
        If Not mApplyCheck Then
            mApplyCheck = True

            Me.SystemPathCheckList.SetItemChecked(e.Index, e.NewValue)
            Me.SaveState()

            mApplyCheck = False
        End If
    End Sub

    ''' <summary>
    ''' Event that fires when the python filter is enabled or disabled.
    ''' </summary>
    Private Sub OnPythonCheckChanged(sender As Object, e As EventArgs) Handles PythonCheckBox.CheckedChanged
        Me.LoadState()
    End Sub

#End Region

#Region "Support Methods"

    ''' <summary>
    ''' Load the current state from the system.
    ''' </summary>
    Private Sub LoadState()
        mLoaded = False
        Me.SystemPathCheckList.Items.Clear()

        'Apply filter
        Dim Filter As String = String.Empty
        If Me.PythonCheckBox.Checked Then
            Filter = "python"
        End If

        'Read enabled items
        Dim Path As String = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine)
        Dim ExistingDirectories As New List(Of String)
        For Each Directory As String In Path.Split(";")
            If Not ExistingDirectories.Contains(Directory.ToLower()) AndAlso Directory.ToLower().Contains(Filter.ToLower()) Then
                Me.SystemPathCheckList.Items.Add(Directory, True)
                ExistingDirectories.Add(Directory.ToLower())
            End If
        Next Directory

        'Read the disabled items if they exist.
        If IO.File.Exists("disabled.txt") Then
            Dim DisabledItems() As String = IO.File.ReadAllLines("disabled.txt")
            For Each Directory As String In DisabledItems
                If Not ExistingDirectories.Contains(Directory.ToLower()) AndAlso Directory.ToLower().Contains(Filter.ToLower()) Then
                    Me.SystemPathCheckList.Items.Add(Directory, False)
                    ExistingDirectories.Add(Directory.ToLower())
                End If
            Next Directory
        End If

        mLoaded = True
    End Sub

    ''' <summary>
    ''' Commit the changes to the system.
    ''' </summary>
    Private Sub SaveState()
        If mLoaded Then
            Dim EnabledDirectories As New List(Of String)
            Dim DisabledDirectories As New List(Of String)
            For Index As Integer = 0 To Me.SystemPathCheckList.Items.Count - 1
                If Me.SystemPathCheckList.GetItemChecked(Index) Then
                    EnabledDirectories.Add(Me.SystemPathCheckList.Items(Index))
                Else
                    DisabledDirectories.Add(Me.SystemPathCheckList.Items(Index))
                End If
            Next Index

            Dim Value As String = String.Join(";", EnabledDirectories.ToArray)
            Environment.SetEnvironmentVariable("PATH", Value, EnvironmentVariableTarget.Machine)
            IO.File.WriteAllLines("disabled.txt", DisabledDirectories)
        End If
    End Sub

#End Region

End Class
