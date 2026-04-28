---
kind: property
id: P:Autodesk.Revit.DB.ComponentRepeaterIterator.IsValidObject
source: html/8b1f3db5-7697-5932-7330-3b5565d32bf8.htm
---
# Autodesk.Revit.DB.ComponentRepeaterIterator.IsValidObject Property

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

