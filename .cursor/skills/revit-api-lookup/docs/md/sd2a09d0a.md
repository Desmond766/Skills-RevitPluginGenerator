---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCTransaction.IsValidObject
source: html/b9f626f7-7381-0af9-1a2b-50405866f3e2.htm
---
# Autodesk.Revit.DB.IFC.IFCTransaction.IsValidObject Property

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

