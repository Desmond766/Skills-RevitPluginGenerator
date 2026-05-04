---
kind: property
id: P:Autodesk.Revit.DB.FilterOperatorAndTextString.IsValidObject
source: html/cf0e38b7-8fc5-1c69-6791-d731511771f3.htm
---
# Autodesk.Revit.DB.FilterOperatorAndTextString.IsValidObject Property

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

