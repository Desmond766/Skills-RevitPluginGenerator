---
kind: type
id: T:Autodesk.Revit.DB.Events.WorksharedOperationProgressChangedEventArgs
source: html/110ee5e7-4cc1-3dbb-c824-6fd7bb5a8061.htm
---
# Autodesk.Revit.DB.Events.WorksharedOperationProgressChangedEventArgs

The event arguments used by the WorksharedOperationProgressChanged event, this event will be raised when executing following workshared operations.

## Syntax (C#)
```csharp
public class WorksharedOperationProgressChangedEventArgs : RevitAPISingleEventArgs
```

## Remarks
Remarks For synchronizing with central operation, there are 4 steps.
 1) Save to local (before save to central) - Serializes the streams from memory to local disk cache;
 [!:Autodesk::Revit::DB::Events::DocumentSaveToLocalProgressChangedEventArgs] 
 2) Reload latest - Downloads the streams from central model on server and merge them into local memory;
 [!:Autodesk::Revit::DB::Events::DocumentReloadLatestProgressChangedEventArgs] 
 3) Save to central - Uploads merged streams from local memory to server central model;
 [!:Autodesk::Revit::DB::Events::DocumentSaveToCentralProgressChangedEventArgs] 
 4) Save to local (after save to central) - Serializes the merged streams from memory to local disk cache;
 [!:Autodesk::Revit::DB::Events::DocumentSaveToLocalProgressChangedEventArgs] For document open operation, just download the model from server and then open it; [!:Autodesk::Revit::DB::Events::CreateRelatedFileProgressChangedEventArgs] It is NOT recommended to deal with time-consuming work when handling WorksharedOperationProgressChanged event, otherwise it would increase synchronizing with central or model open time.

