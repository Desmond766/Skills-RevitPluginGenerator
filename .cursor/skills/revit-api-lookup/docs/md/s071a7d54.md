---
kind: property
id: P:Autodesk.Revit.DB.TableData.IsValidObject
source: html/c7fa73f8-59df-dd41-c8e6-4b98093e9a19.htm
---
# Autodesk.Revit.DB.TableData.IsValidObject Property

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

