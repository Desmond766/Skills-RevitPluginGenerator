---
kind: property
id: P:Autodesk.Revit.DB.Macros.MacroModuleIterator.IsValidObject
source: html/e734d625-f3ee-79fc-c046-1023ad0c4cfc.htm
---
# Autodesk.Revit.DB.Macros.MacroModuleIterator.IsValidObject Property

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

