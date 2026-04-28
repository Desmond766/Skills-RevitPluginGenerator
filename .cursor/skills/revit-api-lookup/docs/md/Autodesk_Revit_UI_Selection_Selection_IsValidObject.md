---
kind: property
id: P:Autodesk.Revit.UI.Selection.Selection.IsValidObject
source: html/cd25e5c2-e087-07dc-6444-288b0e86479f.htm
---
# Autodesk.Revit.UI.Selection.Selection.IsValidObject Property

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

