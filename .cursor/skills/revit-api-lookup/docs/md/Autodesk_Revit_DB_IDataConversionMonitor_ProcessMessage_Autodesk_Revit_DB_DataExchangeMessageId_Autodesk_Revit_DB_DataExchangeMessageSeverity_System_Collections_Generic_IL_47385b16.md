---
kind: method
id: M:Autodesk.Revit.DB.IDataConversionMonitor.ProcessMessage(Autodesk.Revit.DB.DataExchangeMessageId,Autodesk.Revit.DB.DataExchangeMessageSeverity,System.Collections.Generic.IList{System.String})
source: html/015145ca-6980-cfad-86bc-dd7858261d58.htm
---
# Autodesk.Revit.DB.IDataConversionMonitor.ProcessMessage Method

The default implementation ignores input and always returns true. The using app should override the behavior as necessary.
 Some examples of overridden behavior are
 1. Someone is developing a classic Revit add-on that imports STEP AP 203 solids. She will implement a log object such that
 a) At each imported face (logMessage() called with LogMessage::FaceCreated as first argument) the log object will update
 count of imported faces and call an application-specific progress indicator where appropriate
 b) If the app gets a cancel request between the calls to logMessage(), the next call will return false.
 The Import API will then cancel the conversion and clean up the intermediate data.
 2. Someone is implementing a web service to convert IFC files to RVT. As a part of that service UI, the user would like
 to cancel the conversion on the first error in order to avoid being charged for storage/processor time.
 The implementation of logMessage() in that case would be different: the cancellation request would be based on severity of the error.
 The app would probably want to keep a detailed count of entities converted.
 3. Someone is implementing an IFC importer. Each API call is fast enough that cancelation/progress requests are handled by the application.
 Problems with data should be reported to the user, but the conversion should go on regardless. The app collects its own conversion statistics.
 The app developer implements logMessage() to accumulate reported errors and appends the formatted results to her conversion report.
 The overloaded logMessage() always returns true, since all cancellations are handled by the app.

## Syntax (C#)
```csharp
bool ProcessMessage(
	DataExchangeMessageId messageId,
	DataExchangeMessageSeverity messageSeverity,
	IList<string> entityIds
)
```

## Parameters
- **messageId** (`Autodesk.Revit.DB.DataExchangeMessageId`) - Indicates a specific event during data conversion.
- **messageSeverity** (`Autodesk.Revit.DB.DataExchangeMessageSeverity`) - Indicates a severity of the event.
- **entityIds** (`System.Collections.Generic.IList < String >`) - Input objects affected by the reported event.

## Returns
If the function returns true, the import API will continue conversion. Otherwise, it will be cancelled and all intermediate data reset.

