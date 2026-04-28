---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.CanDeleteWorkset(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.WorksetId,Autodesk.Revit.DB.DeleteWorksetSettings)
source: html/6a120bcb-6b51-f8c4-2f59-e21b15c31b6a.htm
---
# Autodesk.Revit.DB.WorksetTable.CanDeleteWorkset Method

Indicates if a workset can be deleted.

## Syntax (C#)
```csharp
public static bool CanDeleteWorkset(
	Document document,
	WorksetId worksetId,
	DeleteWorksetSettings deleteWorksetSettings
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the worksets.
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The id of the workset to delete.
- **deleteWorksetSettings** (`Autodesk.Revit.DB.DeleteWorksetSettings`) - The settings to delete a workset.

## Returns
True if the workset can be deleted, false otherwise.

## Remarks
The workset can't be deleted in the following cases:
 The input worksetId is not valid in the document. The input worksetId doesn't represent a user-created workset, which means this workset might be a system workset. The workset is not editable by the current user. In order to resolve this problem,
 please checkout the workset by calling [!:Autodesk::Revit::DB::WorksharingUtils::CheckoutWorksets] . The workset or some elements under the workset are owned by the other users. In order to resolve this problem,
 please ask the other users to call [!:Autodesk::Revit::DB::WorksharingUtils::RelinquishOwnership] 
 to relinquish their ownership on the workset and elements. The target workset is not a user-created workset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

