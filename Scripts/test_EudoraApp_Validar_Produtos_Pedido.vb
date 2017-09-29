'*********************************************************************************************************************************
'Create by LeanTest Automation 3.2 in 29/09/2017 17:22:38 (By LeanTest Automation Test 2.0) 
'User:............ Admin
'Domain:.......... LeanTest Execution Automation
'Environment:..... Automation Project
'Application...... EudoraApp
'Functionality:... Validar Produtos Pedido
'Master Test:..... No Defined
'TableTest:....... test_EudoraApp_Validar_Produtos_Pedido
'*********************************************************************************************************************************
Imports System.Text.RegularExpressions
Imports Lean.Test.Automation.Framework.LibraryGlobal.LibGlobal

Namespace test_EudoraApp_Validar_Produtos_Pedido
    Public Class test_EudoraApp_Validar_Produtos_Pedido
        Public Sub New()
        End Sub
        Public Function Run() As Boolean
            Try
                If StartTest() Then
                    Do While p_CountTest <> 0
                        Try
                            Test.TestLog("Evidência antes de Validar Produtos Pedido", "", "", typelog.NA)

                            Dim htmlSource As String
                            htmlSource = Test.GetHtmlSource()
                            Dim mcCodes As MatchCollection = Regex.Matches(htmlSource, "text=.(\d+).[^>]+resource-id=.br.com.grupoboticario.eudorarepresentante.staging:id/component_product_info_code.")
                            Dim mcQtd As MatchCollection = Regex.Matches(htmlSource, "text=.(\d+).[^>]+resource-id=.br.com.grupoboticario.eudorarepresentante.staging:id/component_bordered_selector_view_value.")

                            Dim ok As Boolean = False

                            For i = 0 To mcCodes.Count - 1
                                If mcCodes(i).Groups(1).Value.Equals(vProduto1) And mcQtd(i).Groups(1).Value.Equals(vQuantidade1) Then
                                    ok = True
                                    Exit For
                                End If
                            Next

                            If ok Then
                                Test.TestLog("Validar Produtos no Pedido", "Validar produtos e quantidade adicionados ao pedido", "Validação realizada com sucesso", typelog.Passed)
                            Else
                                Test.TestLog("Validar Produtos no Pedido", "Validar produtos e quantidade adicionados ao pedido", "Validação com falha", typelog.Failed)
                            End If

                            'Checkpoint
                            Test.CheckPointTest(p_CheckPoint1, p_ExpectedResult)
                            'end test                         
                            Test.EndTest(p_GenerateLogTest)
                            If p_IsLoop Then StartTest() Else p_CountTest = 0
                        Catch ex As Exception
                            p_errorDescription = "Menssage error: " & ex.Message.ToString
                            Test.TestLog("Passo executado", "Execução do passo com sucesso", "Passo executado com falha! Message: " & p_errorDescription, typelog.Failed)
                            EndTestTable()
                            Test.EndTest(p_GenerateLogTest)
                            If p_IsLoop Then StartTest() Else p_CountTest = 0
                        End Try
                    Loop
                    EndTestTable()
                    Return True
                Else
                    Test.TestLog("Teste executado", "Teste executado com sucesso", "Teste executado com falha! StartTest = False", typelog.Failed)
                    EndTestTable()
                    Return False
                End If
            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                HandlerError("test_EudoraApp_Validar_Produtos_Pedido.test_EudoraApp_Validar_Produtos_Pedido.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vProduto1, vQuantidade1 As String

        Private Function StartTest() As Boolean
            Dim strQueryOut1, strQueryOut2, strQueryOut3, strQueryOut4, strQueryOut5, strQueryOut6
            Try
                p_CountTest = pc_db.OpenTestTable(p_TableTest, p_IDScenario) 'opening the test table containing all the test cases
                If p_CountTest <> 0 Then
                    p_IDScenario = pc_db.Fieldt("IDScenario") 'set IDSceario
                    p_IDTest = pc_db.Fieldt("IDTest") 'set IDTest
                    p_OrdemTest = pc_db.Fieldt("Ordem")
                    p_TestName = pc_db.Fieldt("TestName")
                    p_DescriptionTest = pc_db.Fieldt("Description")
                    p_IDRun = pc_db.Fieldt("IDRun")
                    p_ExpectedResult = pc_db.Fieldt("ExpectedResult")
                    p_IDTestInstance = pc_db.Fieldt("IDTool")
                    p_CheckPoint1 = pc_db.Fieldt("CheckPoint1")

                    'parameters output
                    strQueryOut1 = pc_db.Fieldt("QueryInput1")
                    strQueryOut2 = pc_db.Fieldt("QueryInput2")
                    strQueryOut3 = pc_db.Fieldt("QueryInput3")
                    strQueryOut4 = pc_db.Fieldt("QueryInput4")
                    strQueryOut5 = pc_db.Fieldt("QueryInput5")
                    strQueryOut6 = pc_db.Fieldt("QueryInput6")
                    'parameters input

                    'transfer values between tables
                    If strQueryOut1 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut1, p_TableTest, p_IDScenario, p_IDTest)
                    If strQueryOut2 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut2, p_TableTest, p_IDScenario, p_IDTest)
                    If strQueryOut3 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut3, p_TableTest, p_IDScenario, p_IDTest)
                    If strQueryOut4 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut4, p_TableTest, p_IDScenario, p_IDTest)
                    If strQueryOut5 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut5, p_TableTest, p_IDScenario, p_IDTest)
                    If strQueryOut6 <> Nothing Then pc_db.TransferDataInTablesArray(strQueryOut6, p_TableTest, p_IDScenario, p_IDTest)

                    p_CountTest = pc_db.OpenTestTable(p_TableTest, p_IDScenario)
                    vProduto1 = pc_db.Fieldt("vProduto1")
                    vQuantidade1 = pc_db.Fieldt("vQuantidade1")


                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_EudoraApp_Validar_Produtos_Pedido.test_EudoraApp_Validar_Produtos_Pedido.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace

