# DellTestApp
Test application for Dell Technical Test

The application is composed of a WCF service that is hosted in a Windows Forms application.
The client (WinForm application) will request the user to enter customer details that are to be added to the database. After we press the "Add customer" button we will insert/update, through the service ,the entered values in the database.Then the windows forms app will receive the generated customer ID and display it in the textbox element.

The steps I took in creating this app :

1. Created the database 'DellTestDB'
2. Created the following table :
	
	create table Customer_Details (
	CustomerID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(255),
	LastName varchar(255),
	Email varchar(255) UNIQUE
	);

3. In order to connect to the database I created a "Data Source" that I then referenced in my program in "Service1.cs". You will most likely have to modify this string according to your own created "Data Source".
4. I use 4 methods in order to : add a new customer, update a customer, check if the entered email already exists and to return the customer id of the entered email.
5. I also added some test units for the 4 methods mentioned above, both for expected result and failed result.
6. A sample for the requests is as follows :

I. Add Customer Request :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1281300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{49edad17-d82d-4da8-a8a2-a002a45d713d}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1281300+03:00" Source="TransportReceive" Type="System.ServiceModel.Channels.BufferedMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<HttpRequest>
<Method>POST</Method>
<QueryString></QueryString>
<WebHeaders>
<VsDebuggerCausalityData>uIDPo5XmEf1zXpxGgi8tWL5Fl6YAAAAAmSee2bwnokuXKY0bdmtMf0gqjhRxAnFEufln42DBG94ACQAA</VsDebuggerCausalityData>
<SOAPAction>"http://tempuri.org/IService1/AddCustomer"</SOAPAction>
<Content-Length>556</Content-Length>
<Content-Type>text/xml; charset=utf-8</Content-Type>
<Accept-Encoding>gzip, deflate</Accept-Encoding>
<Expect>100-continue</Expect>
<Host>localhost:8733</Host>
</WebHeaders>
</HttpRequest>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="67b59f7d-2d80-45cd-820a-f73b2b480791" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
<To s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://localhost:8733/Design_Time_Addresses/TheService/Service1/</To>
<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService1/AddCustomer</Action>
</s:Header>
<s:Body>
<AddCustomer xmlns="http://tempuri.org/">
<c xmlns:a="http://schemas.datacontract.org/2004/07/TheService" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
<a:Email>John.Doe@gmail.com</a:Email>
<a:Fname>John</a:Fname>
<a:Lname>Doe</a:Lname>
</c>
</AddCustomer>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

I. Add Customer Response :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1381300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{49edad17-d82d-4da8-a8a2-a002a45d713d}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1381300+03:00" Source="TransportSend" Type="System.ServiceModel.Dispatcher.OperationFormatter+OperationFormatterMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<Addressing>
<Action>http://tempuri.org/IService1/AddCustomerResponse</Action>
</Addressing>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="ebc5ec06-4c7c-4756-82ae-6640d8084af1" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
</s:Header>
<s:Body>
<AddCustomerResponse xmlns="http://tempuri.org/">
<AddCustomerResult>1</AddCustomerResult>
</AddCustomerResponse>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

II. Check if the email already exists in the DB request :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1281300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{437b83e9-466e-4447-bcdb-4c67a3ac32d7}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1281300+03:00" Source="TransportReceive" Type="System.ServiceModel.Channels.BufferedMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<HttpRequest>
<Method>POST</Method>
<QueryString></QueryString>
<WebHeaders>
<VsDebuggerCausalityData>uIDPo5TmEf1zXpxGgi8tWL5Fl6YAAAAAmSee2bwnokuXKY0bdmtMf0gqjhRxAnFEufln42DBG94ACQAA</VsDebuggerCausalityData>
<SOAPAction>"http://tempuri.org/IService1/AlreadyExists"</SOAPAction>
<Connection>Keep-Alive</Connection>
<Content-Length>383</Content-Length>
<Content-Type>text/xml; charset=utf-8</Content-Type>
<Accept-Encoding>gzip, deflate</Accept-Encoding>
<Expect>100-continue</Expect>
<Host>localhost:8733</Host>
</WebHeaders>
</HttpRequest>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="88e470d3-6b70-453a-afe2-c2bc09b781f5" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
<To s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://localhost:8733/Design_Time_Addresses/TheService/Service1/</To>
<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService1/AlreadyExists</Action>
</s:Header>
<s:Body>
<AlreadyExists xmlns="http://tempuri.org/">
<s>John.Doe@gmail.com</s>
</AlreadyExists>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

II. Check if the email already exists in the DB response :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1281300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{437b83e9-466e-4447-bcdb-4c67a3ac32d7}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1281300+03:00" Source="TransportSend" Type="System.ServiceModel.Channels.BodyWriterMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<Addressing>
<Action>http://tempuri.org/IService1/AlreadyExistsResponse</Action>
</Addressing>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="e914a34e-3c01-44de-baf4-c078436ec499" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
</s:Header>
<s:Body>
<AlreadyExistsResponse xmlns="http://tempuri.org/">
<AlreadyExistsResult>0</AlreadyExistsResult>
</AlreadyExistsResponse>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

III. Return the customer ID request :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1381300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{6af40eba-156e-446a-9fd7-96008daf3a2b}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1381300+03:00" Source="TransportReceive" Type="System.ServiceModel.Channels.BufferedMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<HttpRequest>
<Method>POST</Method>
<QueryString></QueryString>
<WebHeaders>
<VsDebuggerCausalityData>uIDPo5bmEf1zXpxGgi8tWL5Fl6YAAAAAmSee2bwnokuXKY0bdmtMf0gqjhRxAnFEufln42DBG94ACQAA</VsDebuggerCausalityData>
<SOAPAction>"http://tempuri.org/IService1/ReturnId"</SOAPAction>
<Content-Length>373</Content-Length>
<Content-Type>text/xml; charset=utf-8</Content-Type>
<Accept-Encoding>gzip, deflate</Accept-Encoding>
<Expect>100-continue</Expect>
<Host>localhost:8733</Host>
</WebHeaders>
</HttpRequest>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="14b547e7-6de9-4bb2-af51-c6e54ce34786" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
<To s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://localhost:8733/Design_Time_Addresses/TheService/Service1/</To>
<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService1/ReturnId</Action>
</s:Header>
<s:Body>
<ReturnId xmlns="http://tempuri.org/">
<s>John.Doe@gmail.com</s>
</ReturnId>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

III. Return the customer ID response :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:30:20.1381300Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{6af40eba-156e-446a-9fd7-96008daf3a2b}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:30:20.1381300+03:00" Source="TransportSend" Type="System.ServiceModel.Channels.BodyWriterMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<Addressing>
<Action>http://tempuri.org/IService1/ReturnIdResponse</Action>
</Addressing>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="2e543a56-503f-463a-9b18-773132f8a2be" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
</s:Header>
<s:Body>
<ReturnIdResponse xmlns="http://tempuri.org/">
<ReturnIdResult>42</ReturnIdResult>
</ReturnIdResponse>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

IV. Update the customer other parameters when the email already exists ('alreadyexists' response will be '1') in the database request :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:34:50.9652051Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{e75319f2-8ddf-4b5b-b402-8acc280d6a1b}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:34:50.9652051+03:00" Source="TransportReceive" Type="System.ServiceModel.Channels.BufferedMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<HttpRequest>
<Method>POST</Method>
<QueryString></QueryString>
<WebHeaders>
<VsDebuggerCausalityData>uIDPo5jmEf1zXpxGgi8tWL5Fl6YAAAAAmSee2bwnokuXKY0bdmtMf0gqjhRxAnFEufln42DBG94ACQAA</VsDebuggerCausalityData>
<SOAPAction>"http://tempuri.org/IService1/UpdateCustomer"</SOAPAction>
<Content-Length>565</Content-Length>
<Content-Type>text/xml; charset=utf-8</Content-Type>
<Accept-Encoding>gzip, deflate</Accept-Encoding>
<Expect>100-continue</Expect>
<Host>localhost:8733</Host>
</WebHeaders>
</HttpRequest>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="77e64cc8-ed6c-4d52-8d1f-049b9a027733" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
<To s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://localhost:8733/Design_Time_Addresses/TheService/Service1/</To>
<Action s:mustUnderstand="1" xmlns="http://schemas.microsoft.com/ws/2005/05/addressing/none">http://tempuri.org/IService1/UpdateCustomer</Action>
</s:Header>
<s:Body>
<UpdateCustomer xmlns="http://tempuri.org/">
<c xmlns:a="http://schemas.datacontract.org/2004/07/TheService" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
<a:Email>John.Doe@gmail.com</a:Email>
<a:Fname>Michael</a:Fname>
<a:Lname>Doe</a:Lname>
</c>
</UpdateCustomer>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>

IV. Update the customer other parameters when the email already exists ('alreadyexists' response will be '1') in the database response :

<E2ETraceEvent xmlns="http://schemas.microsoft.com/2004/06/E2ETraceEvent">
<System xmlns="http://schemas.microsoft.com/2004/06/windows/eventlog/system">
<EventID>0</EventID>
<Type>3</Type>
<SubType Name="Information">0</SubType>
<Level>8</Level>
<TimeCreated SystemTime="2018-10-22T20:34:50.9752051Z" />
<Source Name="System.ServiceModel.MessageLogging" />
<Correlation ActivityID="{e75319f2-8ddf-4b5b-b402-8acc280d6a1b}" />
<Execution ProcessName="WcfSvcHost" ProcessID="8544" ThreadID="10" />
<Channel />
<Computer>GAMER-PC</Computer>
</System>
<ApplicationData>
<TraceData>
<DataItem>
<MessageLogTraceRecord Time="2018-10-22T23:34:50.9752051+03:00" Source="TransportSend" Type="System.ServiceModel.Dispatcher.OperationFormatter+OperationFormatterMessage" xmlns="http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace">
<Addressing>
<Action>http://tempuri.org/IService1/UpdateCustomerResponse</Action>
</Addressing>
<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
<s:Header>
<ActivityId CorrelationId="a13453e8-2cd3-4dd2-8329-cd2d2ec326b2" xmlns="http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics">00000000-0000-0000-0000-000000000000</ActivityId>
</s:Header>
<s:Body>
<UpdateCustomerResponse xmlns="http://tempuri.org/">
<UpdateCustomerResult>1</UpdateCustomerResult>
</UpdateCustomerResponse>
</s:Body>
</s:Envelope>
</MessageLogTraceRecord>
</DataItem>
</TraceData>
</ApplicationData>
</E2ETraceEvent>
