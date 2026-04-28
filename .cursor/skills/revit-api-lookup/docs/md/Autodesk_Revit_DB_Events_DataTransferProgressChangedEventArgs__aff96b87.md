---
kind: type
id: T:Autodesk.Revit.DB.Events.DataTransferProgressChangedEventArgs
source: html/a5a0081b-e990-ac8f-68dc-be0915955d1d.htm
---
# Autodesk.Revit.DB.Events.DataTransferProgressChangedEventArgs

The event arguments used during the data transferring phase of [!:Autodesk::Revit::ApplicationServices::Application::WorksharedOperationProgressChanged] .

## Syntax (C#)
```csharp
public class DataTransferProgressChangedEventArgs : WorksharedOperationProgressChangedEventArgs
```

## Remarks
It is NOT recommended to do any time-consuming work when handling WorksharedOperationProgressChanged event. This can increase workshared operation time.

