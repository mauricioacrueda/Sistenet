Imports Microsoft.VisualBasic

Public Class conexion

    Public Function conex() As String
        'Dim con As String = "Data Source=rrincon; Initial Catalog=sistenet;Integrated Security=True"
        Dim con As String = "Data Source=.\SQLEXPRESS; Initial Catalog=sistenet;Integrated Security=True"
        'Dim con As String = "Data Source=.\BUC33\SQLEXPRESS; Initial Catalog=sistenet;Integrated Security=True"
        'Dim con As String = "Data Source=.\SQLEXPRESS; Initial Catalog=Sistenet; User Id=sa; Password=mao182*"
        Return con

    End Function

End Class
