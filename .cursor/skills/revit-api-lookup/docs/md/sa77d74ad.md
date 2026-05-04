---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCHybridImport.IsValidObject
source: html/e0eb98ed-a5e7-0bba-25b9-59a2a21a947a.htm
---
# Autodesk.Revit.DB.IFC.IFCHybridImport.IsValidObject Property

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

