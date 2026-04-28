---
kind: type
id: T:Autodesk.Revit.DB.Events.DocumentSaveToCentralProgressChangedEventArgs
source: html/5c818638-328f-555e-a668-674d9f585775.htm
---
# Autodesk.Revit.DB.Events.DocumentSaveToCentralProgressChangedEventArgs

The event arguments used during the save to central phase of [!:Autodesk::Revit::ApplicationServices::Application::WorksharedOperationProgressChanged] .

## Syntax (C#)
```csharp
public class DocumentSaveToCentralProgressChangedEventArgs : DataTransferProgressChangedEventArgs
```

## Remarks
It is NOT recommended to do any time-consuming work when handling WorksharedOperationProgressChanged event. This can increase workshared operation time.
 Name correction - it is renamed from 'DocumentSaveToCentralProgessChangedEventArgs' released since 2017 Subscription Update.

