---
kind: property
id: P:Autodesk.Revit.DB.TableCellCalculatedValueData.IsValidObject
source: html/8bc99a68-f19d-1a18-86b4-665ac51d1e76.htm
---
# Autodesk.Revit.DB.TableCellCalculatedValueData.IsValidObject Property

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

