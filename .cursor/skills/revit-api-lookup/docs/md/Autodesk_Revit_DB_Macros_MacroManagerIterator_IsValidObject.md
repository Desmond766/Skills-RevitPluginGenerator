---
kind: property
id: P:Autodesk.Revit.DB.Macros.MacroManagerIterator.IsValidObject
source: html/05fdabfa-c48f-4532-c1fb-27544e5494fd.htm
---
# Autodesk.Revit.DB.Macros.MacroManagerIterator.IsValidObject Property

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

