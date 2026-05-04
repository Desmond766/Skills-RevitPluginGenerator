---
kind: property
id: P:Autodesk.Revit.DB.CustomFieldData.IsValidObject
source: html/e64faaa7-4a8d-84a2-4c14-049b2687bc12.htm
---
# Autodesk.Revit.DB.CustomFieldData.IsValidObject Property

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

