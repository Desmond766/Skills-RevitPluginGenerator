---
kind: property
id: P:Autodesk.Revit.UI.RevisionsOnSheetUIServiceData.IsValidObject
source: html/e10df7c4-f75b-9ad9-3c7b-0b0a366b9622.htm
---
# Autodesk.Revit.UI.RevisionsOnSheetUIServiceData.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

