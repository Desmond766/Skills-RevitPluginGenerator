---
kind: property
id: P:Autodesk.Revit.DB.TableCellCombinedParameterData.IsValidObject
source: html/96cb0ea2-1216-83d7-baf8-69326178c15c.htm
---
# Autodesk.Revit.DB.TableCellCombinedParameterData.IsValidObject Property

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

