---
kind: type
id: T:Autodesk.Revit.DB.Events.DocumentSaveToLocalProgressChangedEventArgs
source: html/a3a774b8-2913-5de6-e7ad-5daa24a9c172.htm
---
# Autodesk.Revit.DB.Events.DocumentSaveToLocalProgressChangedEventArgs

The event arguments used during the save to local phase of [!:Autodesk::Revit::ApplicationServices::Application::WorksharedOperationProgressChanged] .

## Syntax (C#)
```csharp
public class DocumentSaveToLocalProgressChangedEventArgs : WorksharedOperationProgressChangedEventArgs
```

## Remarks
It is NOT recommended to do any time-consuming work when handling WorksharedOperationProgressChanged event. This can increase workshared operation time.
 Name correction - it is renamed from 'DocumentSaveToLocalProgessChangedEventArgs' released since 2017 Subscription Update.

