---
kind: property
id: P:Autodesk.Revit.DB.IFC.ExporterIFC.IsValidObject
source: html/f42afa5b-2c19-2684-3ba5-8acf73fad2a1.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.IsValidObject Property

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

