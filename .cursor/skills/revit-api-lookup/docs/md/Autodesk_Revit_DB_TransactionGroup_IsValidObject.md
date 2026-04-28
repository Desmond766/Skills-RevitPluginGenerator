---
kind: property
id: P:Autodesk.Revit.DB.TransactionGroup.IsValidObject
source: html/34580d0f-a9ba-1981-8bc0-ae6144585c74.htm
---
# Autodesk.Revit.DB.TransactionGroup.IsValidObject Property

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

