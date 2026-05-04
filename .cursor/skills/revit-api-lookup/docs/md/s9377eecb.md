---
kind: property
id: P:Autodesk.Revit.UI.SelectionUIOptions.IsValidObject
source: html/0d47dfb4-09d9-e3b6-b483-d015d3b0bf71.htm
---
# Autodesk.Revit.UI.SelectionUIOptions.IsValidObject Property

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

