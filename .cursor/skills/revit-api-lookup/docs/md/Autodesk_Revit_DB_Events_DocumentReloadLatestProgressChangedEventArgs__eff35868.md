---
kind: type
id: T:Autodesk.Revit.DB.Events.DocumentReloadLatestProgressChangedEventArgs
source: html/dfe6923a-ec47-704d-8e2b-29c2371beef1.htm
---
# Autodesk.Revit.DB.Events.DocumentReloadLatestProgressChangedEventArgs

The event arguments used during the reload latest phase of [!:Autodesk::Revit::ApplicationServices::Application::WorksharedOperationProgressChanged] .

## Syntax (C#)
```csharp
public class DocumentReloadLatestProgressChangedEventArgs : DataTransferProgressChangedEventArgs
```

## Remarks
It is NOT recommended to do any time-consuming work when handling WorksharedOperationProgressChanged event. This can increase workshared operation time.
 Name correction - it is renamed from 'DocumentReloadLatestProgessChangedEventArgs' released since 2017 Subscription Update.

