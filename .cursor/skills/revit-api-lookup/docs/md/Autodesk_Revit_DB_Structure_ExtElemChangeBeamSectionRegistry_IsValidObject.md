---
kind: property
id: P:Autodesk.Revit.DB.Structure.ExtElemChangeBeamSectionRegistry.IsValidObject
source: html/134a39d5-264e-05ba-8616-162b1feea170.htm
---
# Autodesk.Revit.DB.Structure.ExtElemChangeBeamSectionRegistry.IsValidObject Property

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

