Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports System.Windows.Media

Namespace Example.ViewModel
    <POCOViewModel(ImplementIDataErrorInfo := True)> _
    Public Class MainViewModel
        Inherits ViewModelBase

        Private Shared Function AddPasswordCheck(ByVal builder As PropertyMetadataBuilder(Of MainViewModel, String)) As PropertyMetadataBuilder(Of MainViewModel, String)
            Return builder.MatchesInstanceRule(Function(name, vm) vm.Password = vm.ConfirmPassword, Function() "The passwords don't match.").MinLength(8, Function() "The password must be at least 8 characters long.").MaxLength(20, Function() "The password must not exceed the length of 20.")
        End Function
        Public Shared Sub BuildMetadata(ByVal builder As MetadataBuilder(Of MainViewModel))
            builder.Property(Function(x) x.FirstName).Required(Function() "Please enter the first name.")
            builder.Property(Function(x) x.LastName).Required(Function() "Please enter the last name.")
            builder.Property(Function(x) x.Email).EmailAddressDataType(Function() "Please enter a correct email address.")
            AddPasswordCheck(builder.Property(Function(x) x.Password)).Required(Function() "Please enter the password.")
            AddPasswordCheck(builder.Property(Function(x) x.ConfirmPassword)).Required(Function() "Please confirm the password.")
        End Sub
        Public Overridable Property FirstName() As String
        Public Overridable Property LastName() As String
        Public Overridable Property Email() As String
        Public Overridable Property Password() As String
        Public Overridable Property ConfirmPassword() As String
        Public Sub OnPasswordChanged()
            Me.RaisePropertyChanged(Function() ConfirmPassword)
        End Sub
        Public Sub OnConfirmPasswordChanged()
            Me.RaisePropertyChanged(Function() Password)
        End Sub
    End Class
End Namespace