'*********************************************************************************************************************************
'Create by LeanTest Automation 3.2 in 04/09/2017 17:42:26 (By LeanTest Automation Test 2.0) 
'User:............ Admin
'Domain:.......... LeanTest Execution Automation
'Environment:..... Automation Project
'Application...... EudoraApp
'Functionality:... Selecionar Categoria
'Master Test:..... No Defined
'TableTest:....... test_EudoraApp_Selecionar_Categoria
'*********************************************************************************************************************************
Imports System.Text
Imports System.Text.RegularExpressions
Imports Lean.Test.Automation.Framework.LibraryGlobal.LibGlobal

Namespace test_EudoraApp_Selecionar_Categoria
    Public Class test_EudoraApp_Selecionar_Categoria
        Public Sub New()
        End Sub
        Public Function Run() As Boolean
            Try
                If StartTest() Then
                    Do While p_CountTest <> 0
                        Try
                            Test.TestLog("Evidência antes de selecionar categoria", "", "", typelog.NA)

                            vCategoria = vCategoria.ToUpper
                            Dim i = 1
                            Dim categoria = ""
                            Dim last = ""
                            Dim continueLoop = True
                            Do
                                If Test.Exist("//android.support.v7.widget.RecyclerView[@resource-id='br.com.grupoboticario.eudorarepresentante.staging:id/component_category_recycler_view']//android.widget.LinearLayout[" + i.ToString + "]//android.widget.Button", 500) Then
                                    categoria = TrimNonBreaking(Test.GetText("//android.support.v7.widget.RecyclerView[@resource-id='br.com.grupoboticario.eudorarepresentante.staging:id/component_category_recycler_view']//android.widget.LinearLayout[" + i.ToString + "]//android.widget.Button")).ToUpper
                                    If categoria.Equals(vCategoria) Then
                                        continueLoop = False
                                    Else
                                        i += 1
                                    End If
                                Else
                                    DragAndDrop("650", "230", "-500", "0")

                                    If last = categoria Then
                                        continueLoop = False
                                    End If
                                    last = categoria
                                    i = 1
                                End If
                            Loop While continueLoop

                            If categoria.Equals(vCategoria) Then
                                Test.TestLog("Buscar categoria no menu navegando pelas opções", "A categoria deve ser encontrada", "Categoria encontrada com sucesso", typelog.Passed)
                                Test.Click("//android.support.v7.widget.RecyclerView[@resource-id='br.com.grupoboticario.eudorarepresentante.staging:id/component_category_recycler_view']//android.widget.LinearLayout[" + i.ToString + "]//android.widget.Button", vbtnSelecionaCategoria)
                                Test.TestLog("Selecionar categoria", "A categoria é selecionada com sucesso", "A categoria foi selecionada com sucesso", typelog.Passed)
                            Else
                                Test.TestLog("Buscar categoria no menu navegando pelas opções", "A categoria deve ser encontrada", "Categoria não encontrada", typelog.Failed)
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
                HandlerError("test_EudoraApp_Selecionar_Categoria.test_EudoraApp_Selecionar_Categoria.Run: " & ex.Message)
                Test.TestLog("Execução do teste", "Teste executado com sucesso", "Teste executado com falha! Message: " & p_errorDescription, typelog.Failed)
                Return False
            End Try
        End Function

        Private Function DragAndDrop(x As String, y As String, dx As String, dy As String) As Boolean
            Try
                Dim WR As System.Net.HttpWebRequest

                Dim URI As New Uri("http://127.0.0.1:4723/wd/hub/sessions")
                WR = DirectCast(System.Net.HttpWebRequest.Create(URI), System.Net.HttpWebRequest)
                If (WR.GetResponse().ContentLength = 0) Then
                    Return False
                End If
                Dim RS = New System.IO.StreamReader(WR.GetResponse().GetResponseStream())
                Dim response = RS.ReadToEnd()
                Dim RX = New Regex("""id"":""(.+?)""")
                Dim sessionId = RX.Match(response).Groups(1).Value

                URI = New Uri("http://127.0.0.1:4723/wd/hub/session/" + sessionId + "/touch/perform")
                WR = DirectCast(System.Net.HttpWebRequest.Create(URI), System.Net.HttpWebRequest)
                WR.Method = "POST"
                WR.ContentType = "application/json"
                Dim content = "{""actions"":[{""action"":""press"",""options"":{""x"":" + x + ",""y"":" + y + "}},{""action"":""wait"",""options"":{""ms"":200}},{""action"":""moveTo"",""options"":{""x"":" + dx + ",""y"":" + dy + "}},{""action"":""wait"",""options"":{""ms"":100}},{""action"":""release"",""options"":{}}]}"
                WR.ContentLength = content.Length
                WR.GetRequestStream().Write(Encoding.UTF8.GetBytes(content), 0, content.Length)
                'RS = New System.IO.StreamReader(WR.GetResponse().GetResponseStream())
                'response = RS.ReadToEnd()
                Return True
            Catch ex As System.Net.WebException
                'Error in accessing the resource, handle it
                Return False
            End Try
        End Function

        Private Function TrimNonBreaking(text As String) As String
            Dim returnText = ""
            For i = 0 To text.Length - 1 Step 2
                returnText = returnText + text(i)
            Next
            Return returnText
        End Function

        '*********************************************************************************************************************************
        'STARTTEST
        Public Shared p_ExpectedResult, p_CheckPoint1 As String
        Public Shared vbtnSelecionaCategoria, vCategoria As String

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
                    vbtnSelecionaCategoria = pc_db.Fieldt("vbtnSelecionaCategoria")
                    vCategoria = pc_db.Fieldt("vCategoria")


                    pc_db.StartExecution(p_TableTest, p_IDTest)
                    If p_PublishQC Then CreateStructureQC()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("test_EudoraApp_Selecionar_Categoria.test_EudoraApp_Selecionar_Categoria.StartTest" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
    End Class
End Namespace

