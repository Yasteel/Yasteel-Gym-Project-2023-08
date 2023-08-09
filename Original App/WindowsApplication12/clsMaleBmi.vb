Public Class clsMaleBmi
    Inherits clsBMI
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(Weight As Decimal, height As Decimal)
        MyBase.New(Weight, height)
    End Sub
End Class
