'*********************************************************************************************************************************
'Create by LeanTest Automation 3.2 in 23/08/2017 16:42:35 (By LeanTest Automation Test 2.0) 
'User:............ Admin
'Domain:.......... LeanTest Execution Automation
'Environment:..... Automation Project
'Application...... EudoraApp
'Functionality:... Busca - Histórico
'Master Test:..... No Defined
'TableTest:....... test_EudoraApp_Busca_Historico
'*********************************************************************************************************************************
Imports Lean.Test.Automation.Framework.LibraryGlobal.LibGlobal

Namespace test_EudoraApp_Busca_Historico
    Public Class test_EudoraApp_Busca_Historico
        Public Sub New()
        End Sub
        Public Function Run() As Boolean
            Try
                If StartTest() Then
                    Do While p_CountTest <> 0
                        Try
                            Test.TestLog("Evidência antes do click em Voltar", "", "", typelog.NA)

                            If CBool(vbtnVoltar) Then
                                Test.Click("//android.widget.ImageButton", vbtnVoltar) 'click ClickBusca
                                Test.TestLog("Clicar em Voltar", "Clicar em Voltar e verificar o resultado esperado", "Clique em Voltar realizado com sucesso", typelog.Passed)
                            End If
                            If CBool(vbtnClickBusca) Then
                                Test.Click("br.com.grupoboticario.eudorarepresentante.staging:id/fragment_home_search_bar_container", vbtnClickBusca, typeIdentification.id) 'click ClickBusca
                                Test.TestLog("Clicar em Busca", "Clicar em Busca e verificar o resultado esperado", "Clique em Busca com sucesso", typelog.Passed)
                            End If

                            Test.WaitExist("br.com.grupoboticario.eudorarepresentante.staging:id/view_holder_history_search_icon", typeIdentification.id)
                            Test.TestLog("Evidência do histórico", "", "", typelog.NA)

                            Dim text As String
                            text = Test.GetText("br.com.grupoboticario.eudorarepresentante.staging:id/view_holder_history_search_text", typeIdentification.id)
                            Dim c = text.ToCharArray
                            text = ""
                            For i = 0 To c.Length - 1 Step 2
                                text = text + c(i)
                            Next

                            If text.Equals(vBusca) Then
                                Test.TestLog("Verificar histórico", "Verificar histórico após realizar uma busca", "Verificação realizada com sucesso", typelog.Passed)
                            Else
                                Test.TestLog("Verificar histórico", "Verificar histórico após realizar uma busca", "Verificação falhou", typelog.Failed)
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
				HandlerError("test_EudoraApp_Busca_Historico.test_EudoraApp_Busca_Historico.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vbtnClickBusca, vbtnVoltar, vBusca As String

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
                    vbtnClickBusca = pc_db.Fieldt("vbtnClickBusca")
                    vbtnVoltar = pc_db.Fieldt("vbtnVoltar")
                    vBusca = pc_db.Fieldt("vBusca")

                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_EudoraApp_Busca_Historico.test_EudoraApp_Busca_Historico.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace

