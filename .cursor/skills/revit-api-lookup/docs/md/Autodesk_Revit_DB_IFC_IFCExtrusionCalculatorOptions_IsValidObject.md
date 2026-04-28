---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions.IsValidObject
source: html/a8f91af6-4397-c3fa-9cea-db1d44e63847.htm
---
# Autodesk.Revit.DB.IFC.IFCExtrusionCalculatorOptions.IsValidObject Property

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

